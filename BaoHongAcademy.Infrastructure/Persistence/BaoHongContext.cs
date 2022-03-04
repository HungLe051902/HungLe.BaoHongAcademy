using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BaoHongAcademy.Infrastructure
{
    public class BaoHongContext : DbContext
    {
        public BaoHongContext(DbContextOptions<BaoHongContext> options) : base(options)
        {
        }

        /// <summary>
        /// Use Fluent API to config Entity Model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<User> Users { get; set; }
    }
}
