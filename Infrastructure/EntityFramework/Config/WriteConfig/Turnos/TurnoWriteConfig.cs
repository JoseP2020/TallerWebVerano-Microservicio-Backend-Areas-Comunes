using Domain.Model.Turnos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Turnos
{
    internal class TurnoWriteConfig : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {

            builder.ToTable("Turno");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Inicio).HasColumnName("inicio");
            builder.Property(x => x.Fin).HasColumnName("fin");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
