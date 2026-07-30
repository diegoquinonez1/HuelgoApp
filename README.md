# PersonalHub

> App móvil multiplataforma para gestión de presupuesto personal y tareas.
> Frontend en .NET MAUI — Backend modular en ASP.NET Core 9 — Desplegado en Azure.

## Estructura del Repositorio

```
PersonalHub/
├── src/
│   ├── mobile/
│   │   └── PersonalHub.Mobile/          # MAUI (Android + iOS)
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

## Documentación

- [Requerimiento de Producto](docs/REQUIREMENT.md)
- [Wireframes](docs/WIREFRAMES.md)
- [Architecture Decision Records](docs/adr/)
