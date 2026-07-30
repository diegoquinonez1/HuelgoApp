# Historias de Usuario — PersonalHub

> **Estado:** Definición completa — Alcance 1 y Alcance 2
> **Última actualización:** 2026-07-30
> **Rol único:** Usuario (persona individual que gestiona sus finanzas y tareas personales)

---

## Convenciones

| Campo | Descripción |
|---|---|
| **ID** | HU-A1-XXX (Alcance 1) / HU-A2-XXX (Alcance 2) |
| **Prioridad** | 🔴 Must Have · 🟠 Should Have · 🟡 Could Have |
| **Puntos** | Fibonacci: 1 · 2 · 3 · 5 · 8 · 13 |
| **Estado** | Pendiente · En análisis · Listo para desarrollo |

---

## Alcance 1 — Gestión de Presupuesto

### Épica 1: Autenticación y Cuenta

---

#### HU-A1-001 — Registro de cuenta
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario nuevo,
**quiero** registrarme con mi nombre, apellido, fecha de nacimiento, email y contraseña,
**para** tener una cuenta personal y privada donde guardar mis datos financieros.

**Criterios de aceptación:**
- [ ] El formulario tiene campos: nombre(s), apellido(s), fecha de nacimiento, email, contraseña, confirmar contraseña.
- [ ] El email debe tener formato válido y no estar registrado previamente.
- [ ] La contraseña debe tener mínimo 8 caracteres.
- [ ] La confirmación de contraseña debe coincidir.
- [ ] Al registrarse exitosamente, el usuario queda autenticado y va al Dashboard.
- [ ] Si el email ya existe, se muestra un mensaje claro sin revelar datos de otros usuarios.
- [ ] La fecha de nacimiento es obligatoria y el usuario debe ser mayor de edad (≥ 13 años).

---

#### HU-A1-002 — Inicio de sesión
> 🔴 Must Have · 2 pts · Pendiente

**Como** usuario registrado,
**quiero** iniciar sesión con mi email y contraseña,
**para** acceder a mis datos desde cualquier dispositivo.

**Criterios de aceptación:**
- [ ] La sesión persiste en el dispositivo; no se pide login en cada apertura de la app.
- [ ] Si las credenciales son incorrectas, se muestra un mensaje genérico (sin indicar cuál campo falló).
- [ ] Después de 5 intentos fallidos, la cuenta se bloquea por 5 minutos.
- [ ] Al iniciar sesión correctamente, el usuario va al Dashboard.

---

#### HU-A1-003 — Recuperación de contraseña
> 🟠 Should Have · 2 pts · Pendiente

**Como** usuario que olvidó su contraseña,
**quiero** recuperar el acceso a mi cuenta mediante mi email,
**para** no perder mis datos.

**Criterios de aceptación:**
- [ ] El usuario ingresa su email y recibe un correo con enlace de recuperación.
- [ ] El enlace expira en 30 minutos.
- [ ] El enlace solo puede usarse una vez.
- [ ] Después de cambiar la contraseña, las sesiones activas anteriores se invalidan.

---

#### HU-A1-004 — Cierre de sesión
> 🔴 Must Have · 1 pt · Pendiente

**Como** usuario autenticado,
**quiero** cerrar sesión desde la app,
**para** proteger mis datos si comparto el dispositivo.

**Criterios de aceptación:**
- [ ] La opción de cerrar sesión está visible en el perfil / configuración.
- [ ] Al cerrar sesión, los tokens se invalidan y se elimina la sesión local.
- [ ] El usuario es redirigido a la pantalla de login.

---

### Épica 2: Dashboard

---

#### HU-A1-005 — Ver resumen financiero del período
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver al abrir la app el total de ingresos, gastos y balance neto del período activo,
**para** saber en segundos cómo están mis finanzas sin tener que navegar.

**Criterios de aceptación:**
- [ ] El dashboard muestra: total ingresos, total gastos, balance neto (ingreso − gasto).
- [ ] El balance neto se muestra en verde si es positivo, rojo si es negativo, gris si es cero.
- [ ] El período activo se muestra claramente (ej. "Julio 2026").
- [ ] Los valores se calculan solo con transacciones del período activo.
- [ ] Si no hay transacciones, se muestran ceros sin errores.

---

#### HU-A1-006 — Cambiar período activo desde el Dashboard
> 🔴 Must Have · 2 pts · Pendiente

**Como** usuario,
**quiero** navegar entre períodos (anterior / siguiente) desde el Dashboard,
**para** revisar el histórico de meses o semanas pasadas.

**Criterios de aceptación:**
- [ ] El usuario puede navegar al período anterior y siguiente con flechas.
- [ ] El usuario puede seleccionar un período específico desde un picker.
- [ ] Todos los valores del Dashboard se actualizan al cambiar el período.
- [ ] El período activo se mantiene al navegar a otros módulos y volver.

---

#### HU-A1-007 — Ver resumen de presupuesto por categoría en el Dashboard
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver en el Dashboard el porcentaje consumido de cada categoría con presupuesto configurado,
**para** identificar de un vistazo si estoy cerca de exceder algún límite.

**Criterios de aceptación:**
- [ ] Se muestran barras de progreso por categoría con el monto gastado vs. la meta.
- [ ] El color de la barra cambia: verde (<75%), naranja (75–99%), rojo (≥100%).
- [ ] Solo se muestran las categorías que tienen una meta de presupuesto configurada.
- [ ] Si hay más de 4 categorías, se muestra un resumen y un enlace "Ver todas".
- [ ] Tocar una barra navega directo al detalle de esa categoría.

---

#### HU-A1-008 — Ver alertas activas en el Dashboard
> 🟠 Should Have · 2 pts · Pendiente

**Como** usuario,
**quiero** ver en el Dashboard las alertas activas (presupuesto excedido, recurrentes pendientes),
**para** actuar sobre ellas sin tener que buscarlas.

**Criterios de aceptación:**
- [ ] Las alertas se muestran como banners o tarjetas al inicio del Dashboard.
- [ ] Las alertas de presupuesto excedido muestran la categoría y el porcentaje.
- [ ] Las alertas de recurrentes pendientes muestran el nombre y la fecha.
- [ ] Tocar una alerta navega a la acción correspondiente.
- [ ] El usuario puede descartar una alerta con swipe o botón de cerrar.

---

### Épica 3: Transacciones

---

#### HU-A1-009 — Registrar una transacción
> 🔴 Must Have · 5 pts · Pendiente

**Como** usuario,
**quiero** registrar un ingreso o gasto con monto, fecha, categoría y estado en pocos toques,
**para** llevar el control de mis movimientos financieros sin que me tome tiempo.

**Criterios de aceptación:**
- [ ] Al abrir el formulario, el cursor está en el campo de monto y el teclado numérico aparece automáticamente.
- [ ] El tipo (Ingreso/Gasto) es el toggle más prominente del formulario.
- [ ] La fecha tiene como valor por defecto "hoy".
- [ ] El estado tiene como valor por defecto "Pagado".
- [ ] La moneda tiene como valor por defecto "COP".
- [ ] Los campos obligatorios son: tipo, monto, fecha, categoría, estado.
- [ ] El campo descripción/nota es opcional.
- [ ] La transacción se guarda localmente de inmediato (offline-first).
- [ ] Al guardar, el Dashboard se actualiza con el nuevo valor.
- [ ] No se permite guardar con monto igual a cero.

---

#### HU-A1-010 — Editar una transacción existente
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** modificar cualquier campo de una transacción ya registrada,
**para** corregir errores o actualizar valores que cambiaron.

**Criterios de aceptación:**
- [ ] El formulario de edición pre-llena todos los campos con los valores actuales.
- [ ] Todos los campos editables en creación también son editables en edición.
- [ ] Los cambios se guardan localmente de inmediato.
- [ ] Al guardar, el Dashboard y la lista de transacciones reflejan el cambio.
- [ ] El usuario puede cancelar la edición sin guardar cambios.

---

#### HU-A1-011 — Eliminar una transacción
> 🔴 Must Have · 2 pts · Pendiente

**Como** usuario,
**quiero** eliminar una transacción,
**para** corregir registros erróneos.

**Criterios de aceptación:**
- [ ] La acción de eliminar requiere confirmación explícita (diálogo "¿Eliminar esta transacción?").
- [ ] Al confirmar, la transacción desaparece de la lista y el Dashboard se actualiza.
- [ ] La eliminación se registra como soft delete para sincronización.
- [ ] La acción es accesible con swipe izquierdo en la lista y desde el detalle.

---

#### HU-A1-012 — Listar y filtrar transacciones
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver mis transacciones agrupadas por fecha y filtrarlas por tipo, categoría y estado,
**para** encontrar rápidamente cualquier movimiento.

**Criterios de aceptación:**
- [ ] Las transacciones se listan agrupadas por fecha, de más reciente a más antigua.
- [ ] Cada ítem muestra: nombre/nota, categoría, estado, monto (verde si ingreso, rojo si gasto).
- [ ] Los filtros disponibles son: tipo (ingreso/gasto/todos), categoría, estado, período.
- [ ] Los filtros son acumulativos (se pueden combinar).
- [ ] La lista incluye un buscador por texto libre (nombre/nota).
- [ ] Si no hay resultados para el filtro activo, se muestra un estado vacío descriptivo.

---

#### HU-A1-013 — Ver detalle de una transacción
> 🟠 Should Have · 1 pt · Pendiente

**Como** usuario,
**quiero** ver todos los campos de una transacción en una pantalla dedicada,
**para** confirmar los detalles sin editar.

**Criterios de aceptación:**
- [ ] Se muestran todos los campos: tipo, monto, moneda, fecha, categoría, estado, nota, si es recurrente, fecha de registro.
- [ ] Desde el detalle se puede acceder directamente a editar o eliminar.

---

### Épica 4: Categorías

---

#### HU-A1-014 — Usar categorías del sistema
> 🔴 Must Have · 1 pt · Pendiente

**Como** usuario,
**quiero** seleccionar categorías predefinidas por la app al registrar una transacción,
**para** clasificar mis movimientos sin tener que crear nada.

**Criterios de aceptación:**
- [ ] Las categorías del sistema están disponibles para todos los usuarios desde el primer login.
- [ ] No se pueden editar ni eliminar.
- [ ] Se distinguen visualmente de las categorías personalizadas (ej. etiqueta "Sistema").
- [ ] Categorías iniciales: Alimentación, Transporte, Vivienda, Salud, Educación, Entretenimiento, Sueldo, Freelance, Otros.

---

#### HU-A1-015 — Crear categoría personalizada
> 🟠 Should Have · 2 pts · Pendiente

**Como** usuario,
**quiero** crear mis propias categorías con nombre e ícono,
**para** clasificar transacciones según mi estilo de vida.

**Criterios de aceptación:**
- [ ] El usuario puede crear una categoría con nombre e ícono/color.
- [ ] El nombre no puede duplicar una categoría del sistema ni una propia existente.
- [ ] La categoría queda disponible inmediatamente en el selector de transacciones.
- [ ] El usuario puede editar el nombre e ícono de sus categorías personalizadas.
- [ ] El usuario puede eliminar una categoría personalizada si no tiene transacciones asociadas; si tiene, se le avisa y se le pide reasignar.

---

### Épica 5: Períodos y Presupuesto Proyectado

---

#### HU-A1-016 — Configurar el período de presupuesto
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** definir el tipo de período con el que quiero controlar mi presupuesto,
**para** que se ajuste a mi ciclo de ingresos (ej. quincenal si cobro dos veces al mes).

**Criterios de aceptación:**
- [ ] Opciones de período: mensual, quincenal, semanal, anual, personalizado (desde/hasta).
- [ ] El período activo se refleja en el Dashboard y en todos los cálculos.
- [ ] Al cambiar el tipo de período, los datos históricos no se pierden.
- [ ] El período personalizado permite seleccionar una fecha de inicio y fin.

---

#### HU-A1-017 — Configurar meta de presupuesto por categoría
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** definir cuánto quiero gastar por categoría en un período,
**para** tener un objetivo concreto y saber si me estoy excediendo.

**Criterios de aceptación:**
- [ ] El usuario puede asignar un monto máximo a cualquier categoría.
- [ ] El usuario puede configurar el umbral de alerta (ej. avisarme al 80%).
- [ ] La meta se muestra como barra de progreso en el Dashboard y en el módulo de presupuesto.
- [ ] Si no se configura meta para una categoría, no se muestra barra para ella.
- [ ] El usuario puede editar o eliminar la meta de una categoría.

---

#### HU-A1-018 — Recibir alerta cuando se acerca o supera el presupuesto
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** recibir una notificación push cuando el gasto de una categoría supera el umbral configurado,
**para** tomar decisiones antes de quedarme sin presupuesto.

**Criterios de aceptación:**
- [ ] La notificación se envía cuando el porcentaje de gasto alcanza el umbral definido.
- [ ] La notificación indica la categoría, el monto gastado y el monto de la meta.
- [ ] Si el usuario ya recibió la alerta al 80% y luego llega al 100%, recibe una segunda alerta.
- [ ] La notificación no se repite si el porcentaje no cambia de umbral.
- [ ] El usuario puede desactivar las alertas de una categoría específica.

---

### Épica 6: Transacciones Recurrentes

---

#### HU-A1-019 — Marcar una transacción como recurrente
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** marcar una transacción como recurrente y definir su frecuencia,
**para** no tener que recordar cuándo vence el arriendo, el sueldo o una suscripción.

**Criterios de aceptación:**
- [ ] Al crear o editar una transacción, el usuario puede activar "Es recurrente".
- [ ] Al activar, aparece el selector de frecuencia: mensual, quincenal, semanal, anual.
- [ ] La transacción recurrente queda en una lista de recurrentes gestionable.
- [ ] La regla recurrente puede pausarse o eliminarse sin afectar las transacciones ya registradas.

---

#### HU-A1-020 — Recibir notificación para confirmar una recurrente
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** recibir una notificación cuando una transacción recurrente está próxima a vencer, para confirmar o ajustar el registro antes de que se registre,
**para** poder ajustar el monto si cambió (ej. aumento de arriendo).

**Criterios de aceptación:**
- [ ] La notificación se envía el día de la fecha configurada.
- [ ] La notificación muestra el nombre, monto y fecha de la transacción recurrente.
- [ ] Al tocar la notificación, se abre un modal pre-llenado con los datos de la recurrente.
- [ ] El usuario puede ajustar el monto y/o la fecha antes de confirmar.
- [ ] Al confirmar, se registra la transacción normalmente.
- [ ] El usuario puede ignorar la notificación; la recurrente no se registra automáticamente.
- [ ] La próxima fecha de vencimiento se calcula automáticamente después de confirmar.

---

#### HU-A1-021 — Gestionar la lista de recurrentes
> 🟠 Should Have · 2 pts · Pendiente

**Como** usuario,
**quiero** ver todas mis transacciones recurrentes en un solo lugar,
**para** saber qué compromisos fijos tengo y cuándo vence cada uno.

**Criterios de aceptación:**
- [ ] La lista muestra: nombre, tipo, frecuencia, próxima fecha de vencimiento, monto.
- [ ] Las recurrentes activas y pausadas se muestran en secciones separadas.
- [ ] El usuario puede editar, pausar/activar o eliminar una recurrente desde la lista.

---

### Épica 7: Monedas

---

#### HU-A1-022 — Registrar una transacción en moneda extranjera
> 🟡 Could Have · 2 pts · Pendiente

**Como** usuario que recibe pagos en dólares u otra divisa,
**quiero** registrar una transacción en una moneda diferente a COP,
**para** que el registro sea fiel a la realidad aunque no convierta automáticamente.

**Criterios de aceptación:**
- [ ] El selector de moneda muestra al menos: COP, USD, EUR.
- [ ] La transacción se guarda en la moneda seleccionada con su monto original.
- [ ] En la lista y en el detalle se muestra la moneda junto al monto.
- [ ] Las transacciones en moneda extranjera no se suman al total en COP del Dashboard (o se muestran por separado con una nota).

---

### Épica 8: Reportes y Exportación

---

#### HU-A1-023 — Ver gráficas de gastos por categoría
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver una gráfica de torta o barras con el desglose de gastos por categoría del período,
**para** entender visualmente en qué se va mi dinero.

**Criterios de aceptación:**
- [ ] La gráfica muestra el porcentaje y monto por categoría.
- [ ] Al tocar un segmento/barra, se muestra el detalle de esa categoría.
- [ ] La gráfica incluye solo el período activo seleccionado.
- [ ] Si no hay datos, se muestra un estado vacío descriptivo.

---

#### HU-A1-024 — Ver evolución del balance en el tiempo
> 🟡 Could Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver una gráfica de línea con la evolución de ingresos y gastos por los últimos meses,
**para** identificar tendencias en mis finanzas.

**Criterios de aceptación:**
- [ ] La gráfica muestra al menos los últimos 6 períodos.
- [ ] Hay dos líneas: ingresos y gastos, con colores distintos.
- [ ] Al tocar un punto, se muestra el monto exacto de ese período.

---

#### HU-A1-025 — Exportar transacciones a Excel
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** exportar las transacciones de un período a un archivo Excel,
**para** hacer análisis adicionales o guardar un respaldo.

**Criterios de aceptación:**
- [ ] El usuario selecciona el período a exportar (mes actual, personalizado).
- [ ] El usuario puede filtrar qué tipos incluir: gastos, ingresos, pendientes.
- [ ] El archivo `.xlsx` descargado contiene todas las columnas de la transacción.
- [ ] El archivo se descarga al dispositivo y puede abrirse desde cualquier app de hojas de cálculo.
- [ ] Si el período no tiene transacciones, se informa antes de generar.

---

### Épica 9: Sincronización Offline

---

#### HU-A1-026 — Usar la app sin conexión a internet
> 🔴 Must Have · 5 pts · Pendiente

**Como** usuario,
**quiero** registrar transacciones y consultar mis datos aunque no tenga internet,
**para** no depender de la conexión para llevar mis finanzas al día.

**Criterios de aceptación:**
- [ ] Todas las operaciones de lectura y escritura funcionan sin conexión.
- [ ] Los datos se guardan localmente en SQLite de forma inmediata.
- [ ] La app muestra un indicador visual discreto cuando está en modo offline.
- [ ] Cuando se recupera la conexión, la sincronización ocurre automáticamente en background.
- [ ] El usuario recibe confirmación cuando la sincronización se completó.
- [ ] En caso de conflicto, gana el registro con el `updated_at` más reciente.

---

## Alcance 2 — Gestión de Tareas

### Épica 10: Gestión de Tareas

---

#### HU-A2-001 — Crear una tarea rápidamente
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** crear una tarea escribiendo solo el título y tocar Guardar,
**para** registrar un pendiente en segundos sin interrumpir lo que estoy haciendo.

**Criterios de aceptación:**
- [ ] Al abrir el formulario, el cursor está en el campo de título y el teclado aparece automáticamente.
- [ ] El único campo obligatorio es el título.
- [ ] Un solo botón "Guardar" guarda con lo que esté diligenciado.
- [ ] La tarea se crea con estado "Pendiente" por defecto.
- [ ] La tarea queda visible en la lista inmediatamente después de guardar.
- [ ] El formulario se puede cerrar sin guardar con el botón X.

---

#### HU-A2-002 — Agregar detalle a una tarea
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** enriquecer una tarea con descripción, prioridad, fecha de vencimiento, categoría y valor monetario,
**para** tener toda la información relevante en un solo lugar.

**Criterios de aceptación:**
- [ ] Campos opcionales disponibles: descripción, prioridad, fecha de vencimiento, categoría, valor monetario, moneda.
- [ ] La sección de campos opcionales puede estar colapsada por defecto en el formulario.
- [ ] El valor monetario acepta decimales y muestra el símbolo de la moneda seleccionada.
- [ ] Si se ingresa fecha de vencimiento, se habilita la opción de agregar un recordatorio.
- [ ] Todos los cambios se guardan con el mismo botón "Guardar".

---

#### HU-A2-003 — Editar una tarea existente
> 🔴 Must Have · 2 pts · Pendiente

**Como** usuario,
**quiero** modificar cualquier campo de una tarea ya creada,
**para** actualizar información o corregir errores.

**Criterios de aceptación:**
- [ ] El formulario de edición pre-llena todos los campos con los valores actuales.
- [ ] Todos los campos son editables.
- [ ] Los cambios se guardan localmente de inmediato.
- [ ] El usuario puede cancelar la edición sin guardar cambios.

---

#### HU-A2-004 — Completar una tarea desde la lista
> 🔴 Must Have · 2 pts · Pendiente

**Como** usuario,
**quiero** marcar una tarea como completada directamente desde la lista sin abrirla,
**para** cerrar pendientes de forma instantánea.

**Criterios de aceptación:**
- [ ] Cada tarea en la lista muestra un checkbox visible.
- [ ] Al tocar el checkbox, la tarea cambia su estado a "Completada" de inmediato.
- [ ] La tarea completada se mueve visualmente a la sección "Completadas" o cambia su apariencia (texto tachado).
- [ ] La acción es reversible: volver a tocar el checkbox la marca como "Pendiente".

---

#### HU-A2-005 — Eliminar una tarea
> 🔴 Must Have · 1 pt · Pendiente

**Como** usuario,
**quiero** eliminar una tarea,
**para** limpiar ítems que ya no son relevantes.

**Criterios de aceptación:**
- [ ] La eliminación requiere confirmación explícita.
- [ ] Al confirmar, la tarea desaparece de todas las vistas (lista y calendario).
- [ ] La eliminación es un soft delete para sincronización.
- [ ] La acción es accesible con swipe izquierdo en la lista y desde el detalle.

---

#### HU-A2-006 — Listar y filtrar tareas
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver mis tareas agrupadas por fecha y filtrarlas por estado, prioridad y categoría,
**para** enfocarme en lo que importa en cada momento.

**Criterios de aceptación:**
- [ ] Las tareas se agrupan por fecha de vencimiento: Hoy, Mañana, Esta semana, Sin fecha, Completadas.
- [ ] Los filtros disponibles son: estado, prioridad, categoría, con/sin valor monetario.
- [ ] Los filtros son acumulativos.
- [ ] Hay un buscador por texto libre (título/descripción).
- [ ] Las tareas completadas se pueden ocultar/mostrar con un toggle.

---

#### HU-A2-007 — Ver detalle de una tarea
> 🔴 Must Have · 1 pt · Pendiente

**Como** usuario,
**quiero** ver todos los datos de una tarea en una pantalla dedicada,
**para** revisar el contexto completo antes de ejecutarla.

**Criterios de aceptación:**
- [ ] Se muestran todos los campos: título, descripción, estado, prioridad, fecha, categoría, valor monetario, recordatorio, subtareas.
- [ ] El progreso de subtareas se muestra como "X de Y completadas".
- [ ] Desde el detalle se puede acceder a editar, eliminar y marcar como completada.
- [ ] Las subtareas se pueden marcar directamente desde el detalle sin abrir el formulario de edición.

---

### Épica 11: Subtareas

---

#### HU-A2-008 — Agregar subtareas a una tarea
> 🟠 Should Have · 3 pts · Pendiente

**Como** usuario,
**quiero** agregar una lista de subtareas a una tarea principal,
**para** desglosar tareas complejas en pasos más manejables.

**Criterios de aceptación:**
- [ ] Una tarea puede tener múltiples subtareas (sin límite definido).
- [ ] Cada subtarea tiene un texto y un estado (pendiente/completada).
- [ ] Las subtareas se agregan inline sin abrir otro modal.
- [ ] Se pueden reordenar con drag & drop.
- [ ] El progreso se muestra en la tarjeta de la lista: "2 de 5 completadas".
- [ ] Se pueden eliminar individualmente.

---

### Épica 12: Prioridades

---

#### HU-A2-009 — Asignar prioridad a una tarea
> 🟠 Should Have · 1 pt · Pendiente

**Como** usuario,
**quiero** asignar un nivel de prioridad a cada tarea,
**para** distinguir visualmente lo urgente de lo que puede esperar.

**Criterios de aceptación:**
- [ ] Las prioridades del sistema son: Alta (🔴), Media (🟠), Baja (🟡).
- [ ] Las prioridades del sistema no se pueden eliminar ni renombrar.
- [ ] La prioridad se muestra como ícono de color en la tarjeta de la lista.
- [ ] Las tareas sin prioridad asignada no muestran ícono de prioridad.

---

#### HU-A2-010 — Crear prioridades personalizadas
> 🟡 Could Have · 2 pts · Pendiente

**Como** usuario,
**quiero** crear mis propias banderas/prioridades con nombre y color,
**para** adaptar el sistema de priorización a mi flujo de trabajo.

**Criterios de aceptación:**
- [ ] El usuario puede crear prioridades con nombre y color personalizado.
- [ ] Las prioridades personalizadas se muestran junto a las del sistema en el selector.
- [ ] Pueden editarse y eliminarse; al eliminar, las tareas asociadas quedan sin prioridad.

---

### Épica 13: Recordatorios

---

#### HU-A2-011 — Configurar un recordatorio para una tarea
> 🔴 Must Have · 3 pts · Pendiente

**Como** usuario,
**quiero** configurar una fecha y hora de recordatorio para una tarea,
**para** recibir una notificación push que me avise antes de que venza.

**Criterios de aceptación:**
- [ ] El usuario puede seleccionar una fecha y hora específica para el recordatorio.
- [ ] El usuario puede elegir una anticipación: 30 min, 1 hora, 1 día, 2 días, 1 semana antes.
- [ ] Si se selecciona anticipación, el recordatorio se envía antes de la fecha de vencimiento.
- [ ] El recordatorio es visible en la tarjeta de la lista con ícono 🔔.
- [ ] La notificación push muestra el título de la tarea y la acción rápida "Completar".
- [ ] Al tocar la notificación, se abre el detalle de la tarea.

---

#### HU-A2-012 — Cancelar o modificar un recordatorio
> 🟠 Should Have · 1 pt · Pendiente

**Como** usuario,
**quiero** editar o cancelar el recordatorio de una tarea,
**para** ajustarlo si cambió la fecha o la tarea ya no es relevante.

**Criterios de aceptación:**
- [ ] El usuario puede editar el recordatorio desde el detalle de la tarea.
- [ ] El usuario puede eliminar el recordatorio sin eliminar la tarea.
- [ ] Si se elimina la tarea, el recordatorio programado se cancela automáticamente.

---

### Épica 14: Vista de Calendario

---

#### HU-A2-013 — Ver tareas en vista de mes
> 🟠 Should Have · 5 pts · Pendiente

**Como** usuario,
**quiero** ver mis tareas en una vista de calendario mensual,
**para** entender de un vistazo cómo está distribuida mi carga de trabajo en el mes.

**Criterios de aceptación:**
- [ ] La vista muestra un calendario mensual con puntos indicadores en días que tienen tareas.
- [ ] Al tocar un día, se expande la lista de tareas de ese día debajo del calendario.
- [ ] El día actual aparece resaltado.
- [ ] La vista se puede navegar hacia el mes anterior y siguiente.

---

#### HU-A2-014 — Ver tareas en vista de semana
> 🟡 Could Have · 3 pts · Pendiente

**Como** usuario,
**quiero** ver mis tareas en una cuadrícula semanal,
**para** planificar la semana y detectar días sobrecargados.

**Criterios de aceptación:**
- [ ] La vista muestra los 7 días de la semana en columnas.
- [ ] Cada celda muestra el título (truncado) de las tareas del día.
- [ ] Al tocar una tarea, se abre su detalle.
- [ ] Se puede navegar semana a semana.

---

#### HU-A2-015 — Crear tarea directamente desde el calendario
> 🟡 Could Have · 2 pts · Pendiente

**Como** usuario,
**quiero** tocar una fecha en el calendario y crear una tarea con esa fecha ya asignada,
**para** planificar desde la vista de calendario sin pasos adicionales.

**Criterios de aceptación:**
- [ ] Al tocar y mantener presionado (long press) un día en el calendario, se abre el formulario de nueva tarea con esa fecha pre-llenada.
- [ ] El flujo de creación es el mismo que desde la lista (solo título obligatorio).

---

### Épica 15: Relación Tareas — Presupuesto

---

#### HU-A2-016 — Asociar un valor monetario a una tarea
> 🟠 Should Have · 2 pts · Pendiente

**Como** usuario,
**quiero** indicar un valor monetario en una tarea (ej. "Pagar factura – $89.000"),
**para** tener visibilidad de los compromisos financieros pendientes desde el módulo de tareas.

**Criterios de aceptación:**
- [ ] El campo de valor monetario es opcional en el formulario de tarea.
- [ ] Si tiene valor, se muestra en la tarjeta de la lista y en el detalle.
- [ ] La moneda puede seleccionarse (COP por defecto).
- [ ] El valor no se registra automáticamente en el módulo de presupuesto.
- [ ] Las tareas con valor monetario pueden filtrarse en la lista.

---

## Resumen de Estimación

### Alcance 1 — Total

| Épica | Historias | Puntos totales | Must Have | Should Have | Could Have |
|---|---|---|---|---|---|
| Autenticación | 4 | 8 | 3 | 1 | 0 |
| Dashboard | 4 | 10 | 2 | 2 | 0 |
| Transacciones | 5 | 14 | 4 | 1 | 0 |
| Categorías | 2 | 3 | 1 | 1 | 0 |
| Períodos y Presupuesto | 3 | 9 | 1 | 2 | 0 |
| Recurrentes | 3 | 8 | 0 | 3 | 0 |
| Monedas | 1 | 2 | 0 | 0 | 1 |
| Reportes | 3 | 9 | 0 | 2 | 1 |
| Sincronización | 1 | 5 | 1 | 0 | 0 |
| **Total A1** | **26** | **68** | **12** | **12** | **2** |

### Alcance 2 — Total

| Épica | Historias | Puntos totales | Must Have | Should Have | Could Have |
|---|---|---|---|---|---|
| Gestión de Tareas | 7 | 15 | 6 | 1 | 0 |
| Subtareas | 1 | 3 | 0 | 1 | 0 |
| Prioridades | 2 | 3 | 0 | 1 | 1 |
| Recordatorios | 2 | 4 | 1 | 1 | 0 |
| Calendario | 3 | 10 | 0 | 1 | 2 |
| Tareas + Presupuesto | 1 | 2 | 0 | 1 | 0 |
| **Total A2** | **16** | **37** | **7** | **6** | **3** |

### **Total General: 42 historias · 105 puntos**

---

## Plan de Sprints

> **Duración de sprint:** 2 semanas
> **Velocidad estimada:** 12–15 puntos por sprint
> **Convención de estado:** 📋 Pendiente · 🔄 En progreso · ✅ Completado

---

### Sprint 0 — Fundación técnica ✅
> *Completado — no incluye historias de usuario*

| Entregable | Descripción |
|---|---|
| Repositorio local | Git init, .gitignore, README |
| Solución .NET | 27 proyectos scaffoldeados, build 0 errores |
| Infraestructura local | docker-compose (PostgreSQL, Redis, RabbitMQ, Seq) |
| Documentación base | REQUIREMENT.md, WIREFRAMES.md, USER_STORIES.md |

---

### Sprint 1 — Autenticación + Offline-first 📋
> **Puntos:** 11 · **Objetivo:** el usuario puede registrarse, iniciar sesión y operar sin conexión

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A1-001 | Registro de cuenta | 3 | 🔴 |
| HU-A1-002 | Inicio de sesión | 2 | 🔴 |
| HU-A1-004 | Cierre de sesión | 1 | 🔴 |
| HU-A1-026 | Usar la app sin conexión | 5 | 🔴 |

**Definición de "done" del sprint:**
- [ ] Un usuario nuevo puede registrarse y quedar autenticado.
- [ ] Un usuario existente puede iniciar y cerrar sesión.
- [ ] Las operaciones de escritura se persisten en SQLite cuando no hay red.
- [ ] Al recuperar la red, los datos se sincronizan con el servidor.
- [ ] Tests unitarios e integración para flujos de auth y sync básico.

---

### Sprint 2 — Dashboard + CRUD de Transacciones 📋
> **Puntos:** 15 · **Objetivo:** flujo completo de registro y consulta de movimientos financieros

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A1-005 | Ver resumen financiero en Dashboard | 3 | 🔴 |
| HU-A1-006 | Cambiar período activo | 2 | 🔴 |
| HU-A1-009 | Registrar una transacción | 5 | 🔴 |
| HU-A1-010 | Editar una transacción | 3 | 🔴 |
| HU-A1-011 | Eliminar una transacción | 2 | 🔴 |

**Definición de "done" del sprint:**
- [ ] El Dashboard muestra ingresos, gastos y balance neto del período activo.
- [ ] El usuario puede crear una transacción en ≤ 3 toques.
- [ ] El usuario puede editar y eliminar cualquier transacción.
- [ ] El Dashboard se actualiza en tiempo real al registrar o modificar.

---

### Sprint 3 — Lista, Filtros y Categorías 📋
> **Puntos:** 12 · **Objetivo:** el usuario puede navegar su historial y clasificar sus movimientos

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A1-012 | Listar y filtrar transacciones | 3 | 🔴 |
| HU-A1-013 | Ver detalle de una transacción | 1 | 🟠 |
| HU-A1-014 | Usar categorías del sistema | 1 | 🔴 |
| HU-A1-015 | Crear categoría personalizada | 2 | 🟠 |
| HU-A1-003 | Recuperación de contraseña | 2 | 🟠 |
| HU-A1-007 | Ver resumen de presupuesto por categoría en Dashboard | 3 | 🔴 |

**Definición de "done" del sprint:**
- [ ] El usuario puede filtrar transacciones por tipo, categoría, estado y período.
- [ ] Las 9 categorías del sistema están disponibles al crear una transacción.
- [ ] El usuario puede crear, editar y eliminar sus propias categorías.
- [ ] El Dashboard muestra barras de progreso por categoría con presupuesto configurado.

---

### Sprint 4 — Presupuesto Proyectado y Alertas 📋
> **Puntos:** 11 · **Objetivo:** el usuario tiene control proactivo de sus límites de gasto

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A1-016 | Configurar el período de presupuesto | 3 | 🔴 |
| HU-A1-017 | Configurar meta de presupuesto por categoría | 3 | 🟠 |
| HU-A1-018 | Recibir alerta cuando se acerca o supera el presupuesto | 3 | 🟠 |
| HU-A1-008 | Ver alertas activas en el Dashboard | 2 | 🟠 |

**Definición de "done" del sprint:**
- [ ] El usuario puede definir período mensual, quincenal, semanal o personalizado.
- [ ] El usuario puede asignar una meta y umbral de alerta por categoría.
- [ ] Se envía notificación push cuando se alcanza el umbral.
- [ ] Las alertas activas aparecen en el Dashboard.

---

### Sprint 5 — Transacciones Recurrentes 📋
> **Puntos:** 11 · **Objetivo:** el usuario gestiona compromisos financieros fijos sin olvidarlos

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A1-019 | Marcar una transacción como recurrente | 3 | 🟠 |
| HU-A1-020 | Recibir notificación para confirmar una recurrente | 3 | 🟠 |
| HU-A1-021 | Gestionar la lista de recurrentes | 2 | 🟠 |
| HU-A1-023 | Ver gráficas de gastos por categoría | 3 | 🟠 |

**Definición de "done" del sprint:**
- [ ] El usuario puede marcar una transacción como recurrente con frecuencia definida.
- [ ] La app notifica al usuario en la fecha de vencimiento para confirmar.
- [ ] El usuario puede editar, pausar y activar recurrentes desde una lista.
- [ ] La gráfica de torta muestra el desglose de gastos por categoría del período.

---

### Sprint 6 — Reportes, Exportación y Monedas 📋
> **Puntos:** 8 · **Objetivo:** cierre del Alcance 1 con visibilidad y portabilidad de datos

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A1-024 | Ver evolución del balance en el tiempo | 3 | 🟡 |
| HU-A1-025 | Exportar transacciones a Excel | 3 | 🟠 |
| HU-A1-022 | Registrar transacción en moneda extranjera | 2 | 🟡 |

**Definición de "done" del sprint:**
- [ ] La gráfica de línea muestra ingresos y gastos de los últimos 6 períodos.
- [ ] El usuario puede exportar un período a `.xlsx` con filtros de contenido.
- [ ] Las transacciones en USD u otra moneda se registran y visualizan en su moneda original.
- [ ] ✅ **Alcance 1 completo.**

---

### Sprint 7 — Tareas: Núcleo 📋
> **Puntos:** 14 · **Objetivo:** el usuario puede gestionar sus tareas diarias de forma rápida y sin fricción

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A2-001 | Crear una tarea rápidamente | 3 | 🔴 |
| HU-A2-002 | Agregar detalle a una tarea | 3 | 🔴 |
| HU-A2-003 | Editar una tarea existente | 2 | 🔴 |
| HU-A2-004 | Completar una tarea desde la lista | 2 | 🔴 |
| HU-A2-005 | Eliminar una tarea | 1 | 🔴 |
| HU-A2-006 | Listar y filtrar tareas | 3 | 🔴 |

**Definición de "done" del sprint:**
- [ ] El usuario crea una tarea escribiendo solo el título en ≤ 2 toques.
- [ ] Puede enriquecer la tarea con todos los campos opcionales.
- [ ] Puede completar una tarea directamente desde el checkbox en la lista.
- [ ] Las tareas se agrupan por fecha y se pueden filtrar por estado, prioridad y categoría.

---

### Sprint 8 — Tareas: Detalle, Subtareas y Recordatorios 📋
> **Puntos:** 11 · **Objetivo:** las tareas tienen toda la profundidad necesaria para planificar compromisos

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A2-007 | Ver detalle de una tarea | 1 | 🔴 |
| HU-A2-008 | Agregar subtareas a una tarea | 3 | 🟠 |
| HU-A2-009 | Asignar prioridad a una tarea | 1 | 🟠 |
| HU-A2-011 | Configurar un recordatorio para una tarea | 3 | 🔴 |
| HU-A2-012 | Cancelar o modificar un recordatorio | 1 | 🟠 |
| HU-A2-016 | Asociar un valor monetario a una tarea | 2 | 🟠 |

**Definición de "done" del sprint:**
- [ ] El detalle muestra todos los campos y el progreso de subtareas.
- [ ] Las subtareas son marcables directamente desde el detalle.
- [ ] Se envía notificación push en la fecha/hora configurada del recordatorio.
- [ ] Las tareas con valor monetario lo muestran en la lista y en el detalle.

---

### Sprint 9 — Tareas: Calendario y Personalización 📋
> **Puntos:** 12 · **Objetivo:** visión temporal de la agenda y personalización del sistema de prioridades

| ID | Historia | Pts | Prioridad |
|---|---|---|---|
| HU-A2-013 | Ver tareas en vista de mes | 5 | 🟠 |
| HU-A2-014 | Ver tareas en vista de semana | 3 | 🟡 |
| HU-A2-015 | Crear tarea directamente desde el calendario | 2 | 🟡 |
| HU-A2-010 | Crear prioridades personalizadas | 2 | 🟡 |

**Definición de "done" del sprint:**
- [ ] La vista mensual muestra puntos en días con tareas y lista al tocar un día.
- [ ] La vista semanal muestra tareas en cuadrícula por columna de día.
- [ ] Long press en una fecha del calendario abre el formulario con esa fecha pre-llenada.
- [ ] El usuario puede crear, editar y eliminar sus propias prioridades con color.
- [ ] ✅ **Alcance 2 completo.**

---

## Resumen del Plan

| Sprint | Enfoque | Puntos | Estado |
|---|---|---|---|
| 0 | Fundación técnica | — | ✅ |
| 1 | Autenticación + Offline | 11 | 📋 |
| 2 | Dashboard + CRUD Transacciones | 15 | 📋 |
| 3 | Lista, Filtros y Categorías | 12 | 📋 |
| 4 | Presupuesto Proyectado y Alertas | 11 | 📋 |
| 5 | Transacciones Recurrentes | 11 | 📋 |
| 6 | Reportes, Exportación y Monedas | 8 | 📋 |
| 7 | Tareas: Núcleo | 14 | 📋 |
| 8 | Tareas: Detalle, Subtareas y Recordatorios | 11 | 📋 |
| 9 | Tareas: Calendario y Personalización | 12 | 📋 |
| **Total** | | **105 pts · 18 semanas** | |

> **MVP entregable al finalizar Sprint 2** (semana 6): registro, login, dashboard y CRUD completo de transacciones con modo offline.
> **Alcance 1 completo al finalizar Sprint 6** (semana 12).
> **Alcance 2 completo al finalizar Sprint 9** (semana 18).

---

## MVP Propuesto — Alcance 1

Las siguientes historias forman el producto mínimo viable funcional:

| ID | Historia | Puntos |
|---|---|---|
| HU-A1-001 | Registro de cuenta | 3 |
| HU-A1-002 | Inicio de sesión | 2 |
| HU-A1-005 | Ver resumen financiero en Dashboard | 3 |
| HU-A1-006 | Cambiar período activo | 2 |
| HU-A1-009 | Registrar transacción | 5 |
| HU-A1-010 | Editar transacción | 3 |
| HU-A1-011 | Eliminar transacción | 2 |
| HU-A1-012 | Listar y filtrar transacciones | 3 |
| HU-A1-014 | Usar categorías del sistema | 1 |
| HU-A1-026 | Usar la app sin conexión | 5 |
| **MVP A1** | **10 historias** | **29 pts** |
