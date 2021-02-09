using System;
using GloomyCollector.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GloomyCollector.Data
{
    public class GloomyDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Gloomy> Gloomies { get; set; }

        public GloomyDbContext(DbContextOptions<GloomyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

