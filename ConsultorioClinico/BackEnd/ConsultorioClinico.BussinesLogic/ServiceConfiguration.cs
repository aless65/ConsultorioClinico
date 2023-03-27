using Consultorio.BussinesLogic.Services;
using Consultorio.DataAccess;
using Consultorio.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.BussinesLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string connectionString)
        {
            service.AddScoped<DepartamentosRepository>();
            service.AddScoped<CargosRepository>();
            service.AddScoped<EmpleadosRepository>();
            ConsultorioContext.BuildConnectionString(connectionString);
        }
            
        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<GralService>();
            service.AddScoped<ConsService>();
        }
    }
}
