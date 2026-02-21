using AriaRealState.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Context;

public class AppDbContext : IdentityDbContext<iUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
		
	}

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<CallRequest> CallRequests { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerLikedEstate> CustomerLikedEstates { get; set; }
    public DbSet<Land> Lands { get; set; }
    public DbSet<LandGallery> landGalleries { get; set; }
    public DbSet<Neighborhood> Neighborhoods { get; set; }
    public DbSet<UserActivity> UserActivities { get; set; }
    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaAdvanceFacility> VillaAdvanceFacilities { get; set; }
    public DbSet<VillaGallery> VillaGalleries { get; set; }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "1a111111-1111-1111-1111-111111111111",
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = "role-superadmin-v1"
            },
            new IdentityRole
            {
                Id = "2a222222-2222-2222-2222-222222222222",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "role-admin-v1"
            },
            new IdentityRole
            {
                Id = "3a333333-3333-3333-3333-333333333333",
                Name = "SupportLight",
                NormalizedName = "SUPPORTLIGHT",
                ConcurrencyStamp = "role-supportlight-v1"
            },
            new IdentityRole
            {
                Id = "4a444444-4444-4444-4444-444444444444",
                Name = "Seo",
                NormalizedName = "SEO",
                ConcurrencyStamp = "role-seo-v1"
            },
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
