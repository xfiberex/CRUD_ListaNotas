using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ListaNotas.BLL.Implementacion;
using ListaNotas.BLL.Interfaces;
using ListaNotas.DAL.DBContext;
using ListaNotas.DAL.Implementacion;
using ListaNotas.DAL.Interfaces;

namespace ListaNotas.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DBTASK>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ITareaService, TareaService>();
        }
    }
}
