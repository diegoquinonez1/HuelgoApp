# Registro de problemas y respuestas

## Problema 1 — ¿Qué ADRs son necesarios construir como parte de la documentación?

### Traducción

Para este proyecto, ¿qué registros de decisiones de arquitectura (ADR por sus siglas en inglés) son necesarios documentar para que la solución quede bien sustentada y mantenible?

### Solución

Para este proyecto, lo recomendable es documentar un conjunto mínimo de ADRs que cubran las decisiones de arquitectura con mayor impacto técnico, riesgo y costo de cambio. No hace falta un ADR por cada módulo funcional; sí hace falta uno por cada decisión que condiciona el diseño del sistema.

#### ADRs mínimos recomendados

1. ADR-0001 — Uso de arquitectura modular monolítica con posibilidad de extracción futura
2. ADR-0002 — Uso de .NET MAUI como base para la app móvil multiplataforma
3. ADR-0003 — Uso de un API Gateway (YARP) y patrón de acceso centralizado
4. ADR-0004 — Autenticación y autorización con OpenIddict / OAuth2 / OIDC
5. ADR-0005 — Estrategia offline-first con SQLite y sincronización incremental
6. ADR-0006 — Persistencia principal en PostgreSQL y separación por módulo/esquema
7. ADR-0007 — Uso de Redis para caché y RabbitMQ/MassTransit para eventos y mensajería
8. ADR-0008 — Observabilidad con OpenTelemetry + Seq
9. ADR-0009 — Despliegue con Docker, Kubernetes y recursos de Azure mediante Bicep/Helm
10. ADR-0010 — Notificaciones push con FCM y arquitectura de eventos para alertas

#### Recomendación práctica

Si se quiere un conjunto mínimo viable para empezar, lo esencial sería:

- ADR-0001
- ADR-0003
- ADR-0004
- ADR-0005
- ADR-0006
- ADR-0007
- ADR-0009

La diferencia entre el grupo mínimo y el grupo completo es que los ADRs adicionales ayudan a dejar documentadas decisiones importantes para onboarding, operación y evolución del producto.

### Entendimiento

El proyecto tiene una arquitectura clara y con varios elementos que exigen decisiones de diseño explícitas:

- El frontend es una app móvil multiplataforma con MAUI.
- El backend está organizado en módulos y pensado como modular monolith.
- La app debe funcionar offline-first.
- Debe existir autenticación por usuario, aislamiento de datos y sesiones.
- Hay Gateway, base de datos, caché, mensajería y notificaciones.
- El despliegue está pensado para contenedores y Kubernetes, con Azure como infraestructura objetivo.

Todos esos puntos son decisiones arquitectónicas que cambian el comportamiento del sistema y condicionan futuras implementaciones. Por eso no basta con tener un README; se necesita un registro formal de por qué se eligió cada alternativa.

### Justificación

#### 1) ADR-0001 — Modular monolith

Es la decisión central del backend. Permite crear módulos bien definidos con separación de dominio y crecimiento futuro, sin entrar en la complejidad de microservicios desde el inicio.

#### 2) ADR-0002 — MAUI

La app requiere Android e iOS desde una sola base de código. Esta decisión evita duplicación de código y reduce costos de mantenimiento.

#### 3) ADR-0003 — API Gateway

Con YARP, se centraliza la entrada de tráfico, enrutamiento, seguridad y política de API. Esto simplifica la evolución de módulos y facilita control centralizado.

#### 4) ADR-0004 — OpenIddict / OIDC

La aplicación trata datos financieros y personales; la autenticación no es opcional. Documentar esto evita decisiones inconsistentes sobre sesiones, JWT, roles y protección de endpoints.

#### 5) ADR-0005 — Offline-first

Es un requisito no funcional clave. El sistema no funciona solo online; por eso se debe documentar la estrategia de persistencia local, sincronización incremental y resolución de conflictos.

#### 6) ADR-0006 — PostgreSQL

Es la base de datos principal y tiene impacto sobre relaciones, migraciones, performance y consistencia. Esta decisión debe quedar documentada.

#### 7) ADR-0007 — Redis + RabbitMQ/MassTransit

Estos componentes soportan caché, mensajería y eventos de dominio. Son decisiones clave para escalabilidad, asincronía y desacoplamiento entre módulos.

#### 8) ADR-0008 — Observabilidad

Con trazas, métricas y logs se puede operar correctamente la app en producción. Sin esta decisión, la solución será muy difícil de diagnosticar.

#### 9) ADR-0009 — Docker + Kubernetes + Bicep/Helm

El proyecto ya está orientado a infraestructura portable y Azure. Esta decisión permite desplegar repetidamente y mantener entornos consistentes.

#### 10) ADR-0010 — FCM para notificaciones

La app requiere alertas push para presupuestos, tareas y recordatorios. La elección del canal de notificación debe quedar explícita para no depender de una solución puntual sin justificación.

### Conclusión

Para este proyecto, el conjunto recomendable de ADRs es el siguiente:

- Mínimo necesario: 7 ADRs
- Recomendado para documentación completa: 10 ADRs

La regla práctica es: documentar todo lo que cambia el diseño, la operación o el costo de mantenimiento del sistema. En este caso, los ADRs más importantes son precisamente los que cubren modularidad, autenticación, offline-first, persistencia, mensajería, observabilidad y despliegue.

---

## Sugerencia de nombres de archivo para la carpeta docs/adr

- 0001-modular-monolith.md
- 0002-maui-mobile.md
- 0003-api-gateway-yarp.md
- 0004-authentication-openiddict.md
- 0005-offline-first-sync.md
- 0006-postgresql-persistence.md
- 0007-cache-messaging.md
- 0008-observability.md
- 0009-deploy-docker-kubernetes.md
- 0010-push-notifications.md

Esto permite mantener una documentación ordenada y escalable.
