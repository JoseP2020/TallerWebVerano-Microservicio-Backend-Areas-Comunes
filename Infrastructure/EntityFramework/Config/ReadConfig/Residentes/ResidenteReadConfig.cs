using Infrastructure.EntityFramework.ReadModel.Residentes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Residentes
{
    internal class ResidenteReadConfig : IEntityTypeConfiguration<ResidenteReadModel>
    {
        public void Configure(EntityTypeBuilder<ResidenteReadModel> builder)
        {
            builder.ToTable("Residente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Deudor).HasColumnName("deudor");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

        }
    }
}
