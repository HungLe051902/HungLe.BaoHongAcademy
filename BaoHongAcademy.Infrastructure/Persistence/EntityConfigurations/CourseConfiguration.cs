using BaoHongAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.Persistence.EntityConfigurations
{
    class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course")
                .HasKey(b => b.CourseId);

            builder.Property(b => b.Author).HasMaxLength(50);

            builder.Property(b => b.CourseName).HasMaxLength(256);
        }

    }
}
