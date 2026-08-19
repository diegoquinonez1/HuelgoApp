# ADR-0002: Aplicación móvil multiplataforma con .NET MAUI

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

El producto debe ofrecer paridad funcional en Android e iOS desde el primer lanzamiento, manteniendo una sola base de código principal.

## Decisión

Usar .NET MAUI 9 con C# y MVVM mediante CommunityToolkit.Mvvm. La navegación se implementará con Shell Navigation y la lógica de presentación permanecerá separada de la interfaz.

## Alternativas consideradas

- Aplicaciones nativas separadas: descartadas por duplicación de código y mayor costo de mantenimiento.
- Flutter o React Native: descartados para mantener el stack .NET de la solución.

## Consecuencias

Se comparte la mayor parte de la lógica entre plataformas. Se deben validar explícitamente las diferencias de ciclo de vida, permisos, almacenamiento y notificaciones de Android e iOS.
