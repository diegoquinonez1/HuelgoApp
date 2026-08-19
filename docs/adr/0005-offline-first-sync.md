# ADR-0005: Estrategia offline-first y sincronización delta

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

La app debe permitir leer y modificar datos sin conexión y sincronizar automáticamente al recuperar la red.

## Decisión

Usar SQLite local como fuente operativa de la aplicación móvil. Registrar cambios localmente y sincronizar deltas con el servidor usando marcas de tiempo, identificadores estables y estados de sincronización. Para conflictos del MVP se aplicará último cambio válido gana, dejando trazabilidad del cambio sincronizado.

## Alternativas consideradas

- Funcionamiento únicamente online: descartado porque incumple RNF-04.
- Sincronizar el conjunto completo de datos: descartado por consumo de red y menor escalabilidad.
- Resolución manual de todos los conflictos: reservada para una evolución posterior por su mayor complejidad de UX.

## Consecuencias

La experiencia mejora en redes inestables, pero aumenta la complejidad de identidad de registros, reintentos, borrados y conflictos. La estrategia debe cubrir idempotencia, paginación, reloj del servidor y migraciones locales.
