using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLearn.Models
{
    public class BrothersDbContext : DbContext
    {
        public DbSet<Brother> Brothers { get; set; }
        public BrothersDbContext(DbContextOptions<BrothersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brother>().ToTable("Brothers");
        }
    }
}
