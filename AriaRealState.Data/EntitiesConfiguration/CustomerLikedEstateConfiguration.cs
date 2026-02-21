using AriaRealState.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.EntitiesConfiguration;

public class CustomerLikedEstateConfiguration : BaseEntityConfiguration<CustomerLikedEstate>
{
    public override void Configure(EntityTypeBuilder<CustomerLikedEstate> builder)
    {
        base.Configure(builder);

        builder.HasOne(o => o.Land)
            .WithMany(o => o.CustomerLikedEstates)
            .HasForeignKey(o => o.LandId);

        builder.HasOne(o => o.Villa)
            .WithMany(o => o.CustomerLikedEstates)
            .HasForeignKey(o => o.VillaId);

        builder.HasOne(o => o.Customer)
            .WithMany(o => o.CustomerLikedEstates)
            .HasForeignKey(o => o.CustomerId);

        builder.HasOne(o => o.iUser)
            .WithMany(o => o.CustomerLikedEstates)
            .HasForeignKey(o => o.CreatedByUserId);
    }
}
