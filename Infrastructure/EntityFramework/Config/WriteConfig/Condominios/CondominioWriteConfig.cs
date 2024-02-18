using Domain.Model.Condominios;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Condominios
{
    internal class CondominioWriteConfig : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            var nombreConverter = new ValueConverter<NombreCondominioValue, string>(
                nombreValue => nombreValue.Nombre,
                stringValue => new NombreCondominioValue(stringValue)
            );

            builder.ToTable("Condominio");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(nombreConverter);
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}

