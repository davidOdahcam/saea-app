using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SAEA.Infrastructure.Database.Context
{
    public sealed class SAEAContext(DbContextOptions<SAEAContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
