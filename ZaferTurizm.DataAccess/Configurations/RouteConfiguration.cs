using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable(nameof(Route));
            builder.HasKey(route => route.Id);

            builder.HasOne(route => route.DepartureCity)
                .WithMany()
                .HasForeignKey(route => route.DepartureCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(route => route.ArrivalCity)
                .WithMany()
                .HasForeignKey(route => route.ArrivalCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                RouteData.Data01_IzmirIstanbul,
                RouteData.Data02_IstanbulAnkara,
                RouteData.Data03_IstanbulAntalya,
                RouteData.Data04_AnkaraIzmir);
        }
    }
}
