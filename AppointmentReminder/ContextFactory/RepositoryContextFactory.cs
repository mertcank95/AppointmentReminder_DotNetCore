using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace ApiAppointmentReminder.ContextFactory
{
    public class RepositoryContextFactory
        : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("ef-SqlConnection"),
                prj => prj.MigrationsAssembly("ApiAppointmentReminder"));

            return new RepositoryContext(builder.Options);
        }
    }
}
