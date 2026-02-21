using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class BlogConfiguration : BaseEntityConfiguration<Blog>
{
    public override void Configure(EntityTypeBuilder<Blog> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.BlogCategory)
            .WithMany(o => o.Blogs)
            .HasForeignKey(o => o.BlogCategoryId);
    }
}
