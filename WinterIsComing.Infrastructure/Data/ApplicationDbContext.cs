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
        public virtual DbSet<Like> Likes { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new ResortConfiguration());
            builder.ApplyConfiguration(new PriceConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
