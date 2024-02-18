using Domain.Model.AreasComunes;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.ValueObjects;

namespace Infrastructure.EntityFramework.Config.WriteConfig.AreasComunes
{
    internal class AreaComunWriteConfig : IEntityTypeConfiguration<AreaComun>
    {
        public void Configure(EntityTypeBuilder<AreaComun> builder)
        {

            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
                descripcionValue => descripcionValue.Descripcion,
                stringValue => new DescripcionValue(stringValue)
            );
            var nombreConverter = new ValueConverter<NombreAreaComunValue, string>(
                nombreValue => nombreValue.Nombre,
                stringValue => new NombreAreaComunValue(stringValue)
            );
            var cantidadConverter = new ValueConverter<CantidadValue, int>(
                cantidadValue => cantidadValue.Value,
                numberValue => new CantidadValue(numberValue)
            );

            builder.ToTable("AreaComun");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(nombreConverter);
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);
            builder.Property(x => x.CapacidadMaxima).HasColumnName("capacidad_maxima").HasConversion(cantidadConverter);
            builder.Property(x => x.Estado).HasColumnName("estado").HasConversion(nombreConverter);
            builder.Property(x => x.FinCierre).HasColumnName("fin_cierre");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

            builder.Property(x => x.TurnoId).HasColumnName("turno_id");
            builder.Property(x => x.CondominioId).HasColumnName("condominio_id");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
