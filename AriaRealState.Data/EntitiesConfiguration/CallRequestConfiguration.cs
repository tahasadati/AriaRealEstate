using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class CallRequestConfiguration : BaseEntityConfiguration<CallRequest>
{
    public override void Configure(EntityTypeBuilder<CallRequest> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.Land)
            .WithMany(o => o.CallRequests)
            .HasForeignKey(o => o.LandId);

        builder.HasOne(o => o.Villa)
            .WithMany(o => o.CallRequests)
            .HasForeignKey(o => o.VillaId);
    }
}
