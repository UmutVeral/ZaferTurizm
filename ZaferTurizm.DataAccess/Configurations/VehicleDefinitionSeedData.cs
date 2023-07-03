using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleDefinitionSeedData : IEntityTypeConfiguration<VehicleDefinition>
    {
        public void Configure(EntityTypeBuilder<VehicleDefinition> builder)
        {
            builder.HasData(
                VehicleDefinitionData.Data01_MercedesTravego2020,
                VehicleDefinitionData.Data02_MercedesTravego2021,
                VehicleDefinitionData.Data03_ManFortuna2019);
        }
    }
}
