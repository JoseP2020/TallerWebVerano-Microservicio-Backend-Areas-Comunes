using Application;
using Domain.Repository.AreasComunes;
using Domain.Repository.Condominios;
using Domain.Repository.Reservas;
using Domain.Repository.Residentes;
using Domain.Repository.Turnos;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.Repository.AreasComunes;
using Infrastructure.EntityFramework.Repository.Condominios;
using Infrastructure.EntityFramework.Repository.Reservas;
using Infrastructure.EntityFramework.Repository.Residentes;
using Infrastructure.EntityFramework.Repository.Turnos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core;
using System.Reflection;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAplication();
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            services.AddDbContext<ReadDbContext>(context => { context.UseNpgsql(connectionString); });
            services.AddDbContext<WriteDbContext>(context => { context.UseNpgsql(connectionString); });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IResidenteRepository, ResidenteRepository>();
            services.AddScoped<IAreaComunRepository, AreaComunRepository>();
            services.AddScoped<ITurnoRepository, TurnoRepository>();
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            return services;
        }
    }
}
