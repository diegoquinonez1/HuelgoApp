# Wireframes — Dashboard, Presupuesto y Tareas

> **Estado:** Baja fidelidad — para validación funcional, no visual
> **Plataforma:** Mobile (Android / iOS) — 390px de referencia
> **Última actualización:** 2026-07-30

---

## Convenciones

```
[ Botón ]          → elemento tappable / botón
[ Campo _______ ]  → campo de texto / input
( ● ) / ( ○ )      → radio button seleccionado / no seleccionado
[✓] / [ ]          → checkbox marcado / desmarcado
▓▓▓▓░░░░           → barra de progreso
▼                  → dropdown / selector
≡                  → menú hamburguesa
← →                → navegación entre períodos
```

---

## Pantallas

**Alcance 1 — Presupuesto**
1. [Login / Registro](#1-login--registro)
2. [Dashboard](#2-dashboard)
3. [Lista de Transacciones](#3-lista-de-transacciones)
4. [Agregar / Editar Transacción](#4-agregar--editar-transacción)
5. [Detalle de Transacción](#5-detalle-de-transacción)
6. [Presupuesto por Categorías](#6-presupuesto-por-categorías)
7. [Transacciones Recurrentes](#7-transacciones-recurrentes)
8. [Confirmar Recurrente](#8-confirmar-recurrente-notificación)
9. [Reportes y Gráficas](#9-reportes-y-gráficas)
10. [Exportar a Excel](#10-exportar-a-excel)

**Alcance 2 — Tareas**
11. [Lista de Tareas](#11-lista-de-tareas)
12. [Agregar / Editar Tarea](#12-agregar--editar-tarea)
13. [Detalle de Tarea](#13-detalle-de-tarea)
14. [Vista de Calendario](#14-vista-de-calendario)
15. [Configurar Recordatorio](#15-configurar-recordatorio)

---

## 1. Login / Registro

```
┌─────────────────────────────┐
│                             │
│                             │
│         [ LOGO APP ]        │
│    Gestión Personal         │
│                             │
│  ┌───────────────────────┐  │
│  │ Email _______________  │  │
│  └───────────────────────┘  │
│  ┌───────────────────────┐  │
│  │ Contraseña ___________│  │
│  └───────────────────────┘  │
│                             │
│      [ Ingresar       ]     │
│                             │
│  ¿Olvidaste tu contraseña?  │
│                             │
│  ─────────── o ───────────  │
│                             │
│      [ Crear cuenta   ]     │
│                             │
└─────────────────────────────┘
```

**Pantalla de Registro:**

```
┌─────────────────────────────┐
│  ←  Crear cuenta            │
├─────────────────────────────┤
│                             │
│  ┌───────────────────────┐  │
│  │ Nombre(s) ____________│  │
│  └───────────────────────┘  │
│  ┌───────────────────────┐  │
│  │ Apellido(s) __________│  │
│  └───────────────────────┘  │
│  Fecha de nacimiento        │
│  ┌───────────────────────┐  │
│  │ DD / MM / AAAA    ▼   │  │  ← usado en planes de ahorro futuros
│  └───────────────────────┘  │
│  ┌───────────────────────┐  │
│  │ Email ________________│  │
│  └───────────────────────┘  │
│  ┌───────────────────────┐  │
│  │ Contraseña ___________│  │
│  └───────────────────────┘  │
│  ┌───────────────────────┐  │
│  │ Confirmar contraseña _│  │
│  └───────────────────────┘  │
│                             │
│      [ Registrarme    ]     │
│                             │
└─────────────────────────────┘
```

---

## 2. Dashboard

```
┌─────────────────────────────┐
│  ≡   Mi Finanzas      🔔 👤 │  ← barra superior
├─────────────────────────────┤
│                             │
│   ← Julio 2026  ▼  →        │  ← selector de período
│                             │
│  ╔═════════════════════════╗ │
│  ║   BALANCE NETO          ║ │
│  ║   $ 1.250.000           ║ │  ← verde si positivo
│  ╚═════════════════════════╝ │
│                             │
│  ┌───────────┐ ┌───────────┐│
│  │ ↑ INGRESOS│ │ ↓ GASTOS  ││
│  │$4.500.000 │ │$3.250.000 ││
│  └───────────┘ └───────────┘│
│                             │
│  ─── Presupuesto del mes ───│
│                             │
│  Alimentación               │
│  ▓▓▓▓▓▓▓░░░  $280K/$400K   │  ← 70%
│                             │
│  Transporte                 │
│  ▓▓▓▓▓▓▓▓▓░  $180K/$200K   │  ← 90% ⚠️ alerta
│                             │
│  Vivienda                   │
│  ▓▓▓▓▓▓▓▓▓▓  $900K/$900K   │  ← 100% 🔴
│                             │
│  [ Ver todas las categorías ]│
│                             │
│  ─── Alertas ───────────────│
│  ⚠️  Arriendo vence en 3 días│
│  ⚠️  Transporte al 90%       │
│                             │
├─────────────────────────────┤
│  🏠      💰      ✅      ⚙️  │  ← barra navegación inferior
│ Inicio  Presup. Tareas  Config│
└─────────────────────────────┘
```

**Notas del Dashboard:**
- El balance neto cambia de color: verde (positivo), rojo (negativo), gris (cero).
- Las barras de presupuesto cambian de color: verde (<75%), naranja (75-99%), rojo (≥100%).
- El ícono 🔔 muestra el badge con conteo de alertas pendientes.
- Tapping en una barra de categoría navega directo al detalle de esa categoría.

---

## 3. Lista de Transacciones

```
┌─────────────────────────────┐
│  ←  Presupuesto      + 🔍  │  ← [ + ] abre formulario rápido
├─────────────────────────────┤
│                             │
│   ← Julio 2026  ▼  →        │
│                             │
│  [ Todos ▼ ] [ Tipo ▼ ] [ Categoría ▼ ]│  ← chips de filtro
│                             │
│  ─── Hoy, 30 Jul ───────────│
│  ┌─────────────────────────┐│
│  │ 🛒 Mercado              ││
│  │ Alimentación • Pagado   ││
│  │                -$85.000 ││  ← rojo
│  └─────────────────────────┘│
│  ┌─────────────────────────┐│
│  │ 💼 Sueldo               ││
│  │ Ingreso • Pagado        ││
│  │              +$4.500.000││  ← verde
│  └─────────────────────────┘│
│                             │
│  ─── Ayer, 29 Jul ──────────│
│  ┌─────────────────────────┐│
│  │ 🚌 Bus + Transmilenio   ││
│  │ Transporte • Pagado     ││
│  │                 -$5.800 ││
│  └─────────────────────────┘│
│  ┌─────────────────────────┐│
│  │ 🏠 Arriendo  🔁 recurrente│
│  │ Vivienda • Pendiente    ││  ← naranja si pendiente
│  │               -$900.000 ││
│  └─────────────────────────┘│
│                             │
│  ─── 28 Jul ────────────────│
│       ... más transacciones  │
│                             │
│           [ + Agregar ]      │  ← FAB / botón flotante
└─────────────────────────────┘
```

**Interacciones:**
- Swipe izquierdo sobre una transacción → opciones [ Editar ] [ Eliminar ].
- Tap sobre la transacción → abre detalle.
- Tap en [ + ] o FAB → abre formulario de nueva transacción.
- Los chips de filtro son acumulativos.

---

## 4. Agregar / Editar Transacción

> Este es el flujo más crítico del módulo — debe ser rápido y sin fricción.

```
┌─────────────────────────────┐
│  ✕  Nueva transacción       │  ← modal o pantalla
├─────────────────────────────┤
│                             │
│  ╔══════════╗ ╔══════════╗  │
│  ║  GASTO   ║ ║ INGRESO  ║  │  ← toggle prominente, primer campo
│  ╚══════════╝ ╚══════════╝  │
│                             │
│  ┌───────────────────────┐  │
│  │  $ 0                  │  │  ← teclado numérico se abre automático
│  └───────────────────────┘  │
│      teclado numérico        │
│   [ 1 ] [ 2 ] [ 3 ]         │
│   [ 4 ] [ 5 ] [ 6 ]         │
│   [ 7 ] [ 8 ] [ 9 ]         │
│   [  ] [ 0 ] [  ⌫ ]         │
│                             │
│  Categoría                  │
│  ┌───────────────────────┐  │
│  │ Seleccionar       ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Fecha          Estado       │
│  ┌──────────┐ ┌──────────┐  │
│  │ Hoy  ▼  │ │Pagado ▼  │  │
│  └──────────┘ └──────────┘  │
│                             │
│  Moneda                     │
│  ┌───────────────────────┐  │
│  │ COP - Pesos       ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Nota (opcional)            │
│  ┌───────────────────────┐  │
│  │ ______________________│  │
│  └───────────────────────┘  │
│                             │
│  [✓] Transacción recurrente │
│     (si está marcado ↓)     │
│  ┌───────────────────────┐  │
│  │ Frecuencia        ▼   │  │  ← aparece solo si es recurrente
│  └───────────────────────┘  │
│                             │
│      [ Guardar        ]     │
│                             │
└─────────────────────────────┘
```

**Notas del formulario:**
- Al abrir el formulario, el cursor está en el campo de monto y el teclado numérico se despliega de inmediato.
- El tipo Gasto/Ingreso es el primer elemento visual y el más grande.
- Los campos fecha y estado tienen valores por defecto sensatos (hoy / pagado) para minimizar toques.
- La sección recurrente solo se expande si el usuario activa el checkbox.
- El botón Guardar está siempre visible (no queda debajo del teclado).

**Selector de Categoría (modal):**
```
┌─────────────────────────────┐
│  Categoría           ✕      │
├─────────────────────────────┤
│  🔍 Buscar _______________  │
│                             │
│  ─── Del sistema ───────────│
│  🛒 Alimentación            │
│  🚌 Transporte              │
│  🏠 Vivienda                │
│  🏥 Salud                   │
│  📚 Educación               │
│  🎬 Entretenimiento         │
│  💼 Sueldo                  │
│  💻 Freelance               │
│  📦 Otros                   │
│                             │
│  ─── Mis categorías ────────│
│  ⭐ Mi categoría 1          │
│  ⭐ Mi categoría 2          │
│                             │
│  [ + Crear nueva categoría ]│
└─────────────────────────────┘
```

---

## 5. Detalle de Transacción

```
┌─────────────────────────────┐
│  ←  Detalle            ✏️ 🗑│  ← editar / eliminar
├─────────────────────────────┤
│                             │
│         🛒                  │
│      Mercado                │
│      -$85.000               │  ← grande, color rojo (gasto)
│                             │
│  ─────────────────────────  │
│  Tipo         Gasto         │
│  Categoría    Alimentación  │
│  Fecha        30 Jul 2026   │
│  Estado       Pagado        │
│  Moneda       COP           │
│  Recurrente   No            │
│  Nota         Mercado del   │
│               fin de semana │
│  ─────────────────────────  │
│                             │
│  Registrada el 30/07/2026   │
│  a las 10:32 AM             │
│                             │
└─────────────────────────────┘
```

---

## 6. Presupuesto por Categorías

```
┌─────────────────────────────┐
│  ←  Presupuesto       + ✏️  │  ← [ + ] agrega meta, ✏️ edita metas
├─────────────────────────────┤
│                             │
│   ← Julio 2026  ▼  →        │
│                             │
│  Total gastado / meta total │
│  ▓▓▓▓▓▓▓░░░  $3.250K/$4.5M  │
│                             │
│  ─────────────────────────  │
│                             │
│  🛒 Alimentación            │
│  $280.000 de $400.000        │
│  ▓▓▓▓▓▓▓░░░░  70%           │  ← verde
│  Alertar al [ 80% ▼ ]       │
│                             │
│  🚌 Transporte              │
│  $180.000 de $200.000        │
│  ▓▓▓▓▓▓▓▓▓░  90%  ⚠️        │  ← naranja + alerta
│  Alertar al [ 80% ▼ ]       │
│                             │
│  🏠 Vivienda                │
│  $900.000 de $900.000        │
│  ▓▓▓▓▓▓▓▓▓▓  100%  🔴       │  ← rojo
│  Alertar al [ 80% ▼ ]       │
│                             │
│  🎬 Entretenimiento         │
│  $120.000 de $150.000        │
│  ▓▓▓▓▓▓▓▓░░  80%  ⚠️        │
│  Alertar al [ 75% ▼ ]       │
│                             │
│  💼 Sueldo (ingreso)        │
│  Ingresado: $4.500.000      │
│  Meta: $4.500.000  ✅        │
│                             │
└─────────────────────────────┘
```

**Modal: Configurar meta de categoría:**
```
┌─────────────────────────────┐
│  Alimentación         ✕     │
├─────────────────────────────┤
│                             │
│  Meta de gasto mensual      │
│  ┌───────────────────────┐  │
│  │ $ 400.000             │  │
│  └───────────────────────┘  │
│                             │
│  Alertarme cuando llegue al │
│  ┌───────────────────────┐  │
│  │ 80%               ▼   │  │
│  └───────────────────────┘  │
│                             │
│  [ Guardar ]  [ Cancelar ]  │
│                             │
└─────────────────────────────┘
```

---

## 7. Transacciones Recurrentes

```
┌─────────────────────────────┐
│  ←  Recurrentes             │
├─────────────────────────────┤
│                             │
│  ─── Activas ───────────────│
│                             │
│  ┌─────────────────────────┐│
│  │ 🏠 Arriendo             ││
│  │ Gasto • Mensual         ││
│  │ Próx: 5 Ago 2026        ││
│  │              -$900.000  ││
│  │  [ Editar ]  [ Pausar ] ││
│  └─────────────────────────┘│
│                             │
│  ┌─────────────────────────┐│
│  │ 💼 Sueldo               ││
│  │ Ingreso • Mensual       ││
│  │ Próx: 1 Ago 2026        ││
│  │           +$4.500.000   ││
│  │  [ Editar ]  [ Pausar ] ││
│  └─────────────────────────┘│
│                             │
│  ┌─────────────────────────┐│
│  │ 📱 Netflix              ││
│  │ Gasto • Mensual         ││
│  │ Próx: 15 Ago 2026       ││
│  │               -$37.900  ││
│  │  [ Editar ]  [ Pausar ] ││
│  └─────────────────────────┘│
│                             │
│  ─── Pausadas ──────────────│
│  ┌─────────────────────────┐│
│  │ 🏋️ Gimnasio  (pausada)  ││
│  │  [ Editar ]  [ Activar ]││
│  └─────────────────────────┘│
│                             │
└─────────────────────────────┘
```

---

## 8. Confirmar Recurrente (Notificación)

> El usuario recibe una notificación push. Al tocarla, se abre este modal.

```
┌─────────────────────────────┐
│  Confirmar transacción      │
│  recurrente                 │
├─────────────────────────────┤
│                             │
│  🏠 Arriendo                │
│  Se generó el recordatorio  │
│  para el 5 de agosto.       │
│                             │
│  Confirma o ajusta antes de │
│  registrar:                 │
│                             │
│  Valor                      │
│  ┌───────────────────────┐  │
│  │ $ 900.000             │  │  ← editable por si cambió
│  └───────────────────────┘  │
│                             │
│  Fecha                      │
│  ┌───────────────────────┐  │
│  │ 5 Ago 2026        ▼   │  │  ← editable
│  └───────────────────────┘  │
│                             │
│  Estado                     │
│  ┌───────────────────────┐  │
│  │ Pagado            ▼   │  │
│  └───────────────────────┘  │
│                             │
│  [ Registrar ]  [ Ignorar ] │
│                             │
└─────────────────────────────┘
```

---

## 9. Reportes y Gráficas

```
┌─────────────────────────────┐
│  ←  Reportes                │
├─────────────────────────────┤
│                             │
│   ← Julio 2026  ▼  →        │
│                             │
│  [ Categorías ] [ Evolución ] [ Comparativo ]│  ← tabs
│                             │
│  ── Tab: Gastos por Categoría ──            │
│                             │
│       ╭───────────╮         │
│     ╭─╯     🔵    ╰─╮       │
│    ╭╯  Alimentación  ╰╮     │
│    │  32%  $280K      │     │  ← gráfica de torta
│    ╰╮  🟠  Transp.  ╭╯     │
│     ╰─╮  🔴  Viv. ╭─╯       │
│       ╰───────────╯         │
│                             │
│  🔵 Alimentación  $280K 32% │
│  🟠 Transporte    $180K 21% │
│  🔴 Vivienda      $900K 34% │
│  🟡 Entretenim.   $120K  7% │
│  ⚪ Otros          $90K  6% │
│                             │
│                             │
│  ── Tab: Evolución ─────────│
│                             │
│  4.5M ┤                ●    │
│  3.5M ┤          ●──●       │
│  2.5M ┤     ●──●            │
│  1.5M ┤●──●                 │
│       └──┬──┬──┬──┬──┬──┬── │
│         Feb Mar Abr May Jun Jul│
│                             │
│   ─── Ingresos  - - - Gastos│
│                             │
│        [ Exportar a Excel ] │
│                             │
└─────────────────────────────┘
```

---

## 10. Exportar a Excel

```
┌─────────────────────────────┐
│  Exportar transacciones  ✕  │
├─────────────────────────────┤
│                             │
│  Período                    │
│  ( ●) Mes actual (Jul 2026) │
│  ( ○) Personalizado         │
│                             │
│  (si personalizado ↓)       │
│  Desde  ┌────────────────┐  │
│         │ 01/07/2026  ▼  │  │
│         └────────────────┘  │
│  Hasta  ┌────────────────┐  │
│         │ 30/07/2026  ▼  │  │
│         └────────────────┘  │
│                             │
│  Incluir                    │
│  [✓] Gastos                 │
│  [✓] Ingresos               │
│  [✓] Pendientes             │
│  [ ] Solo recurrentes       │
│                             │
│  [ Generar y descargar ]    │
│                             │
└─────────────────────────────┘
```

---

## Resumen de Navegación

```
┌──────────────────────────────────────────────────────────────┐
│                        NAVEGACIÓN                            │
│                                                              │
│  [Login / Registro]  ──→  [Dashboard]                        │
│                               │                              │
│              ┌────────────────┴──────────────────┐           │
│              ▼                                   ▼           │
│    ── ALCANCE 1 ──                    ── ALCANCE 2 ──        │
│  [Lista Transacciones]            [Lista Tareas]             │
│         │                              │                     │
│   ┌─────┼──────────────┐         ┌────┼────────────────┐    │
│   ▼     ▼      ▼       ▼         ▼    ▼        ▼       ▼    │
│ [+New][Det.][Categ.][Recur.]  [+New][Det.][Calend.][Recs.]  │
│   │              │                │                          │
│   ▼              ▼                ▼                          │
│ [Form]      [Reportes]          [Form rápido]                │
│                  │                                           │
│                  ▼                                           │
│            [Exportar Excel]                                  │
└──────────────────────────────────────────────────────────────┘
```

---

## 11. Lista de Tareas

```
┌─────────────────────────────┐
│  ←  Tareas           + 🔍  │
├─────────────────────────────┤
│                             │
│  [ Lista ] [ Calendario ]   │  ← tabs de vista
│                             │
│  [ Estado ▼ ] [ Prio ▼ ] [ Categ ▼ ]│  ← chips de filtro
│                             │
│  ─── Hoy, 30 Jul ───────────│
│  ┌─────────────────────────┐│
│  │ [ ] 🔴 Pagar arriendo   ││  ← [ ] checkbox para completar directo
│  │ Vivienda • Vence hoy    ││
│  │               $900.000  ││  ← tiene valor monetario
│  └─────────────────────────┘│
│  ┌─────────────────────────┐│
│  │ [ ] 🟠 Llamar al banco  ││
│  │ Finanzas • Sin fecha    ││
│  └─────────────────────────┘│
│                             │
│  ─── Mañana, 31 Jul ────────│
│  ┌─────────────────────────┐│
│  │ [ ] 🟡 Comprar mercado  ││
│  │ Hogar • 31 Jul 2026     ││
│  │ 🔔 Recordatorio: 9 AM   ││
│  └─────────────────────────┘│
│                             │
│  ─── Completadas ───────────│
│  ┌─────────────────────────┐│
│  │ [✓] Renovar SOAT        ││  ← texto tachado
│  │ Vehículo • 29 Jul 2026  ││
│  └─────────────────────────┘│
│                             │
│           [ + Nueva tarea ] │  ← FAB
└─────────────────────────────┘
```

**Interacciones:**
- Tap en [ ] checkbox → marca como completada al instante, sin abrir la tarea.
- Swipe izquierdo → opciones [ Editar ] [ Eliminar ].
- Tap sobre la tarjeta → abre detalle de la tarea.
- 🔴 Alta / 🟠 Media / 🟡 Baja — colores fijos de prioridad.

---

## 12. Agregar / Editar Tarea

> Principio rector: solo el título es obligatorio. El usuario puede guardar en 1 toque y enriquecer después.

```
┌─────────────────────────────┐
│  ✕  Nueva tarea             │
├─────────────────────────────┤
│                             │
│  ┌───────────────────────┐  │
│  │ ¿Qué hay que hacer? __│  │  ← foco automático, teclado abierto
│  └───────────────────────┘  │
│                             │
│  ─── Más detalles ──────────│  ← sección colapsable
│                             │
│  Descripción (opcional)     │
│  ┌───────────────────────┐  │
│  │ ______________________│  │
│  └───────────────────────┘  │
│                             │
│  Prioridad                  │
│  [ 🔴 Alta ] [🟠 Media] [🟡 Baja]│  ← chips seleccionables
│                             │
│  Fecha de vencimiento       │
│  ┌───────────────────────┐  │
│  │ Sin fecha         ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Categoría                  │
│  ┌───────────────────────┐  │
│  │ Seleccionar       ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Valor monetario (opcional) │
│  ┌───────────────────────┐  │
│  │ $ ____________________│  │
│  └───────────────────────┘  │
│                             │
│  Recordatorio               │
│  ┌───────────────────────┐  │
│  │ Sin recordatorio  ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Subtareas                  │
│  ┌───────────────────────┐  │
│  │ + Agregar subtarea    │  │
│  └───────────────────────┘  │
│                             │
│      [ Guardar        ]     │
│                             │
└─────────────────────────────┘
```

**Notas del formulario:**
- Al abrir, el cursor está en el título y el teclado se despliega de inmediato.
- El botón "Guardar" siempre guarda con lo que esté diligenciado — solo el título es obligatorio.
- La sección "Más detalles" puede estar colapsada por defecto para no intimidar al usuario.
- Las subtareas se agregan inline sin abrir otro modal.

---

## 13. Detalle de Tarea

```
┌─────────────────────────────┐
│  ←  Detalle            ✏️ 🗑│
├─────────────────────────────┤
│                             │
│  [ ] Pagar arriendo         │  ← checkbox grande al inicio
│  🔴 Alta • Vivienda         │
│  Vence: hoy 30 Jul 2026     │
│  🔔 Recordatorio: 8:00 AM   │
│  💰 $900.000                │
│                             │
│  Descripción                │
│  Pagar el arriendo de julio │
│  antes de las 5pm.          │
│                             │
│  ─── Subtareas (1 de 3) ────│
│  [✓] Verificar saldo cuenta │
│  [ ] Hacer transferencia    │
│  [ ] Tomar foto recibo      │
│  [ + Agregar subtarea     ] │
│                             │
│  ─────────────────────────  │
│  Creada el 28/07/2026       │
│                             │
│      [ Marcar completada ]  │
│                             │
└─────────────────────────────┘
```

**Notas:**
- El progreso de subtareas se muestra como "1 de 3" en el encabezado de la sección.
- "Marcar completada" al final también actúa como el checkbox principal.
- Las subtareas se pueden marcar directamente desde esta pantalla sin editar.

---

## 14. Vista de Calendario

```
┌─────────────────────────────┐
│  ←  Tareas           + 🔍  │
├─────────────────────────────┤
│                             │
│  [ Lista ] [ Calendario ]   │  ← tab activo: Calendario
│                             │
│  [ Día ] [ Semana ] [ Mes ] │  ← sub-tabs de escala
│                             │
│  ── Vista: Mes — Jul 2026 ──│
│                             │
│  Lu  Ma  Mi  Ju  Vi  Sa  Do │
│   -   1   2   3   4   5   6 │
│   7   8   9  10  11  12  13 │
│  14  15  16  17  18  19  20 │
│  21  22  23  24  25  26  27 │
│  28  29 [30] 31             │  ← [30] = hoy, resaltado
│                             │
│  • días con punto = tienen tarea│
│                             │
│  ─── 30 Jul — Tareas ───────│
│  ┌─────────────────────────┐│
│  │ 🔴 Pagar arriendo       ││
│  │               $900.000  ││
│  └─────────────────────────┘│
│  ┌─────────────────────────┐│
│  │ 🟠 Llamar al banco      ││
│  └─────────────────────────┘│
│                             │
│           [ + Nueva tarea ] │
└─────────────────────────────┘
```

**Vista Semana:**
```
┌─────────────────────────────┐
│  ── Semana 28 Jul – 3 Ago ──│
├─────────────────────────────┤
│  Lun 28  │  Mar 29  │ Mie 30│
│──────────┼──────────┼───────│
│          │ ✅Renovar│🔴Arrend│
│          │   SOAT   │🟠Banco │
│          │          │       │
│  Jue 31  │  Vie 1   │ Sab 2 │
│──────────┼──────────┼───────│
│🟡Mercado │          │       │
│          │          │       │
└─────────────────────────────┘
```

---

## 15. Configurar Recordatorio

> Se abre como modal desde el formulario de tarea o desde el detalle.

```
┌─────────────────────────────┐
│  Recordatorio          ✕    │
├─────────────────────────────┤
│                             │
│  Tarea: Pagar arriendo      │
│                             │
│  Fecha                      │
│  ┌───────────────────────┐  │
│  │ 30 Jul 2026       ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Hora                       │
│  ┌───────────────────────┐  │
│  │ 08:00 AM          ▼   │  │
│  └───────────────────────┘  │
│                             │
│  Recordar también           │
│  ( ○) Solo esta vez         │
│  ( ●) Con anticipación      │
│                             │
│  Anticipación               │
│  ┌───────────────────────┐  │
│  │ 1 día antes       ▼   │  │
│  └───────────────────────┘  │
│    Opciones: 30 min, 1h,    │
│    1 día, 2 días, 1 semana  │
│                             │
│  [ Guardar ]  [ Cancelar ]  │
│                             │
└─────────────────────────────┘
```
