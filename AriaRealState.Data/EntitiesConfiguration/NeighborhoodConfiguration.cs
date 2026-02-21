using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class NeighborhoodConfiguration : BaseEntityConfiguration<Neighborhood>
{
    public override void Configure(EntityTypeBuilder<Neighborhood> builder)
    {
        base.Configure(builder);
    }
}
