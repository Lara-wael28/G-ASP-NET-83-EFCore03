using EFcore03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore03.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new
            {
                e.StudentId,
                e.CourseId
            });

            builder.Property(e => e.EnrollmentDate)
                  .IsRequired();

            builder.Property(e => e.ProgressPercentage)
                   .HasPrecision(5, 2)
                   .IsRequired();

            builder.Property(e => e.Status)
                   .IsRequired();

            builder.Property(e => e.FinalGrade)
                   .HasPrecision(5, 2)
                   .IsRequired(false);

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
