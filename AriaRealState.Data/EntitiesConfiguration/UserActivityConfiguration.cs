using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class UserActivityConfiguration : BaseEntityConfiguration<UserActivity>
{
    public override void Configure(EntityTypeBuilder<UserActivity> builder)
    {
        base.Configure(builder);
    }
}
