using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AltSource.BrighterPath.Authorization.Roles;
using AltSource.BrighterPath.Authorization.Users;
using AltSource.BrighterPath.MultiTenancy;

namespace AltSource.BrighterPath.EntityFrameworkCore
{
    public class BrighterPathDbContext : AbpZeroDbContext<Tenant, Role, User, BrighterPathDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BrighterPathDbContext(DbContextOptions<BrighterPathDbContext> options)
            : base(options)
        {
        }
    }
}

