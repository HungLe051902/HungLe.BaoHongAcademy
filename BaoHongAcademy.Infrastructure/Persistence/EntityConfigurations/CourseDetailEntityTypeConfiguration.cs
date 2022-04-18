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
    class CourseDetailEntityTypeConfiguration : IEntityTypeConfiguration<CourseDetail>
    {
        public void Configure(EntityTypeBuilder<CourseDetail> builder)
        {
            builder.ToTable("CourseDetail")
                .HasKey(b => b.CourseDetailId);
                
            //builder.HasOne(b => b.CourseId).With
        }

    }
}
