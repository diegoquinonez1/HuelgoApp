# ADR-0004: Autenticación con OpenIddict y OIDC

- Estado: Aceptado
- Fecha: 2026-08-12

## Contexto

La aplicación maneja información financiera y personal. Cada usuario debe tener una sesión persistente y acceso aislado a sus propios datos.

## Decisión

Implementar autenticación basada en OAuth 2.0 / OpenID Connect con OpenIddict. La API validará tokens de acceso y aplicará autorización por usuario en cada recurso protegido.

## Alternativas consideradas

- Autenticación propia basada en tokens no estándar: descartada por riesgo de seguridad y mantenimiento.
- Proveedor externo obligatorio: descartado para mantener control sobre la identidad en el MVP.

## Consecuencias

Se obtiene un protocolo estándar y una base para incorporar social login posteriormente. Deben documentarse rotación, expiración y revocación de tokens, almacenamiento seguro en el dispositivo y recuperación de cuenta.
