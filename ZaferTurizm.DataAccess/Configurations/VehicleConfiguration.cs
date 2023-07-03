using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));
            builder.HasKey(veh => veh.Id);
            builder.Property(veh => veh.PlateNumber).IsRequired().HasColumnType("varchar(20)");

            builder.HasOne(veh => veh.VehicleDefinition)
                .WithMany()
                .HasForeignKey(veh => veh.VehicleDefinitionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                VehicleData.Data01_34ABC123,
                VehicleData.Data02_34CDE654,
                VehicleData.Data03_34QWE345,
                VehicleData.Data04_34ZXC987);
        }
    }
}
