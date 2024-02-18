using Infrastructure.EntityFramework.ReadModel.Condominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Condominios
{
    internal class CondominioReadConfig : IEntityTypeConfiguration<CondominioReadModel>
    {
        public void Configure(EntityTypeBuilder<CondominioReadModel> builder)
        {
            builder.ToTable("Condominio");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

        }
    }
}
