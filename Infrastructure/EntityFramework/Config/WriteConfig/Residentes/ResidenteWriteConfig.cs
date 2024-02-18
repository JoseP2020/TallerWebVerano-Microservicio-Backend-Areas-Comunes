using Domain.Model.Residentes;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Residentes
{
    internal class ResidenteWriteConfig : IEntityTypeConfiguration<Residente>
    {
        public void Configure(EntityTypeBuilder<Residente> builder)
        {
            var nombreConverter = new ValueConverter<NombrePersonaValue, string>(
                nombreValue => nombreValue.Nombre,
                stringValue => new NombrePersonaValue(stringValue)
            );

            builder.ToTable("Residente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(nombreConverter);
            builder.Property(x => x.Deudor).HasColumnName("deudor");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
