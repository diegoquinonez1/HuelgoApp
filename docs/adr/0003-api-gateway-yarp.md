# ADR-0003: API Gateway con YARP

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

La aplicación móvil necesita un punto de entrada estable para acceder a los módulos del backend. También se requiere centralizar enrutamiento, políticas de acceso y controles de tráfico.

## Decisión

Usar YARP como API Gateway delante del backend modular. El Gateway será responsable del enrutamiento externo y de las políticas transversales; la lógica de negocio permanecerá dentro de los módulos.

## Alternativas consideradas

- Exponer cada módulo directamente: descartado porque multiplica los puntos públicos y acopla al cliente con la estructura interna.
- Gateway administrado específico de un proveedor: descartado para conservar portabilidad.

## Consecuencias

El cliente obtiene contratos y un punto de entrada estables. El Gateway se convierte en un componente crítico y debe incluir health checks, observabilidad, límites de tamaño y protección contra abuso.
