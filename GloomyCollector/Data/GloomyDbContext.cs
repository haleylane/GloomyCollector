using System;
using GloomyCollector.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GloomyCollector.Data

{
    //changed from IdentityUser to GloomyUser, now changed back
    public partial class GloomyDbContext : IdentityDbContext<IdentityUser>
    //public class GloomyDbContext: DbContext
    {
        public DbSet<Gloomy> Gloomies { get; set; }
        public DbSet<GloomyUser> GloomyUsers { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        public GloomyDbContext(DbContextOptions<GloomyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WishList>().HasKey(et => new { et.UserId, et.GloomyId });
        }


    }

}

