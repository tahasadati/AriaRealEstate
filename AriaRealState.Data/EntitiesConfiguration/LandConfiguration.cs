using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class LandConfiguration : BaseEntityConfiguration<Land>
{
    public override void Configure(EntityTypeBuilder<Land> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.CreatedByUser)
            .WithMany(o => o.Lands)
            .HasForeignKey(o => o.CreateByUserId);
    }
}
