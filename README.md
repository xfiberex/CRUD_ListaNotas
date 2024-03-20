# Solución_ListaNotas

![Captura de pantalla (57)](https://github.com/xfiberex/CRUD_ListaNotas/assets/135444565/7f578d08-b995-4a49-b8f0-5432601a2a5b)

![Captura de pantalla (58)](https://github.com/xfiberex/CRUD_ListaNotas/assets/135444565/5ba836b6-2aed-4da6-852e-3c2c01dbdfec)

## Descripción

CRUD desarrollado en capas como:

- **Capa Negocio (ListaNotas.BLL)**: Sirve de intermediario entre la base de datos y la aplicación.
- **Capa Datos (ListaNotas.DAL)**: Se encarga de la conexión entre la base de datos y la aplicación.
- **Capa Entidad (ListaNotas.Entity)**: Maneja las entidades o tablas con sus atributos.
- **Capa Controlador (ListaNotas.IOC)**: Contiene las dependencias para la ejecución.
- **Capa Presentación (ListaNotas.WEB)**: Encargada del diseño.

- NOTA: la carpeta wwwroot tiene codigo predefinido o plantillas para usar.

Como ejemplo, la aplicación web permite realizar las siguientes operaciones relacionadas con la entidad "Tarea":

### Listar Tareas

A través del endpoint `/Tarea/Lista`, se obtiene una lista de todas las tareas existentes en el sistema. Las tareas son mapeadas desde la entidad `Tarea` a un modelo de vista `VMTarea` y se devuelven como respuesta.

### Crear Tarea

Mediante el endpoint `/Tarea/Crear`, se puede crear una nueva tarea enviando los datos de la tarea en el cuerpo de la solicitud. Los datos se mapean desde el modelo de vista `VMTarea` a la entidad `Tarea`, se crea la tarea a través del servicio correspondiente y se devuelve la tarea creada como respuesta.

### Editar Tarea

El endpoint `/Tarea/Editar` permite actualizar los datos de una tarea existente. Se envían los nuevos datos de la tarea en el cuerpo de la solicitud, se mapean desde el modelo de vista `VMTarea` a la entidad `Tarea`, se actualiza la tarea a través del servicio y se devuelve la tarea actualizada como respuesta.

### Eliminar Tarea

A través del endpoint `/Tarea/Eliminar`, se puede eliminar una tarea existente enviando el identificador de la tarea (`idTarea`) como parámetro de consulta. Se llama al método de eliminación del servicio correspondiente y se devuelve una respuesta indicando si la operación fue exitosa o no.

## Uso

Se utiliza para representar las operaciones básicas que una aplicación de software puede realizar sobre los datos almacenados, generalmente en una base de datos. Estas operaciones son fundamentales para la gestión de información y son comunes en la mayoría de aplicaciones.
