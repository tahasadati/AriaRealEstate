using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class BlogCategoryConfiguration : BaseEntityConfiguration<BlogCategory>
{
    public override void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
        base.Configure(builder);
    }
}
