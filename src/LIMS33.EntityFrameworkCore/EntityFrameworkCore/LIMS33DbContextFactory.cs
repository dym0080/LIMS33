using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LIMS33.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class LIMS33DbContextFactory : IDesignTimeDbContextFactory<LIMS33DbContext>
    {
        public LIMS33DbContext CreateDbContext(string[] args)
        {
            LIMS33EfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = (DbContextOptionsBuilder<LIMS33DbContext>) new DbContextOptionsBuilder<LIMS33DbContext>()
                .UseOracle(configuration.GetConnectionString("Default"));

            return new LIMS33DbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LIMS33.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
