using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinterIsComing.Infrastructure.Data.Configurations;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Resort> Resorts { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;
        public virtual DbSet<UserResort> UserResorts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserResort>()
                .HasKey(ur => new { ur.ResortId, ur.AppUserId });

            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new ResortConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
