using Infrastructure.EntityFramework.ReadModel.Reservas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Reservas
{
    internal class ReservaReadConfig : IEntityTypeConfiguration<ReservaReadModel>
    {
        public void Configure(EntityTypeBuilder<ReservaReadModel> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Estado).HasColumnName("estado").HasConversion<string>();
            builder.Property(x => x.Inicio).HasColumnName("inicio");
            builder.Property(x => x.Fin).HasColumnName("fin");
            builder.Property(x => x.Eliminado).HasColumnName("eliminado");


            builder.Property(x => x.AreaComunId).HasColumnName("area_comun_id");
            builder.HasOne(x => x.AreaComun).WithMany().HasForeignKey(x => x.AreaComunId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ResidenteId).HasColumnName("residente_id");
            builder.HasOne(x => x.Residente).WithMany().HasForeignKey(x => x.ResidenteId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
