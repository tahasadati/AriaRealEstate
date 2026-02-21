using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class VillaConfiguration : BaseEntityConfiguration<Villa>
{
    public override void Configure(EntityTypeBuilder<Villa> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.CreatedByUser)
            .WithMany(o => o.Villas)
            .HasForeignKey(o => o.CreateByUserId);

    }
}
