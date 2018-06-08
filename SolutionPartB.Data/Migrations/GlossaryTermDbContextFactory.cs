using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SolutionPartB.Data.Migration
{
    public class GlossaryTermDbContextFactory : IDesignTimeDbContextFactory<GlossaryTermDBContext>
    {

        public GlossaryTermDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GlossaryTermDBContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json")
              .Build();

            builder.UseSqlServer(configuration.GetConnectionString("Defa​ultConnection"));
            return new GlossaryTermDBContext(builder.Options);
        }
    }
}
