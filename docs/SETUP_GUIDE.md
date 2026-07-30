# Guía de Alistamiento de Ambiente — PersonalHub

> **Para quién es esta guía:** para alguien que nunca ha configurado este tipo de ambiente y quiere seguir los pasos sin adivinar nada.
> **Última actualización:** 2026-07-30

---

## ¿Necesito hacer todo esto antes de escribir la primera línea de código?

**No.** Esta guía está dividida en fases y cada fase se hace cuando la necesitas:

| Fase | Cuándo la necesitas | Tiempo estimado |
|---|---|---|
| **Fase 1 — Herramientas locales** | Antes del Sprint 1 ← **empieza aquí** | ~1 hora |
| **Fase 2 — Servicios locales (Docker)** | Antes del Sprint 1 | ~30 min |
| **Fase 3 — Emulador Android** | Cuando vayas a probar la app móvil | ~45 min |
| **Fase 4 — Firebase** | Antes del Sprint 8 (notificaciones) | ~30 min |
| **Fase 5 — Azure** | Antes de hacer el primer despliegue | ~2 horas |
| **Fase 6 — CI/CD** | Cuando tengas algo que desplegar | ~1 hora |

**Para arrancar el Sprint 1 solo necesitas las Fases 1 y 2.**

---

## Fase 1 — Herramientas locales

Estas son las aplicaciones que necesitas instaladas en tu computador.

### 1.1 Verificar lo que ya tienes

Abre una terminal (PowerShell) y ejecuta estos comandos. Si devuelven una versión, ya lo tienes instalado:

```powershell
# Verificar .NET
dotnet --version
# Esperado: 10.0.x ✅ (ya instalado)

# Verificar Git
git --version
# Esperado: git version 2.x.x

# Verificar Docker
docker --version
# Esperado: Docker version 2x.x

# Verificar Azure CLI
az --version
# Esperado: azure-cli 2.x.x (no urgente, se necesita en Fase 5)
```

---

### 1.2 Docker Desktop *(obligatorio para Sprint 1)*

**¿Para qué sirve?** Docker es como una "caja" que corre programas (base de datos, cache, etc.) de forma aislada en tu computador, sin instalarlos directamente. Así tu computador no se ensucia y todos los del equipo tienen exactamente el mismo ambiente.

**¿Cómo instalarlo?**

1. Ve a: **https://www.docker.com/products/docker-desktop**
2. Descarga la versión para **Windows**.
3. Ejecuta el instalador. Durante la instalación:
   - Acepta los términos.
   - Cuando pregunte "Use WSL 2 instead of Hyper-V" → marca esa opción si aparece.
4. Reinicia el computador cuando te lo pida.
5. Abre Docker Desktop. La primera vez tarda unos minutos en arrancar.
6. Verifica que funciona:
   ```powershell
   docker run hello-world
   ```
   Debe mostrar un mensaje que dice "Hello from Docker!".

> **Si ves un error sobre WSL 2:** abre PowerShell como administrador y ejecuta:
> ```powershell
> wsl --install
> wsl --update
> ```
> Luego reinicia y vuelve a abrir Docker Desktop.

---

### 1.3 Visual Studio 2022 o VS Code *(ya debes tener uno)*

**¿Cuál usar?**

- **Visual Studio 2022 Community** → mejor para MAUI y desarrollo .NET con más herramientas visuales. Gratis.
- **VS Code** → más liviano, suficiente para el backend.

**Para instalar Visual Studio 2022 Community:**

1. Ve a: **https://visualstudio.microsoft.com/vs/community/**
2. Descarga e instala.
3. Durante la instalación, en "Workloads" selecciona:
   - ✅ **ASP.NET and web development**
   - ✅ **.NET Multi-platform App UI development** (esto es MAUI)
4. En "Individual components" asegúrate que esté:
   - ✅ **.NET 9.0 Runtime**
   - ✅ **.NET 10.0 Runtime**

> La instalación toma entre 20 y 40 minutos dependiendo de tu internet.

---

### 1.4 Git *(probablemente ya lo tienes)*

**¿Para qué sirve?** Es el sistema que guarda el historial de cambios del código. Ya tienes el repositorio iniciado.

Si no lo tienes:
1. Ve a: **https://git-scm.com/download/win**
2. Descarga e instala con todas las opciones por defecto.
3. Configura tu identidad (una sola vez):
   ```powershell
   git config --global user.name "Tu Nombre"
   git config --global user.email "tu@email.com"
   ```

---

### 1.5 DBeaver *(opcional pero muy útil)*

**¿Para qué sirve?** Es un cliente visual de bases de datos. Te permite ver las tablas de PostgreSQL como si fuera Excel, sin escribir SQL a mano.

1. Ve a: **https://dbeaver.io/download/**
2. Descarga la versión **Community Edition** (gratis).
3. Instala con las opciones por defecto.

> Úsalo más adelante cuando tengas datos en la base de datos.

---

## Fase 2 — Servicios locales con Docker

**¿Qué vamos a levantar?** El proyecto usa 4 servicios que corren en contenedores Docker:

| Servicio | ¿Para qué sirve? | Puerto |
|---|---|---|
| **PostgreSQL** | Base de datos principal — guarda todos los datos | 5432 |
| **Redis** | Caché rápida — guarda tokens y datos temporales | 6379 |
| **RabbitMQ** | Cola de mensajes — para notificaciones y eventos | 5672 / 15672 |
| **Seq** | Visor de logs — para ver qué hace el backend en tiempo real | 8081 |

### 2.1 Levantar los servicios

1. Abre una terminal y navega al proyecto:
   ```powershell
   cd C:\Users\a0836618\source\repos\mine
   ```

2. Levanta todos los servicios con un solo comando:
   ```powershell
   docker compose -f src\infra\docker\docker-compose.yml up -d
   ```
   
   La primera vez descarga las imágenes (tarda unos minutos según la internet). Las siguientes veces arranca en segundos.

3. Verifica que todos quedaron corriendo:
   ```powershell
   docker compose -f src\infra\docker\docker-compose.yml ps
   ```
   Todos deben aparecer con estado **running**.

### 2.2 Verificar cada servicio

**PostgreSQL** — conéctate con DBeaver:
- Host: `localhost`
- Port: `5432`
- Database: `personalhub`
- Username: `personalhub`
- Password: `personalhub_dev`

**RabbitMQ** — abre en el navegador:
- URL: http://localhost:15672
- Usuario: `personalhub`
- Contraseña: `personalhub_dev`
- Debes ver el panel de administración de RabbitMQ.

**Seq** (visor de logs) — abre en el navegador:
- URL: http://localhost:8081
- No requiere login. Debes ver la interfaz de Seq vacía.

### 2.3 Comandos útiles del día a día

```powershell
# Encender todos los servicios (al empezar el día)
docker compose -f src\infra\docker\docker-compose.yml up -d

# Apagar todos los servicios (al terminar el día)
docker compose -f src\infra\docker\docker-compose.yml down

# Ver los logs de un servicio específico
docker compose -f src\infra\docker\docker-compose.yml logs postgres
docker compose -f src\infra\docker\docker-compose.yml logs rabbitmq

# Reiniciar un servicio específico
docker compose -f src\infra\docker\docker-compose.yml restart redis

# Borrar todo (base de datos incluida) ← ⚠️ cuidado, borra los datos
docker compose -f src\infra\docker\docker-compose.yml down -v
```

---

## Fase 3 — Emulador Android para pruebas móviles

**¿Cuándo lo necesitas?** Cuando quieras ver la app corriendo en un dispositivo virtual. Para el Sprint 1 puedes omitir esto y probar solo el backend.

**Opción A — Usar tu celular físico (más fácil):**

1. En tu celular Android, ve a **Ajustes → Acerca del teléfono**.
2. Toca **Número de compilación** 7 veces seguidas. Esto activa el "Modo desarrollador".
3. Ve a **Ajustes → Opciones de desarrollador**.
4. Activa **Depuración USB**.
5. Conecta el celular al computador con un cable USB.
6. En el celular aparecerá un mensaje "¿Permitir depuración USB?" → toca **Aceptar**.
7. Desde Visual Studio, en el menú de dispositivos debe aparecer tu celular.

**Opción B — Emulador virtual (Android Studio):**

1. Ve a: **https://developer.android.com/studio**
2. Descarga e instala Android Studio.
3. Abre Android Studio → menú **Tools → Device Manager**.
4. Clic en **Create Device**.
5. Selecciona un dispositivo (ej. Pixel 8).
6. Selecciona una imagen de sistema (ej. Android 14 — API 34). Descárgala si no la tienes.
7. Finaliza y el emulador quedará disponible.
8. Desde Visual Studio, selecciona ese emulador como dispositivo de destino.

> **Requisito del emulador:** tu computador necesita tener virtualización habilitada en la BIOS. Si el emulador no inicia, busca "Habilitar virtualización en BIOS [marca de tu computador]".

---

## Fase 4 — Firebase (notificaciones push)

**¿Cuándo lo necesitas?** En el Sprint 8, cuando implementes los recordatorios y alertas. Por ahora no es necesario.

### 4.1 Crear el proyecto en Firebase

1. Ve a: **https://console.firebase.google.com/**
2. Inicia sesión con tu cuenta de Google.
3. Clic en **Agregar proyecto**.
4. Nombre del proyecto: `personalhub-app`.
5. Desactiva Google Analytics (no es necesario por ahora).
6. Clic en **Crear proyecto**.

### 4.2 Configurar para Android

1. En el panel de Firebase, clic en el ícono de Android.
2. Package name: `com.personalhub.app` (este debe coincidir con el de la app MAUI).
3. Descarga el archivo `google-services.json`.
4. Copia ese archivo a: `src/mobile/PersonalHub.Mobile/Platforms/Android/`.

### 4.3 Obtener la clave del servidor (para el backend)

1. En Firebase → tu proyecto → ⚙️ Configuración del proyecto → **Cloud Messaging**.
2. En "API de Cloud Messaging" encontrarás la **Server key** y el **Sender ID**.
3. Guárdalos como variables de entorno en el backend (nunca en el código).

---

## Fase 5 — Azure

**¿Cuándo lo necesitas?** Cuando tengas el Sprint 2 completo y quieras hacer el primer despliegue a un ambiente compartido (staging). No es necesario para desarrollar localmente.

### 5.1 Requisitos previos

- Una cuenta de Azure. Si no tienes: **https://azure.microsoft.com/free** — Microsoft da $200 USD de crédito gratuito por 30 días para cuentas nuevas.
- Una suscripción activa.

### 5.2 Instalar Azure CLI

**¿Para qué sirve?** Es la herramienta de línea de comandos para crear y gestionar recursos en Azure desde la terminal.

```powershell
# Instalar Azure CLI en Windows
winget install -e --id Microsoft.AzureCLI

# Verificar instalación
az --version

# Iniciar sesión (abrirá el navegador)
az login
```

### 5.3 Instalar kubectl

**¿Para qué sirve?** Es la herramienta para hablar con Kubernetes (el orquestador de contenedores en AKS).

```powershell
# Instalar kubectl
az aks install-cli

# Verificar
kubectl version --client
```

### 5.4 Instalar Helm

**¿Para qué sirve?** Es el gestor de paquetes de Kubernetes. Usamos Helm para desplegar la app en AKS.

```powershell
# Instalar Helm con winget
winget install -e --id Helm.Helm

# Verificar
helm version
```

### 5.5 Crear los recursos en Azure

Ejecuta estos comandos en orden. Cada uno crea un recurso en Azure:

```powershell
# 1. Variables (cambia los nombres si quieres)
$RESOURCE_GROUP = "rg-personalhub-dev"
$LOCATION       = "eastus2"
$ACR_NAME       = "acrpersonalhub"        # debe ser único a nivel global
$AKS_NAME       = "aks-personalhub-dev"
$PG_SERVER      = "pg-personalhub-dev"    # debe ser único a nivel global
$REDIS_NAME     = "redis-personalhub-dev" # debe ser único a nivel global
$KV_NAME        = "kv-personalhub-dev"    # debe ser único a nivel global

# 2. Crear el grupo de recursos (es la "carpeta" donde van todos los recursos)
az group create --name $RESOURCE_GROUP --location $LOCATION

# 3. Crear Azure Container Registry (guarda las imágenes Docker)
az acr create `
  --resource-group $RESOURCE_GROUP `
  --name $ACR_NAME `
  --sku Basic `
  --admin-enabled true

# 4. Crear el clúster AKS con 1 nodo (suficiente para dev/staging)
az aks create `
  --resource-group $RESOURCE_GROUP `
  --name $AKS_NAME `
  --node-count 1 `
  --node-vm-size Standard_B2s `
  --attach-acr $ACR_NAME `
  --generate-ssh-keys

# 5. Conectar kubectl a tu clúster AKS
az aks get-credentials --resource-group $RESOURCE_GROUP --name $AKS_NAME

# Verificar conexión
kubectl get nodes
# Debe mostrar 1 nodo con estado Ready

# 6. Crear PostgreSQL Flexible Server
az postgres flexible-server create `
  --resource-group $RESOURCE_GROUP `
  --name $PG_SERVER `
  --location $LOCATION `
  --admin-user personalhub `
  --admin-password "PersonalHub2026!" `
  --sku-name Standard_B1ms `
  --tier Burstable `
  --storage-size 32 `
  --version 16 `
  --public-access 0.0.0.0

# 7. Crear Redis Cache
az redis create `
  --resource-group $RESOURCE_GROUP `
  --name $REDIS_NAME `
  --location $LOCATION `
  --sku Basic `
  --vm-size c0

# 8. Crear Key Vault (para guardar secretos de forma segura)
az keyvault create `
  --resource-group $RESOURCE_GROUP `
  --name $KV_NAME `
  --location $LOCATION

Write-Host "✅ Todos los recursos de Azure creados correctamente"
```

> ⚠️ **Costo estimado del ambiente dev:** ~$80–120 USD/mes con estos recursos. Para minimizar costos, apaga el clúster AKS cuando no lo uses:
> ```powershell
> az aks stop  --resource-group $RESOURCE_GROUP --name $AKS_NAME
> az aks start --resource-group $RESOURCE_GROUP --name $AKS_NAME
> ```

### 5.6 Guardar los secretos en Key Vault

Después de crear los recursos, guarda sus credenciales en Key Vault:

```powershell
# Obtener el connection string de PostgreSQL
$PG_CONN = "Host=$PG_SERVER.postgres.database.azure.com;Database=personalhub;Username=personalhub;Password=PersonalHub2026!"

# Obtener el connection string de Redis
$REDIS_KEY = $(az redis list-keys --resource-group $RESOURCE_GROUP --name $REDIS_NAME --query primaryKey -o tsv)
$REDIS_CONN = "$REDIS_NAME.redis.cache.windows.net:6380,password=$REDIS_KEY,ssl=True"

# Guardar en Key Vault
az keyvault secret set --vault-name $KV_NAME --name "ConnectionStrings--PostgreSQL" --value $PG_CONN
az keyvault secret set --vault-name $KV_NAME --name "ConnectionStrings--Redis"      --value $REDIS_CONN

Write-Host "✅ Secretos guardados en Key Vault"
```

---

## Fase 6 — CI/CD con GitHub Actions

**¿Cuándo lo necesitas?** Cuando quieras que cada push al repositorio construya y despliegue la app automáticamente. Se configura después de tener Azure listo.

### 6.1 Crear repositorio en GitHub

1. Ve a **https://github.com/new**
2. Nombre: `personalhub`
3. Privado o público (tu elección).
4. NO inicialices con README (ya tenemos uno).
5. Crea el repositorio.

### 6.2 Conectar el repositorio local con GitHub

```powershell
cd C:\Users\a0836618\source\repos\mine

# Agregar el remote (reemplaza TU_USUARIO con tu usuario de GitHub)
git remote add origin https://github.com/TU_USUARIO/personalhub.git

# Empujar todo el historial
git push -u origin master
```

### 6.3 Guardar secretos en GitHub

GitHub Actions necesita las credenciales de Azure para desplegar. Ve a tu repositorio en GitHub → **Settings → Secrets and variables → Actions → New repository secret** y agrega:

| Nombre del secreto | Cómo obtener el valor |
|---|---|
| `AZURE_CREDENTIALS` | Ver paso 6.4 |
| `ACR_LOGIN_SERVER` | `az acr show --name $ACR_NAME --query loginServer -o tsv` |
| `ACR_USERNAME` | `az acr credential show --name $ACR_NAME --query username -o tsv` |
| `ACR_PASSWORD` | `az acr credential show --name $ACR_NAME --query passwords[0].value -o tsv` |
| `AKS_RESOURCE_GROUP` | `rg-personalhub-dev` |
| `AKS_CLUSTER_NAME` | `aks-personalhub-dev` |

### 6.4 Crear las credenciales de Azure para GitHub Actions

```powershell
# Obtener el ID de tu suscripción
$SUBSCRIPTION_ID = $(az account show --query id -o tsv)

# Crear un Service Principal con permisos de Contributor
az ad sp create-for-rbac `
  --name "github-actions-personalhub" `
  --role Contributor `
  --scopes "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP" `
  --sdk-auth
```

El resultado es un JSON. Cópialo completo y agrégalo como el secreto `AZURE_CREDENTIALS` en GitHub.

---

## Resumen — ¿Qué necesito para cada momento?

```
HOY — Sprint 1 (codificar backend + sync):
  ✅ .NET 10 SDK          (ya instalado)
  ✅ Git                  (ya instalado)
  ✅ MAUI workloads       (ya instalados)
  🔲 Docker Desktop       (instalar — Fase 1.2)
  🔲 Servicios Docker     (levantar — Fase 2)
  🔲 VS Code / VS 2022    (verificar / instalar — Fase 1.3)

PRÓXIMAS SEMANAS — probar app móvil:
  🔲 Android emulador o celular físico  (Fase 3)

SPRINT 8 — notificaciones push:
  🔲 Proyecto Firebase + google-services.json  (Fase 4)

CUANDO QUIERAS DESPLEGAR — primer deploy a staging:
  🔲 Azure CLI            (Fase 5.2)
  🔲 kubectl              (Fase 5.3)
  🔲 Helm                 (Fase 5.4)
  🔲 Recursos Azure       (Fase 5.5)

AUTOMATIZAR DESPLIEGUES — CI/CD:
  🔲 Repositorio GitHub   (Fase 6.1)
  🔲 GitHub Actions       (Fase 6.3)
```

---

## Checklist de verificación — "Listo para Sprint 1"

Ejecuta esto para confirmar que todo está en orden:

```powershell
# Desde la raíz del proyecto
cd C:\Users\a0836618\source\repos\mine

Write-Host "--- Verificando herramientas ---"
dotnet --version
docker --version
git --version

Write-Host "`n--- Levantando servicios ---"
docker compose -f src\infra\docker\docker-compose.yml up -d

Write-Host "`n--- Verificando servicios ---"
docker compose -f src\infra\docker\docker-compose.yml ps

Write-Host "`n--- Verificando build del proyecto ---"
dotnet build PersonalHub.slnx -v quiet

Write-Host "`n✅ Si no hay errores arriba, estás listo para empezar el Sprint 1"
```

Abre también en el navegador:
- http://localhost:15672 → RabbitMQ (usuario: `personalhub` / `personalhub_dev`)
- http://localhost:8081  → Seq (logs)
