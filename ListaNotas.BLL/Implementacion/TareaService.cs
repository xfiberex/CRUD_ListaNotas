using ListaNotas.BLL.Interfaces;
using ListaNotas.DAL.Interfaces;
using ListaNotas.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaNotas.BLL.Implementacion
{
    public class TareaService : ITareaService
    {
        private readonly IGenericRepository<Tarea> _repositorio;

        public TareaService(IGenericRepository<Tarea> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Tarea>> Lista()
        {
            IQueryable<Tarea> query = await _repositorio.Consultar();
            return query.ToList();
        }

        public async Task<Tarea> Crear(Tarea entidad)
        {
            try
            {
                Tarea tarea_creada = await _repositorio.Crear(entidad);

                if (tarea_creada.IdTarea == 0)
                {
                    throw new TaskCanceledException("No se pudo crear la tarea");
                }
                return tarea_creada;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tarea> Editar(Tarea entidad)
        {
            try
            {
                Tarea tarea_encontrada = await _repositorio.Obtener(t => t.IdTarea == entidad.IdTarea);

                if (tarea_encontrada != null)
                {
                    tarea_encontrada.Nombre = entidad.Nombre;
                    tarea_encontrada.Descripcion = entidad.Descripcion;
                    tarea_encontrada.EsActivo = entidad.EsActivo;

                    bool respuesta = await _repositorio.Editar(tarea_encontrada);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo modificar la tarea");
                    }

                    return tarea_encontrada;
                }
                else
                {
                    // Manejar el caso cuando no se encuentra la tarea
                    throw new Exception($"No se encontró la tarea con el id {entidad.IdTarea}");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int idTarea)
        {
            try
            {
                Tarea tarea_encontrada = await _repositorio.Obtener(c => c.IdTarea == idTarea);

                if (tarea_encontrada == null)
                {
                    throw new TaskCanceledException("La tarea no existe");
                }
                bool respuesta = await _repositorio.Eliminar(tarea_encontrada);
                return respuesta;
            }
            catch
            {
                throw;
            }
        }
    }
}
