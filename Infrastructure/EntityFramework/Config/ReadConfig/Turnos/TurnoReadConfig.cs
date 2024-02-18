using Infrastructure.EntityFramework.ReadModel.Turnos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Turnos
{
    internal class TurnoReadConfig : IEntityTypeConfiguration<TurnoReadModel>
    {
        public void Configure(EntityTypeBuilder<TurnoReadModel> builder)
        {
            builder.ToTable("Turno");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Inicio).HasColumnName("inicio");
            builder.Property(x => x.Fin).HasColumnName("fin");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

        }
    }
}
