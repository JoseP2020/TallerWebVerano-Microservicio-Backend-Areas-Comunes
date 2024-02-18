using Infrastructure.EntityFramework.ReadModel.AreasComunes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.AreasComunes
{

    internal class AreaComunReadConfig : IEntityTypeConfiguration<AreaComunReadModel>
    {
        public void Configure(EntityTypeBuilder<AreaComunReadModel> builder)
        {
            builder.ToTable("AreaComun");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Descripcion).HasColumnName("descripcion");
            builder.Property(x => x.Estado).HasColumnName("estado");
            builder.Property(x => x.CapacidadMaxima).HasColumnName("capacidad_maxima");
            builder.Property(x => x.FinCierre).HasColumnName("fin_cierre");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");

            builder.Property(x => x.TurnoId).HasColumnName("turno_id");
            builder.HasOne(x => x.Turno).WithMany().HasForeignKey(x => x.TurnoId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CondominioId).HasColumnName("condominio_id");
            builder.HasOne(x => x.Condominio).WithMany().HasForeignKey(x => x.CondominioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
