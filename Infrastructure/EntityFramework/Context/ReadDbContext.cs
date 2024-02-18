using Infrastructure.EntityFramework.Config.ReadConfig.AreasComunes;
using Infrastructure.EntityFramework.Config.ReadConfig.Condominios;
using Infrastructure.EntityFramework.Config.ReadConfig.Reservas;
using Infrastructure.EntityFramework.Config.ReadConfig.Residentes;
using Infrastructure.EntityFramework.Config.ReadConfig.Turnos;
using Infrastructure.EntityFramework.ReadModel.AreasComunes;
using Infrastructure.EntityFramework.ReadModel.Condominios;
using Infrastructure.EntityFramework.ReadModel.Reservas;
using Infrastructure.EntityFramework.ReadModel.Residentes;
using Infrastructure.EntityFramework.ReadModel.Turnos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<ResidenteReadModel> Residente { get; set; }
        public virtual DbSet<TurnoReadModel> Turno { get; set; }
        public virtual DbSet<AreaComunReadModel> AreaComun { get; set; }
        public virtual DbSet<CondominioReadModel> Condominio { get; set; }
        public virtual DbSet<ReservaReadModel> Reserva { get; set; }


        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ResidenteReadConfig());
            modelBuilder.ApplyConfiguration(new TurnoReadConfig());
            modelBuilder.ApplyConfiguration(new AreaComunReadConfig());
            modelBuilder.ApplyConfiguration(new CondominioReadConfig());
            modelBuilder.ApplyConfiguration(new ReservaReadConfig());

        }
    }
}
