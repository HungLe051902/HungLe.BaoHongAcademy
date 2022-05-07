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
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            new CourseEntityTypeConfiguration().Configure(modelBuilder.Entity<Course>());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
