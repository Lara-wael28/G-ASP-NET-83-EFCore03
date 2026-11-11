using EFcore03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore03.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course> builder)
        {
           builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(c => c.Description)
                   .HasMaxLength(1000);
            builder.Property(c => c.Price)
                   .HasPrecision(10, 2);
            builder.Property(c => c.Level)
                   .IsRequired();
            builder.Property(c => c.IsPublished)
                   .IsRequired();
            builder.Property(c => c.PublishedDate)
                  .IsRequired(false);

            builder.HasOne(c => c.Instructor)
                   .WithMany(i => i.Courses)
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                   .WithMany(c => c.Courses)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
      new Course
      {
          Id = 1,
          Title = "Introduction to C#",
          Description = "Learn the basics of C# programming language.",
          Price = 49.99m,
          Level = CourseLevel.Beginner,
          IsPublished = true,
          PublishedDate = new DateTime(2026, 1, 1),
          InstructorId = 1,
          CategoryId = 1
      },
      new Course
      {
          Id = 2,
          Title = "Advanced ASP.NET Core",
          Description = "Deep dive into ASP.NET Core for building web applications.",
          Price = 99.99m,
          Level = CourseLevel.Advanced,
          IsPublished = true,
          PublishedDate = new DateTime(2026, 1, 5),
          InstructorId = 2,
          CategoryId = 2
      },
      new Course
      {
          Id = 3,
          Title = "Entity Framework Core Essentials",
          Description = "Master the essentials of Entity Framework Core for data access.",
          Price = 79.99m,
          Level = CourseLevel.Intermediate,
          IsPublished = true,
          PublishedDate = new DateTime(2026, 1, 3),
          InstructorId = 1,
          CategoryId = 3
      },
      new Course
      {
          Id = 4,
          Title = "Database Design Fundamentals",
          Description = "Learn the fundamentals of database design and normalization.",
          Price = 59.99m,
          Level = CourseLevel.Beginner,
          IsPublished = true,
          PublishedDate = new DateTime(2026, 1, 7),
          InstructorId = 3,
          CategoryId = 4
      },
      new Course
      {
          Id = 5,
          Title = "Full-Stack Web Development",
          Description = "Become a full-stack web developer with hands-on projects.",
          Price = 149.99m,
          Level = CourseLevel.Advanced,
          IsPublished = true,
          PublishedDate = new DateTime(2026, 1, 9),
          InstructorId = 2,
          CategoryId = 5
      },
      new Course
      {
          Id = 6,
          Title = "Data Structures and Algorithms",
          Description = "Master data structures and algorithms for efficient coding.",
          Price = 89.99m,
          Level = CourseLevel.Intermediate,
          IsPublished = true,
          PublishedDate = new DateTime(2026, 1, 8),
          InstructorId = 3,
          CategoryId = 5
      }
  );
        }
    }
}
