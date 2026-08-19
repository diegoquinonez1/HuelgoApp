# ADR-0007: Redis para caché y RabbitMQ con MassTransit para eventos

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

La solución necesita escalar horizontalmente, reducir lecturas repetidas y desacoplar procesos como alertas, notificaciones y sincronización.

## Decisión

Usar Redis para caché distribuida y datos efímeros. Usar RabbitMQ como broker y MassTransit como abstracción de mensajería para eventos de dominio y procesos asíncronos entre módulos.

## Alternativas consideradas

- Comunicación síncrona entre todos los módulos: descartada porque aumenta el acoplamiento y la latencia.
- Broker propietario: descartado para preservar portabilidad.
- Memoria local como caché: descartada porque no funciona de forma consistente entre instancias.

## Consecuencias

Se facilita la escalabilidad y el procesamiento asíncrono. Deben definirse contratos versionados, reintentos, idempotencia, colas de mensajes fallidos y políticas de expiración de caché.
