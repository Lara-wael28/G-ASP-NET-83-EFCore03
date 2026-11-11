using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFcore03.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 1, "Courses related to programming languages and software development.", "Programming", null });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinedDate" },
                values: new object[,]
                {
                    { 1, "C# instructor", "ahmed@platform.com", "Ahmed Hassan", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "ASP.NET instructor", "mona@platform.com", "Mona Ali", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Database instructor", "omar@platform.com", "Omar Khaled", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Courses focused on building websites and web applications.", "Web Development", 1 },
                    { 3, "Courses for developing mobile applications.", "Mobile Development", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 1, 1, "Learn the basics of C# programming language.", 1, true, 0, 49.99m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to C#" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 4, "Courses related to data analysis, machine learning, and AI.", "Data Science", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 2, 2, "Deep dive into ASP.NET Core for building web applications.", 2, true, 2, 99.99m, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced ASP.NET Core" },
                    { 3, 3, "Master the essentials of Entity Framework Core for data access.", 1, true, 1, 79.99m, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entity Framework Core Essentials" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 5, "Courses focused on machine learning techniques and algorithms.", "Machine Learning", 4 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 4, 4, "Learn the fundamentals of database design and normalization.", 3, true, 0, 59.99m, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Database Design Fundamentals" },
                    { 5, 5, "Become a full-stack web developer with hands-on projects.", 2, true, 2, 149.99m, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-Stack Web Development" },
                    { 6, 5, "Master data structures and algorithms for efficient coding.", 3, true, 1, 89.99m, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Structures and Algorithms" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
