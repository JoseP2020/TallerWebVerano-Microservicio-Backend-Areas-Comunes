using Domain.Model.Reservas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Reservas
{
    internal class ReservaWriteConfig : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {

            builder.ToTable("Reserva");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Estado).HasColumnName("estado").HasConversion<string>();
            builder.Property(x => x.Inicio).HasColumnName("inicio");
            builder.Property(x => x.Fin).HasColumnName("fin");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

            builder.Property(x => x.ResidenteId).HasColumnName("residente_id");
            builder.Property(x => x.AreaComunId).HasColumnName("area_comun_id");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
