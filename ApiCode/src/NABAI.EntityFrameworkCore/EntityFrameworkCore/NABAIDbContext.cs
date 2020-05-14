using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NABAI.Authorization.Roles;
using NABAI.Authorization.Users;
using NABAI.MultiTenancy;
using NABAI.Wines;
namespace NABAI.EntityFrameworkCore
{
    public class NABAIDbContext : AbpZeroDbContext<Tenant, Role, User, NABAIDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NABAIDbContext(DbContextOptions<NABAIDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Wine> Wines { get; set; }
    }
}
