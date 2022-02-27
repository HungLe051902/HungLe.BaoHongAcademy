using BaoHongAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaoHongAcademy.Infrastructure
{
    public class BaoHongContext : DbContext
    {
        public BaoHongContext(DbContextOptions<BaoHongContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01; Initial Catalog=BaoHong; Integrated Security=SSPI");
        //}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
