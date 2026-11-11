using EFcore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore03.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.FullName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(i => i.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(i => i.Bio)
                   .HasMaxLength(500);

            builder.Property(i => i.JoinedDate)
                   .IsRequired();
            builder.HasData(
               new Instructor
               {
                   Id = 1,
                   FullName = "Ahmed Hassan",
                   Email = "ahmed@platform.com",
                   Bio = "C# instructor",
                   JoinedDate = new DateTime(2025, 1, 10)
               },

               new Instructor
               {
                   Id = 2,
                   FullName = "Mona Ali",
                   Email = "mona@platform.com",
                   Bio = "ASP.NET instructor",
                   JoinedDate = new DateTime(2025, 2, 15)
               },

               new Instructor
               {
                   Id = 3,
                   FullName = "Omar Khaled",
                   Email = "omar@platform.com",
                   Bio = "Database instructor",
                   JoinedDate = new DateTime(2025, 3, 20)

               });
        }
    }

}
