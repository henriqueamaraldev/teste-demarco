using Application.Services.Clientes;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config
{
    public static class ServicesConfig
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
        }
    }
}
