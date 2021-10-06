using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AltSource.BrighterPath.EntityFrameworkCore
{
    public static class BrighterPathDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BrighterPathDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BrighterPathDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

