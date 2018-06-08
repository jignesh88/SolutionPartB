using System;
using Microsoft.EntityFrameworkCore;
using SolutionPartB.Data.Entity;
namespace SolutionPartB.Data
{
    public class GlossaryTermDBContext : DbContext
    {
        public GlossaryTermDBContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<GlossaryTerm> GlossaryTerms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlossaryTerm>().ToTable("GlossaryTerm");
        }
    }
}
