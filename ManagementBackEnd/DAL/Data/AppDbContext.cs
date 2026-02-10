using DAL.Models;
using DAL.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TeacherReview> TeachersReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C# Basic", Description = "Learn C# basic", Duration = 30, Price = 3000000, Status = ECourseStatus.Active },
                new Course { Id = 2, Name = "C# Advanced", Description = "Advanced C#", Duration = 45, Price = 5000000, Status = ECourseStatus.Active },
                new Course { Id = 3, Name = "ASP.NET Core", Description = "Web API", Duration = 40, Price = 4500000, Status = ECourseStatus.Active },
                new Course { Id = 4, Name = "SQL Server", Description = "Database", Duration = 25, Price = 2500000, Status = ECourseStatus.Active },
                new Course { Id = 5, Name = "Clean Architecture", Description = "Best practice", Duration = 20, Price = 4000000, Status = ECourseStatus.InActive }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, UserId = 0, FullName = "Nguyen Van A", Degree = "Master", Experience = 5 },
                new Teacher { Id = 2, UserId = 0, FullName = "Tran Thi B", Degree = "PhD", Experience = 8 },
                new Teacher { Id = 3, UserId = 0, FullName = "Le Van C", Degree = "Bachelor", Experience = 3 },
                new Teacher { Id = 4, UserId = 0, FullName = "Pham Thi D", Degree = "Master", Experience = 6 },
                new Teacher { Id = 5, UserId = 0, FullName = "Hoang Van E", Degree = "PhD", Experience = 10 }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, CourseId = 1, TeacherId = 1, Name = "C# Basic - Morning", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 2, 1), MaxStudents = 30 },
                new Class { Id = 2, CourseId = 2, TeacherId = 2, Name = "C# Advanced - Evening", StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 3, 1), MaxStudents = 25 },
                new Class { Id = 3, CourseId = 3, TeacherId = 3, Name = "ASP.NET Core", StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 3, 15), MaxStudents = 35 },
                new Class { Id = 4, CourseId = 4, TeacherId = 4, Name = "SQL Server", StartDate = new DateTime(2025, 1, 5), EndDate = new DateTime(2025, 2, 5), MaxStudents = 40 },
                new Class { Id = 5, CourseId = 5, TeacherId = 5, Name = "Clean Architecture", StartDate = new DateTime(2025, 3, 1), EndDate = new DateTime(2025, 4, 1), MaxStudents = 20 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, UserId = 0, FullName = "Student One", Gender = EGender.Male, Address = "Ha Noi", DateOfBirth = new DateTime(2000, 1, 1) },
                new Student { Id = 2, UserId = 0, FullName = "Student Two", Gender = EGender.Female, Address = "HCM", DateOfBirth = new DateTime(2001, 2, 2) },
                new Student { Id = 3, UserId = 0, FullName = "Student Three", Gender = EGender.Male, Address = "Da Nang", DateOfBirth = new DateTime(1999, 3, 3) },
                new Student { Id = 4, UserId = 0, FullName = "Student Four", Gender = EGender.Female, Address = "Hue", DateOfBirth = new DateTime(2002, 4, 4) },
                new Student { Id = 5, UserId = 0, FullName = "Student Five", Gender = EGender.Male, Address = "Can Tho", DateOfBirth = new DateTime(2000, 5, 5) }
            );


            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, ClassId = 1, EnrollDate = new DateTime(2025, 1, 1), Status = EEnrollStatus.Active },
                new Enrollment { Id = 2, StudentId = 2, ClassId = 2, EnrollDate = new DateTime(2025, 1, 5), Status = EEnrollStatus.Active },
                new Enrollment { Id = 3, StudentId = 3, ClassId = 3, EnrollDate = new DateTime(2025, 2, 1), Status = EEnrollStatus.Cancel },
                new Enrollment { Id = 4, StudentId = 4, ClassId = 4, EnrollDate = new DateTime(2025, 1, 10), Status = EEnrollStatus.Active },
                new Enrollment { Id = 5, StudentId = 5, ClassId = 5, EnrollDate = new DateTime(2025, 3, 1), Status = EEnrollStatus.Active }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, StudentId = 1, ClassId = 1, Amount = 3000000, PaymentDate = new DateTime(2025, 1, 1), PaymentMethod = "Cash", Status = "Paid" },
                new Payment { Id = 2, StudentId = 2, ClassId = 2, Amount = 5000000, PaymentDate = new DateTime(2025, 1, 6), PaymentMethod = "Banking", Status = "Paid" },
                new Payment { Id = 3, StudentId = 3, ClassId = 3, Amount = 4500000, PaymentDate = new DateTime(2025, 2, 2), PaymentMethod = "Momo", Status = "Paid" },
                new Payment { Id = 4, StudentId = 4, ClassId = 4, Amount = 2500000, PaymentDate = new DateTime(2025, 1, 12), PaymentMethod = "Cash", Status = "Paid" },
                new Payment { Id = 5, StudentId = 5, ClassId = 5, Amount = 4000000, PaymentDate = new DateTime(2025, 3, 2), PaymentMethod = "Banking", Status = "Pending" }
            );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = 1, ClassId = 1, DayOfWeek = EDateOfWeek.Monday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(10, 0, 0), Room = "A101" },
                new Schedule { Id = 2, ClassId = 2, DayOfWeek = EDateOfWeek.Tuesday, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(20, 0, 0), Room = "B202" },
                new Schedule { Id = 3, ClassId = 3, DayOfWeek = EDateOfWeek.Wednesday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), Room = "C303" },
                new Schedule { Id = 4, ClassId = 4, DayOfWeek = EDateOfWeek.Thursday, StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(16, 0, 0), Room = "D404" },
                new Schedule { Id = 5, ClassId = 5, DayOfWeek = EDateOfWeek.Friday, StartTime = new TimeSpan(19, 0, 0), EndTime = new TimeSpan(21, 0, 0), Room = "E505" }
            );

            modelBuilder.Entity<TeacherReview>().HasData(
                new TeacherReview { Id = 1, TeacherId = 1, StudentId = 1, ClassId = 1, Rating = 5, Comment = "Teacher is very dedicated", CreatedAt = new DateTime(2025, 2, 1, 9, 15, 0) },
                new TeacherReview { Id = 2, TeacherId = 1, StudentId = 2, ClassId = 1, Rating = 4, Comment = "Easy to understand", CreatedAt = new DateTime(2025, 2, 2, 10, 30, 0) },
                new TeacherReview { Id = 3, TeacherId = 1, StudentId = 3, ClassId = 1, Rating = 5, Comment = "Very friendly teacher", CreatedAt = new DateTime(2025, 2, 3, 14, 45, 0) },

                new TeacherReview { Id = 4, TeacherId = 2, StudentId = 1, ClassId = 2, Rating = 4, Comment = "Good teaching method", CreatedAt = new DateTime(2025, 2, 4, 8, 20, 0) },
                new TeacherReview { Id = 5, TeacherId = 2, StudentId = 2, ClassId = 2, Rating = 5, Comment = "Very professional", CreatedAt = new DateTime(2025, 2, 5, 13, 10, 0) },
                new TeacherReview { Id = 6, TeacherId = 2, StudentId = 3, ClassId = 2, Rating = 4, Comment = "Clear explanation", CreatedAt = new DateTime(2025, 2, 6, 16, 0, 0) },

                new TeacherReview { Id = 7, TeacherId = 3, StudentId = 1, ClassId = 3, Rating = 5, Comment = "Helpful and patient", CreatedAt = new DateTime(2025, 2, 7, 9, 0, 0) },
                new TeacherReview { Id = 8, TeacherId = 3, StudentId = 4, ClassId = 3, Rating = 4, Comment = "Good class structure", CreatedAt = new DateTime(2025, 2, 8, 11, 25, 0) },
                new TeacherReview { Id = 9, TeacherId = 3, StudentId = 5, ClassId = 3, Rating = 5, Comment = "Excellent knowledge", CreatedAt = new DateTime(2025, 2, 9, 15, 40, 0) },

                new TeacherReview { Id = 10, TeacherId = 4, StudentId = 2, ClassId = 4, Rating = 4, Comment = "Nice teaching style", CreatedAt = new DateTime(2025, 2, 10, 10, 5, 0) },
                new TeacherReview { Id = 11, TeacherId = 4, StudentId = 3, ClassId = 4, Rating = 5, Comment = "Very supportive", CreatedAt = new DateTime(2025, 2, 11, 14, 30, 0) },
                new TeacherReview { Id = 12, TeacherId = 4, StudentId = 4, ClassId = 4, Rating = 4, Comment = "Good interaction", CreatedAt = new DateTime(2025, 2, 12, 17, 15, 0) },

                new TeacherReview { Id = 13, TeacherId = 5, StudentId = 1, ClassId = 5, Rating = 5, Comment = "Great experience", CreatedAt = new DateTime(2025, 2, 13, 9, 50, 0) },
                new TeacherReview { Id = 14, TeacherId = 5, StudentId = 4, ClassId = 5, Rating = 4, Comment = "Well organized class", CreatedAt = new DateTime(2025, 2, 14, 13, 35, 0) },
                new TeacherReview { Id = 15, TeacherId = 5, StudentId = 5, ClassId = 5, Rating = 5, Comment = "Highly recommended", CreatedAt = new DateTime(2025, 2, 15, 18, 0, 0) }
            );


            modelBuilder.Entity<Course>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
