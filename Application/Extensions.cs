using Domain.Factory.AreasComunes;
using Domain.Factory.Condominios;
using Domain.Factory.Reservas;
using Domain.Factory.Residentes;
using Domain.Factory.Turnos;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IAreaComunFactory, AreaComunFactory>();
            services.AddScoped<IReservaFactory, ReservaFactory>();
            services.AddScoped<IResidenteFactory, ResidenteFactory>();
            services.AddScoped<ITurnoFactory, TurnoFactory>();
            services.AddScoped<ICondominioFactory, CondominioFactory>();

            return services;
        }
    }
}
