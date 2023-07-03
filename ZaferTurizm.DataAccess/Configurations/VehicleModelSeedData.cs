using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleModelSeedData : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasData(
                VehicleModelData.Data01_MercedesTravego,
                VehicleModelData.Data02_Mercedes403,
                VehicleModelData.Data03_MercedesTourismo,
                VehicleModelData.Data04_ManLions,
                VehicleModelData.Data05_ManFortuna,
                VehicleModelData.Data06_ManSl);
        }
    }
}
