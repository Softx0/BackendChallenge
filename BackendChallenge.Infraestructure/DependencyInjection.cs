
using BackendChallenge.Application.WaterJug.Handler;
using BackendChallenge.Application.WaterJug.Interfaces;
using BackendChallenge.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IWaterJug, WaterJugService>();
            return services;
        }
    }
}
