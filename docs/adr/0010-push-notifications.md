# ADR-0010: Notificaciones push mediante FCM

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

El producto debe avisar sobre umbrales de presupuesto, transacciones recurrentes y recordatorios de tareas en Android e iOS.

## Decisión

Usar Firebase Cloud Messaging como proveedor de notificaciones push. El módulo Notifications consumirá eventos del backend, aplicará preferencias del usuario y enviará mensajes a los tokens registrados por dispositivo.

## Alternativas consideradas

- Notificaciones locales únicamente: descartadas porque no cubren alertas generadas por el servidor.
- Implementaciones independientes por plataforma: descartadas por duplicación y mayor complejidad operativa.
- Servicio de notificaciones específico de Azure: descartado para mantener el proveedor desacoplado del backend.

## Consecuencias

Se obtiene una integración multiplataforma conocida. Deben gestionarse tokens expirados, permisos, preferencias, reintentos, deduplicación y la exclusión de datos financieros sensibles del contenido visible de la notificación.
