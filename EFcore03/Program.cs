using EFcore03.Context;
using EFcore03.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcore03
{
    internal class Program
    {
        static void Main(string[] args)
        {
                SeedStudentsAndEnrollments();
                AddInstructor();
                AddCourse();
                AddSeveralStudents();
                EnrollStudent();

                FindCourse();
                FilterCourses();
                PrintSubCategories();
                PrintCourseRoster();

                ChangeCoursePrice();
                UpdateProgress();
                PublishCourse();

                UnenrollStudent();
                DeleteCategoryUnsafe();
                DeleteCategorySafe();
                DeleteCourse();

                BulkPriceRaise();
                BulkDeleteDroppedEnrollments();

                Console.WriteLine("\nAll operations finished.");
                Console.ReadKey();
            }

            static void SeedStudentsAndEnrollments()
            {
                using var context = new LearningContext();

                if (context.Students.Any())
                {
                    Console.WriteLine("Students already exist. Seeding skipped.");
                    return;
                }

                var students = new List<Student>
            {
                new Student
                {
                    FullName = "Ahmed Ali",
                    Email = "ahmed@example.com",
                    DateOfBirth = new DateTime(2002, 5, 10)
                },

                new Student
                {
                    FullName = "Mariam Hassan",
                    Email = "mariam@example.com",
                    DateOfBirth = new DateTime(2001, 8, 20)
                },

                new Student
                {
                    FullName = "Omar Mohamed",
                    Email = "omar@example.com",
                    DateOfBirth = new DateTime(2003, 2, 15)
                },

                new Student
                {
                    FullName = "Sara Ibrahim",
                    Email = "sara@example.com",
                    DateOfBirth = new DateTime(2002, 11, 5)
                },

                new Student
                {
                    FullName = "Youssef Khaled",
                    Email = "youssef@example.com",
                    DateOfBirth = new DateTime(2000, 7, 12)
                }
            };

                context.Students.AddRange(students);
                context.SaveChanges();

                Console.WriteLine("5 students inserted.");

                var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = students[0].Id,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2026, 5, 1),
                    ProgressPercentage = 100,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 95
                },

                new Enrollment
                {
                    StudentId = students[0].Id,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2026, 5, 2),
                    ProgressPercentage = 40,
                    Status = EnrollmentStatus.Active
                },

                new Enrollment
                {
                    StudentId = students[1].Id,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2026, 5, 3),
                    ProgressPercentage = 60,
                    Status = EnrollmentStatus.Active
                },

                new Enrollment
                {
                    StudentId = students[1].Id,
                    CourseId = 4,
                    EnrollmentDate = new DateTime(2026, 5, 4),
                    ProgressPercentage = 100,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 88
                },

                new Enrollment
                {
                    StudentId = students[2].Id,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2026, 5, 5),
                    ProgressPercentage = 20,
                    Status = EnrollmentStatus.Dropped
                },

                new Enrollment
                {
                    StudentId = students[2].Id,
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2026, 5, 6),
                    ProgressPercentage = 70,
                    Status = EnrollmentStatus.Active
                },

                new Enrollment
                {
                    StudentId = students[3].Id,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2026, 5, 7),
                    ProgressPercentage = 100,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 91
                },

                new Enrollment
                {
                    StudentId = students[4].Id,
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2026, 5, 8),
                    ProgressPercentage = 10,
                    Status = EnrollmentStatus.Dropped
                }
            };

                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();

                Console.WriteLine("8 enrollments inserted.");
            }

            static void AddInstructor()
            {
                using var context = new LearningContext();

                string email = "newinstructor@example.com";

                bool exists = context.Instructors.Any(i => i.Email == email);

                if (exists)
                {
                    Console.WriteLine("Instructor already exists.");
                    return;
                }

                var instructor = new Instructor
                {
                    FullName = "New Instructor",
                    Email = email,
                    Bio = "Backend Developer",
                    JoinedDate = DateTime.Now
                };

                context.Instructors.Add(instructor);

                context.SaveChanges();

                Console.WriteLine(
                    $"Instructor added successfully. Generated Id = {instructor.Id}");
            }

            static void AddCourse()
            {
                using var context = new LearningContext();
                var instructor = context.Instructors
                    .FirstOrDefault(i => i.Email == "newinstructor@example.com");

                if (instructor == null)
                {
                    Console.WriteLine("Course cannot be added: Instructor not found.");
                    return;
                }

                int categoryId = 3;

                bool categoryExists = context.Categories
                    .Any(c => c.Id == categoryId);

                if (!categoryExists)
                {
                    Console.WriteLine("Course cannot be added: Category not found.");
                    return;
                }

                string title = "New ASP.NET Course";

                if (context.Courses.Any(c => c.Title == title))
                {
                    Console.WriteLine("Course already exists.");
                    return;
                }

                var course = new Course
                {
                    Title = title,
                    Description = "A new ASP.NET course.",
                    Price = 1600,
                    Level = CourseLevel.Intermediate,
                    IsPublished = false,
                    PublishedDate = null,

                    // Work with Foreign Keys directly
                    InstructorId = instructor.Id,
                    CategoryId = categoryId
                };

                context.Courses.Add(course);

                context.SaveChanges();

                Console.WriteLine(
                    $"Course added successfully. Id = {course.Id}");
            }
            static void AddSeveralStudents()
            {
                using var context = new LearningContext();

                if (context.Students.Any(s =>
                    s.Email == "student6@example.com" ||
                    s.Email == "student7@example.com" ||
                    s.Email == "student8@example.com"))
                {
                    Console.WriteLine("Some of these students already exist.");
                    return;
                }

                var students = new List<Student>
            {
                new Student
                {
                    FullName = "Student Six",
                    Email = "student6@example.com",
                    DateOfBirth = new DateTime(2003, 1, 10)
                },

                new Student
                {
                    FullName = "Student Seven",
                    Email = "student7@example.com",
                    DateOfBirth = new DateTime(2002, 3, 20)
                },

                new Student
                {
                    FullName = "Student Eight",
                    Email = "student8@example.com",
                    DateOfBirth = new DateTime(2001, 9, 15)
                }
            };

                context.Students.AddRange(students);
                context.SaveChanges();
                Console.WriteLine("Three students added:");

                foreach (var student in students)
                {
                    Console.WriteLine(
                        $"{student.FullName} - Generated Id: {student.Id}");
                }
            }
            static void EnrollStudent()
            {
                using var context = new LearningContext();

                string studentEmail = "student6@example.com";
                int courseId = 1;
                var student = context.Students
                    .FirstOrDefault(s => s.Email == studentEmail);

                if (student == null)
                {
                    Console.WriteLine("Enrollment refused: Student not found.");
                    return;
                }
                var course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Enrollment refused: Course not found.");
                    return;
                }
                if (!course.IsPublished)
                {
                    Console.WriteLine(
                        "Enrollment refused: Course is not published.");
                    return;
                }

                bool alreadyEnrolled = context.Enrollments.Any(e =>
                    e.StudentId == student.Id &&
                    e.CourseId == courseId);

                if (alreadyEnrolled)
                {
                    Console.WriteLine(
                        "Enrollment refused: Student is already enrolled.");
                    return;
                }

                var enrollment = new Enrollment
                {
                    StudentId = student.Id,
                    CourseId = courseId,
                    EnrollmentDate = DateTime.Now,
                    ProgressPercentage = 0,
                    Status = EnrollmentStatus.Active,
                    FinalGrade = null
                };

                context.Enrollments.Add(enrollment);

                context.SaveChanges();

                Console.WriteLine("Student enrolled successfully.");
            }
            static void FindCourse()
            {
                using var context = new LearningContext();

                int id = 1;
                var courseById = context.Courses.Find(id);

                if (courseById == null)
                {
                    Console.WriteLine("Course not found by Id.");
                }
                else
                {
                    Console.WriteLine(
                        $"Found by Id: {courseById.Title}");
                }
                string title = "C# Fundamentals";

                var courseByTitle = context.Courses
                    .FirstOrDefault(c => c.Title == title);

                if (courseByTitle == null)
                {
                    Console.WriteLine("Course not found by Title.");
                }
                else
                {
                    Console.WriteLine(
                        $"Found by Title: {courseByTitle.Title}");
                }
            }
            static void FilterCourses()
            {
                using var context = new LearningContext();

                decimal minPrice = 900;
                decimal maxPrice = 1800;

                var courses = context.Courses
                    .Where(c => c.Price >= minPrice &&
                                c.Price <= maxPrice)
                    .OrderByDescending(c => c.Price)
                    .Select(c => new
                    {
                        c.Title,
                        c.Level,
                        c.Price
                    })
                    .ToList();

                Console.WriteLine("\nFiltered Courses:");

                if (courses.Count == 0)
                {
                    Console.WriteLine("No courses found in this price range.");
                    return;
                }

                foreach (var course in courses)
                {
                    Console.WriteLine(
                        $"{course.Title} | {course.Level} | {course.Price}");
                }
            }
            static void PrintSubCategories()
            {
                using var context = new LearningContext();

                int parentId = 1;

                var parentExists = context.Categories
                    .Any(c => c.Id == parentId);

                if (!parentExists)
                {
                    Console.WriteLine("Parent category not found.");
                    return;
                }

                var subCategories = context.Categories
                    .Where(c => c.ParentCategoryId == parentId)
                    .ToList();

                Console.WriteLine("\nDirect Sub-Categories:");

                if (subCategories.Count == 0)
                {
                    Console.WriteLine("No sub-categories found.");
                }
                else
                {
                    foreach (var category in subCategories)
                    {
                        Console.WriteLine(category.Name);
                    }
                }

                var topLevelCategories = context.Categories
                    .Where(c => c.ParentCategoryId == null)
                    .ToList();

                Console.WriteLine("\nTop-Level Categories:");

                foreach (var category in topLevelCategories)
                {
                    Console.WriteLine(category.Name);
                }
            }

            static void PrintCourseRoster()
            {
                using var context = new LearningContext();

                int courseId = 1;

                bool courseExists = context.Courses
                    .Any(c => c.Id == courseId);

                if (!courseExists)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }
                var studentIds = context.Enrollments
                    .Where(e => e.CourseId == courseId)
                    .Select(e => e.StudentId)
                    .ToList();

                var students = context.Students
                    .Where(s => studentIds.Contains(s.Id))
                    .ToList();

                Console.WriteLine(
                    $"\nNumber of enrolled students: {studentIds.Count}");

                if (students.Count == 0)
                {
                    Console.WriteLine("No students enrolled in this course.");
                    return;
                }

                foreach (var student in students)
                {
                    Console.WriteLine(student.FullName);
                }
            }

            static void ChangeCoursePrice()
            {
                using var context = new LearningContext();

                int courseId = 1;

                var course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                course.Price = 1200;

                context.SaveChanges();

                Console.WriteLine("Course price changed successfully.");
            }

            static void UpdateProgress()
            {
                using var context = new LearningContext();

                int studentId = 1;
                int courseId = 1;

                decimal newProgress = 100;
                if (newProgress < 0 || newProgress > 100)
                {
                    Console.WriteLine(
                        "Invalid progress. It must be between 0 and 100.");
                    return;
                }
                var enrollment = context.Enrollments.Find(
                    studentId,
                    courseId);

                if (enrollment == null)
                {
                    Console.WriteLine("Enrollment not found.");
                    return;
                }

                enrollment.ProgressPercentage = newProgress;

                if (newProgress == 100)
                {
                    enrollment.Status = EnrollmentStatus.Completed;
                }

                context.SaveChanges();

                Console.WriteLine(
                    $"Progress updated successfully to {newProgress}%.");
            }

            static void PublishCourse()
            {
                using var context = new LearningContext();
                var course = context.Courses
                    .FirstOrDefault(c => c.Title == "New ASP.NET Course");

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                course.IsPublished = true;
                course.PublishedDate = DateTime.Now;

                context.SaveChanges();

                Console.WriteLine("Course published successfully.");
            }
            static void UnenrollStudent()
            {
                using var context = new LearningContext();

                int studentId = 1;
                int courseId = 3;

                var enrollment = context.Enrollments.Find(
                    studentId,
                    courseId);

                if (enrollment == null)
                {
                    Console.WriteLine("Enrollment not found.");
                    return;
                }

                context.Enrollments.Remove(enrollment);

                context.SaveChanges();

                Console.WriteLine("Student unenrolled successfully.");
            }

            static void DeleteCategoryUnsafe()
            {
                using var context = new LearningContext();

                int categoryId = 1;

                var category = context.Categories.Find(categoryId);

                if (category == null)
                {
                    Console.WriteLine("Category not found.");
                    return;
                }

                context.Categories.Remove(category);

                try
                {
                    context.SaveChanges();

                    Console.WriteLine("Category deleted successfully.");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(
                        "Category could not be deleted because it has sub-categories.");

                    Console.WriteLine(
                        ex.InnerException?.Message ?? ex.Message);
                }
            }

            static void DeleteCategorySafe()
            {
                using var context = new LearningContext();

                int categoryId = 1;

                var category = context.Categories.Find(categoryId);

                if (category == null)
                {
                    Console.WriteLine("Category not found.");
                    return;
                }

                bool hasSubCategories = context.Categories
                    .Any(c => c.ParentCategoryId == categoryId);

                if (hasSubCategories)
                {
                    Console.WriteLine(
                        "Cannot delete category because it has sub-categories.");

                    return;
                }

                context.Categories.Remove(category);

                try
                {
                    context.SaveChanges();

                    Console.WriteLine("Category deleted safely.");
                }
                catch (DbUpdateException)
                {
                    Console.WriteLine(
                        "Category could not be deleted because it is referenced by other records.");
                }
            }
            static void DeleteCourse()
            {
                using var context = new LearningContext();

                int courseId = 3;

                var course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                int before = context.Enrollments
                    .Count(e => e.CourseId == courseId);

                Console.WriteLine(
                    $"Enrollments before deleting course: {before}");

                context.Courses.Remove(course);

                context.SaveChanges();
                int after = context.Enrollments
                    .Count(e => e.CourseId == courseId);

                Console.WriteLine(
                    $"Enrollments after deleting course: {after}");

                Console.WriteLine("Course deleted successfully.");
            }

            static void BulkPriceRaise()
            {
                using var context = new LearningContext();

                CourseLevel level = CourseLevel.Beginner;

                int affectedRows = context.Courses
                    .Where(c =>
                        c.IsPublished &&
                        c.Level == level)
                    .ExecuteUpdate(setters =>
                        setters.SetProperty(
                            c => c.Price,
                            c => c.Price * 1.10m));

                Console.WriteLine(
                    $"Bulk price raise affected {affectedRows} courses.");
            }

            static void BulkDeleteDroppedEnrollments()
            {
                using var context = new LearningContext();
                int affectedRows = context.Enrollments
                    .Where(e => e.Status == EnrollmentStatus.Dropped)
                    .ExecuteDelete();

                Console.WriteLine(
                    $"Bulk delete removed {affectedRows} enrollments.");
            }
        }
    }


