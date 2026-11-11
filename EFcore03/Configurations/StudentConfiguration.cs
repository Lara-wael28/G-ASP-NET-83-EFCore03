using EFcore03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore03.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
        {
           builder.HasKey(s => s.Id);
           builder.Property(s => s.FullName)
                  .IsRequired()
                  .HasMaxLength(150);
            builder.Property(s => s.Email)
                  .IsRequired()
                  .HasMaxLength(100);
            builder.Property(s => s.DateOfBirth)
                  .IsRequired();
            builder.HasMany(s => s.Enrollments)
                  .WithOne(e => e.Student)
                  .HasForeignKey(e => e.StudentId);
           
        }
    }
}
