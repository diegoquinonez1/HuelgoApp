# ADR-0006: PostgreSQL como persistencia principal

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

Los módulos de identidad, presupuesto, tareas y sincronización requieren persistencia transaccional, consultas relacionales y soporte para crecimiento.

## Decisión

Usar PostgreSQL 16 con Entity Framework Core 9 y migraciones code-first. Cada módulo será propietario de sus tablas y usará un esquema separado dentro de la base de datos compartida inicialmente.

## Alternativas consideradas

- Una base de datos por módulo desde el primer día: reservada para cuando el aislamiento operativo lo justifique.
- MongoDB: descartado porque el dominio requiere consistencia relacional y consultas agregadas.

## Consecuencias

Se obtiene consistencia ACID y portabilidad. Deben controlarse las migraciones, índices, retención de datos y la prohibición de acceder directamente a tablas propiedad de otro módulo.
