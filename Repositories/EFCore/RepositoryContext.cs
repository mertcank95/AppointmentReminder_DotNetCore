using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;
using System.Reflection.Emit;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public RepositoryContext(DbContextOptions options) :
           base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfig());
        }
    }
}
