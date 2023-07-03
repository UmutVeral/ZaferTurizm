using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable(nameof(VehicleModel));
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Name).IsRequired().HasColumnType("varchar(50)");
            
            builder.HasOne(model => model.VehicleMake)
                .WithMany()
                .HasForeignKey(model => model.VehicleMakeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
