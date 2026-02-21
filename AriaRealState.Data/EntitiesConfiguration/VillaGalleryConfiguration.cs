using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

internal class VillaGalleryConfiguration : BaseEntityConfiguration<VillaGallery>
{
    public override void Configure(EntityTypeBuilder<VillaGallery> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.Villa)
            .WithMany(o => o.VillaGalleries)
            .HasForeignKey(o => o.VillaId);
    }
}
