using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NABAI.EntityFrameworkCore
{
    public static class NABAIDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NABAIDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NABAIDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
