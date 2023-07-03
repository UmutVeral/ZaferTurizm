using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            builder.HasKey(city => city.Id);
            builder.Property(city => city.Name).IsRequired().HasColumnType("varchar(50)");

            builder.HasData(
                CityData.Data01_Adana,
                CityData.Data02_Ankara,
                CityData.Data03_Antalya,
                CityData.Data04_Bursa,
                CityData.Data05_Istanbul,
                CityData.Data06_Izmir);
        }
    }
}
