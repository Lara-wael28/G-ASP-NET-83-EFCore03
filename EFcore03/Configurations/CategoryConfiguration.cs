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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id); 
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(c => c.Description)
                   .HasMaxLength(250);
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Category { Id = 1, Name = "Programming", Description = "Courses related to programming languages and software development." },
                new Category { Id = 2, Name = "Web Development", Description = "Courses focused on building websites and web applications.", ParentCategoryId = 1 },
                new Category { Id = 3, Name = "Mobile Development", Description = "Courses for developing mobile applications.", ParentCategoryId = 1 },
                new Category { Id = 4, Name = "Data Science", Description = "Courses related to data analysis, machine learning, and AI.", ParentCategoryId = 2 },
                new Category { Id = 5, Name = "Machine Learning", Description = "Courses focused on machine learning techniques and algorithms.", ParentCategoryId = 4 }
            );


        }
    }
}
