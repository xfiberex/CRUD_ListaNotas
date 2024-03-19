# Solución_ListaNotas

![Captura de pantalla (57)](https://github.com/xfiberex/CRUD_ListaNotas/assets/135444565/7f578d08-b995-4a49-b8f0-5432601a2a5b)

## Descripción

La aplicación web ASP.NET Core permite realizar las siguientes operaciones relacionadas con la entidad "Tarea":

### Listar Tareas

A través del endpoint `/Tarea/Lista`, se obtiene una lista de todas las tareas existentes en el sistema. Las tareas son mapeadas desde la entidad `Tarea` a un modelo de vista `VMTarea` y se devuelven como respuesta.

### Crear Tarea

Mediante el endpoint `/Tarea/Crear`, se puede crear una nueva tarea enviando los datos de la tarea en el cuerpo de la solicitud. Los datos se mapean desde el modelo de vista `VMTarea` a la entidad `Tarea`, se crea la tarea a través del servicio correspondiente y se devuelve la tarea creada como respuesta.

### Editar Tarea

El endpoint `/Tarea/Editar` permite actualizar los datos de una tarea existente. Se envían los nuevos datos de la tarea en el cuerpo de la solicitud, se mapean desde el modelo de vista `VMTarea` a la entidad `Tarea`, se actualiza la tarea a través del servicio y se devuelve la tarea actualizada como respuesta.

### Eliminar Tarea

A través del endpoint `/Tarea/Eliminar`, se puede eliminar una tarea existente enviando el identificador de la tarea (`idTarea`) como parámetro de consulta. Se llama al método de eliminación del servicio correspondiente y se devuelve una respuesta indicando si la operación fue exitosa o no.

## Uso

Esta aplicación se utiliza en conjunto con los servicios y repositorios correspondientes para manejar las operaciones CRUD de la entidad "Tarea". Se recomienda utilizar una herramienta como Postman o Insomnia para probar los diferentes endpoints y sus funcionalidades.
