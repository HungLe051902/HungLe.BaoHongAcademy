using BaoHongAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaoHongAcademy.Infrastructure.Persistence.EntityConfigurations
{
    class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog")
                .HasKey(b => b.BlogId);

            builder.Property(b => b.Author).HasMaxLength(50);
        }
    }
}
