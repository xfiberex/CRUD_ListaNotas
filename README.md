# 📝 CRUD Lista de Notas

Una aplicación web para gestión de tareas desarrollada con **ASP.NET Core MVC** y arquitectura en capas, que permite crear, leer, actualizar y eliminar notas/tareas de manera eficiente.

![Captura de pantalla (57)](https://github.com/xfiberex/CRUD_ListaNotas/assets/135444565/7f578d08-b995-4a49-b8f0-5432601a2a5b)

![Captura de pantalla (58)](https://github.com/xfiberex/CRUD_ListaNotas/assets/135444565/5ba836b6-2aed-4da6-852e-3c2c01dbdfec)

## 🚀 Características

- ✅ **CRUD completo** para gestión de tareas
- 🏗️ **Arquitectura en capas** bien estructurada
- 🎨 **Interfaz moderna** con SB Admin 2
- 🔄 **AutoMapper** para mapeo de entidades
- 📱 **Diseño responsivo**
- 🔍 **DataTables** para listado dinámico
- 🎯 **Patrón Repository** para acceso a datos

## 🛠️ Tecnologías

- **Framework**: ASP.NET Core 8.0 MVC
- **Lenguaje**: C# 
- **ORM**: Entity Framework Core (Code First)
- **Base de Datos**: SQL Server
- **Frontend**: HTML5, CSS3, JavaScript, jQuery
- **UI Framework**: SB Admin 2, Bootstrap
- **Mapeo**: AutoMapper
- **Inyección de Dependencias**: .NET Core DI Container

## 🏗️ Arquitectura del Proyecto

El proyecto sigue una **arquitectura en capas** que separa las responsabilidades:

### 📦 Capas del Sistema

```
├── ListaNotas.Entity/          # 🏷️ Capa de Entidades
├── ListaNotas.DAL/            # 💾 Capa de Acceso a Datos  
├── ListaNotas.BLL/            # 💼 Capa de Lógica de Negocio
├── ListaNotas.IOC/            # 🔗 Inversión de Control
└── ListaNotas.WEB/            # 🌐 Capa de Presentación
```

#### 🏷️ **ListaNotas.Entity** - Capa de Entidades
Contiene las entidades del dominio que representan las tablas de la base de datos.
- `Tarea.cs` - Entidad principal del sistema

#### 💾 **ListaNotas.DAL** - Capa de Acceso a Datos
Maneja toda la interacción con la base de datos usando el patrón Repository.
- `DBTASK.cs` - Contexto de Entity Framework
- `GenericRepository.cs` - Implementación del patrón Repository
- `IGenericRepository.cs` - Interfaz del repositorio

#### 💼 **ListaNotas.BLL** - Capa de Lógica de Negocio
Contiene la lógica de negocio y reglas de la aplicación.
- `TareaService.cs` - Servicios para gestión de tareas
- `ITareaService.cs` - Interfaz de servicios

#### 🔗 **ListaNotas.IOC** - Inversión de Control
Configura la inyección de dependencias del sistema.
- `Dependencia.cs` - Configuración de dependencias

#### 🌐 **ListaNotas.WEB** - Capa de Presentación
Contiene los controladores, vistas y recursos web.
- **Controllers**: Lógica de controladores MVC
- **Views**: Vistas Razor con diseño responsivo
- **Models**: ViewModels y modelos de vista
- **wwwroot**: Recursos estáticos (CSS, JS, imágenes)

## 🗃️ Modelo de Datos

### Entidad Tarea
```csharp
public class Tarea
{
    public int IdTarea { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
    public DateTime? FechaRegistro { get; set; }
}
```

## 🎯 Funcionalidades

### 📋 **Gestión de Tareas**

| Operación | Endpoint | Descripción |
|-----------|----------|-------------|
| **Listar** | `GET /Tarea/Lista` | Obtiene todas las tareas del sistema |
| **Crear** | `POST /Tarea/Crear` | Crea una nueva tarea |
| **Editar** | `PUT /Tarea/Editar` | Actualiza una tarea existente |
| **Eliminar** | `DELETE /Tarea/Eliminar` | Elimina una tarea por ID |

### 🔄 **Flujo de Datos**
1. **Vista** → **Controlador** → **Servicio** → **Repositorio** → **Base de Datos**
2. Los datos se mapean automáticamente entre entidades y ViewModels usando **AutoMapper**
3. Las respuestas se encapsulan en un objeto `GenericResponse<T>` para manejo consistente

## 📦 Instalación y Configuración

### Prerrequisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) o SQL Server Express
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o VS Code

### 🚀 Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/xfiberex/CRUD_ListaNotas.git
   cd CRUD_ListaNotas
   ```

2. **Configurar la base de datos**
   ```sql
   -- Ejecutar el script en: /Recusos del CRUD_Lista/Creación de BD y Tablas.sql
   CREATE DATABASE DBTASKLIST;
   ```

3. **Configurar cadena de conexión**
   Actualizar `appsettings.json` con tu cadena de conexión:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=tu-servidor;Database=DBTASKLIST;Trusted_Connection=true;"
     }
   }
   ```

4. **Restaurar paquetes y ejecutar**
   ```bash
   dotnet restore
   dotnet build
   dotnet run --project ListaNotas.WEB
   ```

5. **Abrir en el navegador**
   ```
   https://localhost:5001
   ```

## 🎨 Interfaz de Usuario

La aplicación utiliza **SB Admin 2**, un template moderno y responsivo que incluye:

- 📊 **Dashboard** principal
- 📋 **DataTables** para listados interactivos
- 🎨 **Iconografía Font Awesome**
- 📱 **Diseño completamente responsivo**
- 🌈 **Esquema de colores personalizable**

## 🤝 Contribución

Las contribuciones son bienvenidas. Para contribuir:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE.txt` para más detalles.

## 👨‍💻 Autor

**xfiberex** - [GitHub Profile](https://github.com/xfiberex)

---

⭐ Si este proyecto te ha sido útil, no olvides darle una estrella en GitHub
