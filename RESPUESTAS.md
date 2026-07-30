
### 7.1 Contexto y Usuario

1. **¿Quién es el usuario principal?** inicialmente para Una persona individual
2. **¿La app es solo para uso propio o se distribuirá públicamente** ? inicialmente uso propio
3. **¿Se requiere registro de cuenta de usuario** (email/contraseña, social login) o la app funciona de forma local sin autenticación? mejor con autenticacion, para mantener privacidad y confidencialidad, en especial en el primer alcance de finanzas personales
4. **¿Cuántos usuarios simultáneos se proyectan** en un primer lanzamiento? como inicialmetne es de uso indivisual, de pronto le diria al resto de la familia que la pruebe y use, pero piensa a futuro que puedan usarla muchisimos usuarios

### 7.2 Gestión de Presupuesto

5. **¿El período de presupuesto es siempre mensual** o el usuario puede definir períodos personalizados (semanal, quincenal, anual)? el usuario puede definirlo
6. **¿Las categorías/etiquetas son fijas** (predefinidas por la app) o el usuario puede crear las suyas? predeterminadas por la app, que se pueden usar pero no borrar ni modificar, pero el usuario podria crear las propias, que si puede modificar o borra de hecho.
7. **¿Se maneja múltiples monedas** o siempre es una moneda local (y cuál sería)? por defecto COP, pesos colombianos, pero se podrian agregar, por ejemplo si se hace un trabajo freelance y se recibe en otra moneda el ingreso
8. **¿Se requiere presupuesto proyectado?** Es decir, ¿el usuario puede definir cuánto quiere gastar por categoría y la app le avisa si se excede? claro, la idea es que la app permita crear banderas con notificaciones que permitan el mejor control de las finanzas personales
9. **¿La transacción puede ser recurrente** (ej. arriendo mensual, sueldo, suscripción)? Si es así, ¿la app la genera automáticamente cada período? si, pero no lo genera tan automatico, si no que le notifica al usuario para que confirme y hay si registre, por si hay un cambio inesperado de valor o fecha, etc, por ejemplo un aumento en canon de arriendo o subio una cuota de banco, etc.
10. **¿Se requiere exportar o reportar** los datos (PDF, Excel, gráficas)? las graficas pueden verse en la misma aplicacion, y por ahora solo exportemos a excel
11. **¿Qué estados son válidos para una transacción?** ¿Solo pagado/pendiente o hay más estados relevantes para el negocio? por ahora esos

### 7.3 Gestión de Tareas

12. **¿Las tareas están relacionadas con el presupuesto?** Por ejemplo, ¿una tarea puede tener un valor monetario asociado (ej. "pagar factura - $200.000")? si, pero no obligatorio, tambien puede ser tareas de lo que se va a haver en el dia o algo planeado para otro moment, etc.
13. **¿Las banderas/prioridades son niveles predefinidos** (alta, media, baja) o el usuario define sus propias banderas? las que dices son fijas y no se pueden borrar, pero el usuario puede personalizar propias
14. **¿Los recordatorios son notificaciones push** dentro de la app, o también se espera integración con calendario del dispositivo (Google Calendar, Apple Calendar)? por ahora solo la app, para otro alcance incluimos esa integracion
15. **¿Las tareas pueden tener subtareas** (checklist interno)? si
16. **¿Se requiere vista de calendario** para las tareas (ver tareas por día/semana/mes)? si

### 7.4 Experiencia General

17. **¿La app debe funcionar sin conexión a internet** y sincronizar cuando haya red disponible? si
18. **¿Se requiere modo oscuro / temas** desde el primer lanzamiento o es una mejora futura? mejora
19. **¿Hay alguna referencia visual** (app similar que te guste en diseño o UX) que sirva como inspiración? no, solo no he encontrado una que cumpla con lo que necesito entonces decidi en pensar en una
20. **¿Cuál es el dispositivo o sistema operativo prioritario** para el primer lanzamiento (Android, iOS o ambos al mismo tiempo)? ambos

Para el primer alcance, piensa como un analista de finanzas personales y que se requiere para que una persona de a pie, pueda llevar sus finanzas personales al dia, de una manera facil, intuitiva y eficaz. piensa en eso como requerimiento no funcionales super importantes (facil, intuitiva y eficaz)

para el segundo alcance, piensa como en un gestor de tareas, que permite llevar a dia las tareas, si que el hecho de registrarlas lleve o tome mucho tiempo, la idea es pensar en gestionar el tiempo para optimizarlo
