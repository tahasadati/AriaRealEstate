using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class VillaAdvanceFacilityConfiguration : BaseEntityConfiguration<VillaAdvanceFacility>
{
    public override void Configure(EntityTypeBuilder<VillaAdvanceFacility> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.Villa)
            .WithMany(o => o.VillaAdvanceFacilities)
            .HasForeignKey(o => o.VillaId);
    }
}
