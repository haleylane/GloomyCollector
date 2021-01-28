using System;
using GloomyCollector.Models;
using Microsoft.EntityFrameworkCore;

namespace GloomyCollector.Data
{
    public class GloomyDbContext : DbContext
    {
        public DbSet<Gloomy> Gloomies { get; set; }

        public GloomyDbContext(DbContextOptions<GloomyDbContext> options) : base(options)
        {
        }
    }
}
