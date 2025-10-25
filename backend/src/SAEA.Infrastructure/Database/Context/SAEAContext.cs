using Microsoft.EntityFrameworkCore;
using SAEA.Domain.Models;
using System.Reflection;

namespace SAEA.Infrastructure.Database.Context
{
    public sealed class SAEAContext(DbContextOptions<SAEAContext> options) : DbContext(options)
    {
        public DbSet<Pavilion> Pavilions { get; set; }
        public DbSet<OperatingBlock> OperatingBlocks { get; set; }
        public DbSet<OperatingHour> OperatingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
