# Guía para Registrar y Organizar el Backlog en GitHub

> **Objetivo:** dejar en GitHub todas las historias de usuario, épicas, sprints, prioridades y criterios de aceptación del proyecto PersonalHub.
> **Audiencia:** alguien que nunca ha organizado un backlog en GitHub.
> **Resultado esperado:** al final tendrás un tablero GitHub Projects con el backlog completo, 42 historias, 9 sprints, labels, milestones y una forma clara de trabajar.

---

## 1. Qué vamos a crear en GitHub

Vas a organizar el trabajo con 4 piezas:

1. **Issues**
Cada historia de usuario será un Issue en GitHub.

2. **Labels**
Sirven para clasificar cada historia por tipo, alcance, prioridad, estado y sprint.

3. **Milestones**
Cada sprint será un Milestone.

4. **GitHub Project**
Será el tablero visual donde mueves historias entre columnas como `Backlog`, `Ready`, `In Progress`, `Done`.

---

## 2. Estructura recomendada

### 2.1 Un Issue por historia de usuario

Cada una de las 42 historias se registra como un Issue individual.

**Formato recomendado del título:**

```text
[HU-A1-001] Registro de cuenta
[HU-A1-009] Registrar una transacción
[HU-A2-001] Crear una tarea rápidamente
```

Esto permite:
- buscar rápido por ID
- ordenar naturalmente
- relacionar código, PRs y documentación

---

### 2.2 Qué NO debes hacer

No mezcles varias historias en un solo issue.

No uses un issue gigante tipo:
- `Módulo de presupuesto`
- `Todas las tareas del Sprint 1`

Eso rompe la trazabilidad y hace más difícil medir avance real.

---

## 3. Labels recomendados

Crea exactamente estas categorías de labels.

### 3.1 Tipo

| Label | Uso |
|---|---|
| `type:user-story` | Historia de usuario |
| `type:epic` | Épica |
| `type:task` | Tarea técnica derivada |
| `type:bug` | Error encontrado |
| `type:spike` | Investigación técnica o funcional |

### 3.2 Alcance

| Label | Uso |
|---|---|
| `scope:alcance-1` | Presupuesto |
| `scope:alcance-2` | Tareas |

### 3.3 Prioridad

| Label | Uso |
|---|---|
| `priority:must-have` | Imprescindible |
| `priority:should-have` | Importante |
| `priority:could-have` | Deseable |

### 3.4 Estado

| Label | Uso |
|---|---|
| `status:todo` | Aún no trabajada |
| `status:ready` | Lista para desarrollo |
| `status:in-progress` | En desarrollo |
| `status:blocked` | Bloqueada |
| `status:done` | Terminada |

### 3.5 Sprint

| Label | Uso |
|---|---|
| `sprint:1` | Sprint 1 |
| `sprint:2` | Sprint 2 |
| `sprint:3` | Sprint 3 |
| `sprint:4` | Sprint 4 |
| `sprint:5` | Sprint 5 |
| `sprint:6` | Sprint 6 |
| `sprint:7` | Sprint 7 |
| `sprint:8` | Sprint 8 |
| `sprint:9` | Sprint 9 |

### 3.6 Área funcional

| Label | Uso |
|---|---|
| `area:identity` | Login, registro, sesión |
| `area:dashboard` | Dashboard |
| `area:budget` | Transacciones, categorías, presupuesto |
| `area:sync` | Offline y sincronización |
| `area:tasks` | Tareas |
| `area:notifications` | Alertas, recordatorios |
| `area:reports` | Gráficas, exportación |

---

## 4. Milestones recomendados

Crea estos milestones en GitHub. Cada uno representa un sprint.

| Milestone | Fecha sugerida | Objetivo |
|---|---|---|
| `Sprint 1 - Auth + Offline` | +2 semanas | Registro, login, logout, offline-first |
| `Sprint 2 - Dashboard + CRUD Transacciones` | +4 semanas | Flujo principal de presupuesto |
| `Sprint 3 - Lista, Filtros y Categorías` | +6 semanas | Navegación y clasificación |
| `Sprint 4 - Presupuesto y Alertas` | +8 semanas | Metas y notificaciones |
| `Sprint 5 - Recurrentes + Gráficas` | +10 semanas | Gastos fijos y visualización |
| `Sprint 6 - Reportes + Monedas` | +12 semanas | Cierre de Alcance 1 |
| `Sprint 7 - Tareas Núcleo` | +14 semanas | CRUD de tareas |
| `Sprint 8 - Subtareas + Recordatorios` | +16 semanas | Profundidad funcional de tareas |
| `Sprint 9 - Calendario + Personalización` | +18 semanas | Cierre de Alcance 2 |

> Si no quieres usar fechas todavía, puedes crearlos sin due date. No pasa nada.

---

## 5. GitHub Project recomendado

Crea un **GitHub Project** tipo tablero con estas columnas:

1. `Backlog`
2. `Ready`
3. `In Progress`
4. `In Review`
5. `Done`

### Campos personalizados recomendados dentro del Project

Si usas **GitHub Projects (new)**, agrega estos campos:

| Campo | Tipo | Valores |
|---|---|---|
| `Story Points` | Number | 1, 2, 3, 5, 8, 13 |
| `Priority` | Single Select | Must Have, Should Have, Could Have |
| `Scope` | Single Select | Alcance 1, Alcance 2 |
| `Sprint` | Single Select | Sprint 1 ... Sprint 9 |
| `Epic` | Text | Nombre de la épica |

Esto te permite ver carga por sprint, puntos y prioridad sin depender solo de labels.

---

## 6. Orden ideal para cargar todo en GitHub

Hazlo exactamente en este orden para no enredarte:

### Paso 1 — Crear el repositorio en GitHub

Si aún no existe:

1. Ve a https://github.com/new
2. Nombre sugerido: `personalhub`
3. Tipo: privado o público
4. No agregues README nuevo
5. Crea el repositorio

### Paso 2 — Subir el repo local

```powershell
cd C:\Users\a0836618\source\repos\mine
git remote add origin https://github.com/TU_USUARIO/personalhub.git
git push -u origin master
```

### Paso 3 — Crear labels

Hazlo antes de crear issues.

### Paso 4 — Crear milestones

Hazlo antes de asignar las historias.

### Paso 5 — Crear el Project

Y deja las columnas listas.

### Paso 6 — Crear las épicas como issues

Recomendación: crear primero 15 épicas, una por cada bloque ya definido.

### Paso 7 — Crear las 42 historias

Cada historia con:
- título con ID
- descripción completa
- criterios de aceptación
- labels
- milestone
- referencia a la épica

### Paso 8 — Mover cada historia al Project

Todas arrancan en `Backlog` o `Ready`.

---

## 7. Cómo registrar las épicas

Crea un issue por épica con título así:

```text
[EPIC-A1-01] Autenticación y Cuenta
[EPIC-A1-02] Dashboard
[EPIC-A1-03] Transacciones
...
[EPIC-A2-15] Relación Tareas — Presupuesto
```

**Contenido mínimo del issue de épica:**
- objetivo del bloque
- alcance funcional
- historias relacionadas
- criterio general de éxito

**Ejemplo corto:**

```md
## Objetivo
Permitir que el usuario se registre, inicie sesión y cierre sesión de forma segura.

## Historias relacionadas
- HU-A1-001 Registro de cuenta
- HU-A1-002 Inicio de sesión
- HU-A1-003 Recuperación de contraseña
- HU-A1-004 Cierre de sesión

## Criterio de éxito
Un usuario puede crear su cuenta, autenticarse, recuperar acceso y cerrar sesión sin perder privacidad.
```

---

## 8. Cómo registrar una historia de usuario correctamente

Usa esta estructura exacta dentro del issue:

```md
## Identificación
- ID: HU-A1-001
- Alcance: Alcance 1
- Épica: Autenticación y Cuenta
- Sprint objetivo: Sprint 1
- Prioridad: Must Have
- Story points: 3

## Historia
Como usuario nuevo,
quiero registrarme con mi nombre, apellido, fecha de nacimiento, email y contraseña,
para tener una cuenta personal y privada donde guardar mis datos financieros.

## Criterios de aceptación
- [ ] El formulario tiene campos: nombre(s), apellido(s), fecha de nacimiento, email, contraseña, confirmar contraseña.
- [ ] El email debe tener formato válido y no estar registrado previamente.
- [ ] La contraseña debe tener mínimo 8 caracteres.
- [ ] La confirmación de contraseña debe coincidir.
- [ ] Al registrarse exitosamente, el usuario queda autenticado y va al Dashboard.
- [ ] Si el email ya existe, se muestra un mensaje claro sin revelar datos de otros usuarios.
- [ ] La fecha de nacimiento es obligatoria y el usuario debe ser mayor de edad (≥ 13 años).

## Dependencias
- Ninguna

## Referencias
- docs/REQUIREMENT.md
- docs/WIREFRAMES.md
- docs/USER_STORIES.md
```

---

## 9. Cómo relacionar historias con épicas

GitHub no trae jerarquía de épica/historia tan fuerte como Jira, así que usa una de estas dos estrategias:

### Opción recomendada — Issue links manuales

Dentro de cada épica, agrega la lista de historias relacionadas.

Dentro de cada historia, agrega una línea así:

```md
## Épica padre
- #12
```

Donde `#12` sería el issue de la épica.

### Opción alternativa — solo con labels

Pones el label del área y el campo `Epic` dentro del Project.

Sirve, pero es menos explícito.

---

## 10. Cómo organizar el tablero en el día a día

### Flujo simple recomendado

- `Backlog` → idea definida pero no preparada para arrancar
- `Ready` → tiene criterios claros, sin dudas y se puede desarrollar
- `In Progress` → alguien la está trabajando
- `In Review` → ya hay PR o revisión funcional/técnica
- `Done` → terminada y validada

### Regla práctica

Una historia solo pasa a `Ready` si:
- tiene criterios de aceptación completos
- tiene sprint asignado
- tiene story points
- tiene dependencia resuelta o clara

---

## 11. Cómo repartir todas las historias por sprint

Esta es la distribución recomendada para registrar tal cual en GitHub.

### Sprint 1
- HU-A1-001
- HU-A1-002
- HU-A1-004
- HU-A1-026

### Sprint 2
- HU-A1-005
- HU-A1-006
- HU-A1-009
- HU-A1-010
- HU-A1-011

### Sprint 3
- HU-A1-012
- HU-A1-013
- HU-A1-014
- HU-A1-015
- HU-A1-003
- HU-A1-007

### Sprint 4
- HU-A1-016
- HU-A1-017
- HU-A1-018
- HU-A1-008

### Sprint 5
- HU-A1-019
- HU-A1-020
- HU-A1-021
- HU-A1-023

### Sprint 6
- HU-A1-024
- HU-A1-025
- HU-A1-022

### Sprint 7
- HU-A2-001
- HU-A2-002
- HU-A2-003
- HU-A2-004
- HU-A2-005
- HU-A2-006

### Sprint 8
- HU-A2-007
- HU-A2-008
- HU-A2-009
- HU-A2-011
- HU-A2-012
- HU-A2-016

### Sprint 9
- HU-A2-013
- HU-A2-014
- HU-A2-015
- HU-A2-010

---

## 12. Cómo cargarlo rápido sin volverte loco

Tienes dos caminos.

### Opción A — Manual desde la UI de GitHub

Úsala si quieres control total y no te importa tardar 1 o 2 horas.

**Proceso recomendado:**
1. Crea labels
2. Crea milestones
3. Crea épicas
4. Crea historias sprint por sprint
5. Mete todo al Project

### Opción B — Semi-automático con GitHub CLI

Úsala si quieres rapidez. Para eso:
1. instala GitHub CLI (`gh`)
2. autentícate con `gh auth login`
3. usa el script que te dejo en este repo

---

## 13. Recomendación final de orden práctico

Si yo lo estuviera haciendo para no perder tiempo, seguiría este orden exacto:

1. Crear el repo en GitHub
2. Hacer `git push`
3. Crear labels
4. Crear milestones
5. Crear el Project
6. Crear las 15 épicas
7. Crear solo las historias del Sprint 1 y Sprint 2 primero
8. Dejar Sprint 3–9 en backlog
9. Cuando Sprint 1 arranque, mover solo esas historias a `Ready`

**Razón:** puedes registrar todo desde ya, pero no necesitas preparar operativamente los 9 sprints con el mismo nivel de detalle visual desde el día 1.

---

## 14. Qué queda mejor registrado en GitHub y qué no

### En GitHub sí
- historias de usuario
- épicas
- bugs
- tareas técnicas
- sprints
- estados
- prioridades
- PRs y trazabilidad

### En documentos del repo
- requerimiento macro
- wireframes
- arquitectura
- notas largas o decisiones de negocio

GitHub debe ser el **tablero vivo**.
Los `.md` del repo deben ser la **fuente documental**.

---

## 15. Resultado final ideal

Al terminar, GitHub debe mostrar:

- 15 épicas
- 42 historias de usuario
- 9 milestones
- 1 project board
- labels consistentes
- backlog ordenado por sprint
- trazabilidad hacia `docs/REQUIREMENT.md`, `docs/WIREFRAMES.md` y `docs/USER_STORIES.md`

Eso te deja listo para empezar desarrollo sin improvisación.
