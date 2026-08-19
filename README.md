# HuelgoApp

> App móvil multiplataforma para gestión de presupuesto personal y tareas.
> Frontend en .NET MAUI — Backend modular en ASP.NET Core 9 — Desplegado en Azure.

## ¿Por qué HuelgoApp?

Huelgo representa el espacio de calma y control que busca el usuario: tener margen para respirar, organizar sus finanzas y cumplir sus tareas sin caos. El nombre refleja la promesa de la app: recuperar claridad, prioridad y equilibrio en la vida diaria.

## Estructura del Repositorio

```
HuelgoApp/
├── src/
│   ├── mobile/
│   │   └── HuelgoApp.Mobile/            # MAUI (Android + iOS)
│   ├── backend/
│   │   ├── Gateway/App.Gateway/         # YARP — API Gateway
│   │   ├── Host/App.Host/               # Entry point — composition root
│   │   ├── Shared/
│   │   │   ├── Shared.Kernel/           # Contratos, tipos base, abstracciones
│   │   │   └── Shared.Infrastructure/   # Logging, resiliencia, configuración común
│   │   └── Modules/
│   │       ├── Identity/                # Autenticación, usuarios, perfiles
│   │       ├── Budget/                  # Transacciones, categorías, presupuesto
│   │       ├── Tasks/                   # Tareas, subtareas, recordatorios
│   │       ├── Notifications/           # Push notifications, alertas
│   │       └── Sync/                    # Sincronización offline-first
│   └── infra/
│       ├── docker/                      # docker-compose (dev local)
│       ├── k8s/helm/                    # Helm charts (AKS)
│       └── bicep/                       # IaC Azure
├── tests/
│   ├── unit/
│   └── integration/
└── docs/                                # Requerimientos, wireframes, ADRs
```

## Dependencias por módulo

Cada módulo sigue Clean Architecture:

```
Domain  ←  Application  ←  Api
             ↑
         Infrastructure
```

- `Domain`: entidades, value objects, domain events. Sin dependencias externas.
- `Application`: CQRS commands/queries (MediatR). Depende solo de Domain.
- `Api`: endpoints/controllers. Depende de Application.
- `Infrastructure`: EF Core, repos, servicios externos. Depende de Application + Domain.

## Levantar el entorno local

```bash
# 1. Servicios de infraestructura (PostgreSQL, Redis, RabbitMQ, Seq)
docker compose -f src/infra/docker/docker-compose.yml up -d

# 2. Backend
dotnet run --project src/backend/Host/App.Host

# 3. Gateway (en otra terminal)
dotnet run --project src/backend/Gateway/App.Gateway
```

## Sprint 1: Autenticación y sincronización

El Sprint 1 implementa registro, inicio y cierre de sesión con ASP.NET Core Identity y OpenIddict, además de la base de sincronización offline-first. Todos los proyectos usan .NET 10.

1. Levanta PostgreSQL con Docker Compose.
2. Ejecuta el Host en perfil Development. La configuración `Database:ApplyMigrations` aplica las migraciones de los esquemas `identity` y `sync`.
3. Ejecuta Gateway. El cliente MAUI usa `https://localhost:7291` como entrada local.
4. Inicia la app MAUI para registrar o iniciar sesión. Los tokens se guardan con `SecureStorage` y SQLite crea su cola local en el directorio privado de la aplicación.

Consulta [la guía técnica del Sprint 1](docs/SPRINT_1_AUTH_SYNC.md) para los contratos HTTP, seguridad y comandos de validación.

## Documentación

- [Requerimiento de Producto](docs/REQUIREMENT.md)
- [Wireframes](docs/WIREFRAMES.md)
- [Architecture Decision Records](docs/adr/)
- [Sprint 1: autenticación y sincronización](docs/SPRINT_1_AUTH_SYNC.md)
