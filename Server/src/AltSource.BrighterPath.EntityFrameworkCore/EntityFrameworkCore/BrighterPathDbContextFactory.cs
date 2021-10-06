using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AltSource.BrighterPath.Configuration;
using AltSource.BrighterPath.Web;

namespace AltSource.BrighterPath.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BrighterPathDbContextFactory : IDesignTimeDbContextFactory<BrighterPathDbContext>
    {
        public BrighterPathDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BrighterPathDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BrighterPathDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BrighterPathConsts.ConnectionStringName));

            return new BrighterPathDbContext(builder.Options);
        }
    }
}

