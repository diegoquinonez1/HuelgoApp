# ADR-0008: Observabilidad con OpenTelemetry y Seq

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

El sistema combina app móvil, Gateway, módulos, base de datos, broker y servicios externos. Diagnosticar fallos sin trazas correlacionadas sería costoso.

## Decisión

Instrumentar backend y Gateway con OpenTelemetry para logs, métricas y trazas. Usar Seq como destino inicial de logs y conservar los estándares OTLP para poder cambiar de backend de observabilidad.

## Alternativas consideradas

- Solo logging textual: descartado porque no permite correlacionar una operación entre componentes.
- Dependencia directa de una plataforma de monitoreo propietaria: descartada para conservar portabilidad.

## Consecuencias

Se mejora el diagnóstico y la medición operativa. Deben definirse correlation IDs, datos sensibles que nunca se registran, retención, alertas y health checks.
