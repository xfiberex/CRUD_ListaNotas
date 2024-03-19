using AutoMapper;
using ListaNotas.BLL.Interfaces;
using ListaNotas.Entity;
using ListaNotas.WEB.Models.ViewModels;
using ListaNotas.WEB.Utilidades.Response;
using Microsoft.AspNetCore.Mvc;

namespace ListaNotas.WEB.Controllers
{
    public class TareaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITareaService _tareaService;

        public TareaController(IMapper mapper, ITareaService tareaService)
        {
            _mapper = mapper;
            _tareaService = tareaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var ListaTarea = await _tareaService.Lista();
            List<VMTarea> vmTareaLista = _mapper.Map<List<VMTarea>>(ListaTarea);
            return StatusCode(StatusCodes.Status200OK, new { data = vmTareaLista });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] VMTarea modelo)
        {
            GenericResponse<VMTarea> gResponse = new GenericResponse<VMTarea>();

            try
            {
                Tarea tarea_creada = await _tareaService.Crear(_mapper.Map<Tarea>(modelo));
                modelo = _mapper.Map<VMTarea>(tarea_creada);
                gResponse.Estado = true;
                gResponse.Objeto = modelo;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, gResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] VMTarea modelo)
        {
            GenericResponse<VMTarea> gResponse = new GenericResponse<VMTarea>();

            try
            {
                Tarea tarea_editada = await _tareaService.Editar(_mapper.Map<Tarea>(modelo));
                modelo = _mapper.Map<VMTarea>(tarea_editada);
                gResponse.Estado = true;
                gResponse.Objeto = modelo;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, gResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int idTarea)
        {
            GenericResponse<string> gResponse = new GenericResponse<string>();

            try
            {
                gResponse.Estado = await _tareaService.Eliminar(idTarea);
            }
            catch (Exception ex)
            {
                gResponse.Estado = true;
                gResponse.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, gResponse);
        }
    }
}
