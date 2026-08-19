# Sprint 1: Autenticacion y Sincronizacion

## Alcance implementado

- Registro de cuenta con nombre, apellido, fecha de nacimiento, correo, contrasena y confirmacion.
- Validacion de edad minima de 13 anos, correo unico, contrasena minima de ocho caracteres y bloqueo tras cinco intentos fallidos durante cinco minutos.
- Inicio y cierre de sesion basados en ASP.NET Core Identity y OpenIddict.
- Tokens de acceso de 15 minutos y refresh tokens de 30 dias.
- Persistencia PostgreSQL en esquemas separados: `identity` y `sync`.
- Endpoint de sincronizacion delta protegido por token, aislado por usuario, idempotente y con resolucion `last write wins` por `updated_at`.
- Cliente MAUI con `SecureStorage`, SQLite, estado de conectividad y pantalla de registro/login/logout.

## Limite de alcance

Sprint 1 entrega la plataforma de autenticacion y sincronizacion. La cola SQLite, el contrato delta y el endpoint Sync ya estan disponibles para las entidades de negocio.

La historia HU-A1-026 no se considera cerrada hasta que una transaccion real pueda crearse, leerse y modificarse sin red, y luego sincronizarse automaticamente. Esa validacion se implementa con HU-A1-009 en Sprint 2, sin redisenar la infraestructura de Sync.

## Endpoints

| Metodo | Ruta | Autenticacion | Descripcion |
|---|---|---|---|
| POST | `/api/auth/register` | No | Crea la cuenta y devuelve credenciales OpenIddict. |
| POST | `/api/auth/login` | No | Autentica con correo y contrasena. |
| POST | `/api/auth/logout` | Bearer | Invalida el sello de seguridad del usuario y elimina la sesion local. |
| POST | `/connect/token` | No | Emite tokens con grant `password`; acepta `refresh_token` mediante OpenIddict. |
| POST | `/api/sync/push` | Bearer | Aplica cambios del usuario actual. |
| GET | `/api/sync/pull?since={utc}` | Bearer | Devuelve cambios del usuario actual posteriores a `since`. |
| GET | `/health` | No | Health check del Host o Gateway. |

## Ejecutar localmente

```powershell
docker compose -f src/infra/docker/docker-compose.yml up -d postgres
dotnet run --project src/backend/Host/App.Host --launch-profile https
dotnet run --project src/backend/Gateway/App.Gateway --launch-profile https
dotnet run --project src/mobile/HuelgoApp.Mobile -f net10.0-windows10.0.19041.0
```

El Host usa la conexion de `appsettings.Development.json`. Para otro entorno, configura `ConnectionStrings__Postgres`. Las migraciones solo se aplican cuando `Database__ApplyMigrations=true`; esto evita que los tests necesiten una base PostgreSQL local.

## Persistencia y conflictos

Cada cambio contiene `EntityType`, `EntityId`, `Payload`, `UpdatedAt` y opcionalmente `DeletedAt`. El servidor conserva los datos por `UserId`. Si llegan dos cambios para la misma entidad, se acepta solamente el que tenga `UpdatedAt` mas reciente. Los futuros modulos Budget y Tasks deben convertir sus escrituras locales en estos cambios, preservando el soft delete mediante `DeletedAt`.

## Seguridad

- Las contrasenas se procesan con ASP.NET Core Identity; nunca se guardan ni registran en texto plano.
- Los tokens se almacenan exclusivamente en `SecureStorage` de MAUI.
- Los endpoints de sincronizacion requieren Bearer token y filtran siempre por el sujeto autenticado.
- Las dependencias se verifican con:

```powershell
dotnet list HuelgoApp.slnx package --include-transitive --vulnerable
```

El escaneo actual no informa vulnerabilidades conocidas.

## Validacion

```powershell
dotnet test tests/unit/HuelgoApp.Tests.Unit/HuelgoApp.Tests.Unit.csproj
dotnet test tests/integration/HuelgoApp.Tests.Integration/HuelgoApp.Tests.Integration.csproj
dotnet build HuelgoApp.slnx --no-restore
```

La validacion end-to-end sobre PostgreSQL comprueba registro, access token, refresh token, bloqueo tras cinco fallos, sincronizacion `push`/`pull`, resolucion `last write wins` y revocacion de sesion por `SecurityStamp`.