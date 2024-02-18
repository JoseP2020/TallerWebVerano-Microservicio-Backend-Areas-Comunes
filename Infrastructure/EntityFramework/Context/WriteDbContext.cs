using Domain.Model.AreasComunes;
using Domain.Model.Condominios;
using Domain.Model.Reservas;
using Domain.Model.Residentes;
using Domain.Model.Turnos;
using Infrastructure.EntityFramework.Config.WriteConfig.AreasComunes;
using Infrastructure.EntityFramework.Config.WriteConfig.Condominios;
using Infrastructure.EntityFramework.Config.WriteConfig.Reservas;
using Infrastructure.EntityFramework.Config.WriteConfig.Residentes;
using Infrastructure.EntityFramework.Config.WriteConfig.Turnos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Residente> Residente { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<AreaComun> AreaComun { get; set; }
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ResidenteWriteConfig());
            modelBuilder.ApplyConfiguration(new TurnoWriteConfig());
            modelBuilder.ApplyConfiguration(new AreaComunWriteConfig());
            modelBuilder.ApplyConfiguration(new CondominioWriteConfig());
            modelBuilder.ApplyConfiguration(new ReservaWriteConfig());

        }
    }
}
