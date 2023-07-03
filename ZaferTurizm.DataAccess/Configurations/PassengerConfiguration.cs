using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger));
            builder.HasKey(pass => pass.Id);
            builder.Property(pass => pass.FirstName).IsRequired().HasColumnType("varchar(50)");
            builder.Property(pass => pass.LastName).IsRequired().HasColumnType("varchar(50)");
            builder.Property(pass => pass.IdentityNumber).IsRequired().HasColumnType("varchar(15)");

            builder.HasData(
                PassengerData.Data01_TsubasaOzora,
                PassengerData.Data02_SanaeOzora,
                PassengerData.Data03_TaroMisaki);
        }
    }
}
