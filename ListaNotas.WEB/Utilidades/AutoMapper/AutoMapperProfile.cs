using AutoMapper;
using ListaNotas.Entity;
using ListaNotas.WEB.Models.ViewModels;

namespace ListaNotas.WEB.Utilidades.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Categoria

            CreateMap<Tarea, VMTarea>()
            .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0));

            CreateMap<VMTarea, Tarea>()
            .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false));

            #endregion
        }
    }
}
