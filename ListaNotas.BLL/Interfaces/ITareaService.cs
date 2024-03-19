using ListaNotas.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaNotas.BLL.Interfaces
{
    public interface ITareaService
    {
        Task<List<Tarea>> Lista();
        Task<Tarea> Crear(Tarea entidad);
        Task<Tarea> Editar(Tarea entidad);
        Task<bool> Eliminar(int idTarea);
    }
}
