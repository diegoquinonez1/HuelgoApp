# ADR-0009: Contenedores, Kubernetes y definición de infraestructura

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

La aplicación debe ejecutarse de forma consistente en desarrollo, pruebas y producción, con capacidad de escalar horizontalmente y Azure como destino inicial.

## Decisión

Usar Docker y Docker Compose para desarrollo local. Desplegar la aplicación en Kubernetes mediante Helm. Provisionar recursos de Azure con Bicep, manteniendo la configuración de la aplicación independiente del proveedor.

## Alternativas consideradas

- Ejecutar directamente sobre máquinas virtuales: descartado por menor reproducibilidad y automatización.
- Acoplar la aplicación a servicios específicos de Azure: descartado para conservar portabilidad.

## Consecuencias

Se obtiene una ruta clara hacia despliegues reproducibles y escalables. Aumenta la responsabilidad operativa sobre secretos, health checks, configuración, actualizaciones, costos y seguridad del clúster.
