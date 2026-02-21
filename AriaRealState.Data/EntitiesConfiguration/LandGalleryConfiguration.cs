using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class LandGalleryConfiguration : BaseEntityConfiguration<LandGallery>
{
    public override void Configure(EntityTypeBuilder<LandGallery> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.Land)
            .WithMany(o => o.LandGalleries)
            .HasForeignKey(o => o.LandId);
    }
}
