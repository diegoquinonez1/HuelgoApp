# ADR-0001: Arquitectura modular monolítica

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

El backend debe soportar los módulos Identity, Budget, Tasks, Notifications y Sync, manteniendo límites claros y evitando la complejidad operativa inicial de una arquitectura de microservicios.

## Decisión

Adoptar un modular monolith en ASP.NET Core. Cada módulo tendrá su propio dominio, aplicación, infraestructura, API y contratos. La comunicación entre módulos será mediante interfaces internas o eventos, sin referencias directas a implementaciones de otros módulos.

## Alternativas consideradas

- Microservicios desde el inicio: descartado por el costo operativo y de despliegue para el MVP.
- Monolito sin modularidad: descartado porque dificulta el aislamiento de dominios y la evolución futura.

## Consecuencias

Se reduce la complejidad inicial y se conserva una ruta de extracción futura. Será necesario proteger los límites entre módulos mediante revisiones, pruebas y reglas de dependencias.
