using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NABAI.Configuration;
using NABAI.Web;

namespace NABAI.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NABAIDbContextFactory : IDesignTimeDbContextFactory<NABAIDbContext>
    {
        public NABAIDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NABAIDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NABAIDbContextConfigurer.Configure(builder, configuration.GetConnectionString(NABAIConsts.ConnectionStringName));

            return new NABAIDbContext(builder.Options);
        }
    }
}
