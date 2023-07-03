using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleDefinitionConfiguration : IEntityTypeConfiguration<VehicleDefinition>
    {
        public void Configure(EntityTypeBuilder<VehicleDefinition> builder)
        {
            builder.ToTable(nameof(VehicleDefinition));
            builder.HasKey(entity => entity.Id);

            builder
                .HasOne(entity => entity.VehicleModel)
                .WithMany()
                .HasForeignKey(entity => entity.VehicleModelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
