using DAL.Models;
using DAL.Models.Enum;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<ClassImage> ClassImages { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TeacherReview> TeachersReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Lập trình C# cơ bản", Description = "Học lập trình C# từ cơ bản", Duration = 30, Price = 3000000, Status = ECourseStatus.Active },
                new Course { Id = 2, Name = "Lập trình C# nâng cao", Description = "Các kỹ thuật C# nâng cao", Duration = 45, Price = 5000000, Status = ECourseStatus.Active },
                new Course { Id = 3, Name = "Phát triển Web ASP.NET Core", Description = "Xây dựng Web API", Duration = 40, Price = 4500000, Status = ECourseStatus.Active },
                new Course { Id = 4, Name = "Cơ sở dữ liệu SQL Server", Description = "Quản lý và truy vấn dữ liệu", Duration = 25, Price = 2500000, Status = ECourseStatus.Active },
                new Course { Id = 5, Name = "Clean Architecture trong .NET", Description = "Thiết kế kiến trúc phần mềm", Duration = 20, Price = 4000000, Status = ECourseStatus.InActive }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, UserId = 0, FullName = "Nguyễn Văn An", Degree = "Thạc sĩ Công nghệ thông tin", Experience = 5 },
                new Teacher { Id = 2, UserId = 0, FullName = "Trần Thị Bích", Degree = "Tiến sĩ Khoa học máy tính", Experience = 8 },
                new Teacher { Id = 3, UserId = 0, FullName = "Lê Văn Cường", Degree = "Cử nhân Công nghệ thông tin", Experience = 3 },
                new Teacher { Id = 4, UserId = 0, FullName = "Phạm Thị Dung", Degree = "Thạc sĩ Hệ thống thông tin", Experience = 6 },
                new Teacher { Id = 5, UserId = 0, FullName = "Hoàng Văn Hiếu", Degree = "Tiến sĩ Công nghệ phần mềm", Experience = 10 }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, CourseId = 1, TeacherId = 1, Name = "C# cơ bản - Lớp sáng", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 2, 1), MaxStudents = 30, Description = "Lớp học cung cấp kiến thức cơ bản về lập trình C# bao gồm biến, kiểu dữ liệu, vòng lặp, câu lệnh điều kiện và các khái niệm lập trình hướng đối tượng." },

                new Class { Id = 2, CourseId = 2, TeacherId = 2, Name = "C# nâng cao - Lớp tối", StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 3, 1), MaxStudents = 25, Description = "Khóa học giúp học viên nâng cao kỹ năng lập trình với LINQ, async/await, dependency injection và các design pattern thường dùng." },

                new Class { Id = 3, CourseId = 3, TeacherId = 3, Name = "Lập trình Web ASP.NET Core", StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 3, 15), MaxStudents = 35, Description = "Học xây dựng ứng dụng web hiện đại với ASP.NET Core, MVC, Razor Pages và Web API." },

                new Class { Id = 4, CourseId = 4, TeacherId = 4, Name = "Quản trị SQL Server", StartDate = new DateTime(2025, 1, 5), EndDate = new DateTime(2025, 2, 5), MaxStudents = 40, Description = "Học thiết kế cơ sở dữ liệu, viết truy vấn SQL, sử dụng join, stored procedure và tối ưu truy vấn." },

                new Class { Id = 5, CourseId = 5, TeacherId = 5, Name = "Clean Architecture", StartDate = new DateTime(2025, 3, 1), EndDate = new DateTime(2025, 4, 1), MaxStudents = 20, Description = "Giới thiệu nguyên tắc Clean Architecture và cách áp dụng trong các dự án .NET thực tế." }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, UserId = 0, FullName = "Nguyễn Minh Đức", Gender = EGender.Male, Address = "Hà Nội", DateOfBirth = new DateTime(2000, 1, 1) },
                new Student { Id = 2, UserId = 0, FullName = "Trần Ngọc Anh", Gender = EGender.Female, Address = "TP Hồ Chí Minh", DateOfBirth = new DateTime(2001, 2, 2) },
                new Student { Id = 3, UserId = 0, FullName = "Lê Hoàng Nam", Gender = EGender.Male, Address = "Đà Nẵng", DateOfBirth = new DateTime(1999, 3, 3) },
                new Student { Id = 4, UserId = 0, FullName = "Phạm Thu Trang", Gender = EGender.Female, Address = "Huế", DateOfBirth = new DateTime(2002, 4, 4) },
                new Student { Id = 5, UserId = 0, FullName = "Đỗ Văn Phúc", Gender = EGender.Male, Address = "Cần Thơ", DateOfBirth = new DateTime(2000, 5, 5) }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, ClassId = 1, EnrollDate = new DateTime(2025, 1, 1), Status = EEnrollStatus.Active },
                new Enrollment { Id = 2, StudentId = 2, ClassId = 2, EnrollDate = new DateTime(2025, 1, 5), Status = EEnrollStatus.Active },
                new Enrollment { Id = 3, StudentId = 3, ClassId = 3, EnrollDate = new DateTime(2025, 2, 1), Status = EEnrollStatus.Cancel },
                new Enrollment { Id = 4, StudentId = 4, ClassId = 4, EnrollDate = new DateTime(2025, 1, 10), Status = EEnrollStatus.Active },
                new Enrollment { Id = 5, StudentId = 5, ClassId = 5, EnrollDate = new DateTime(2025, 3, 1), Status = EEnrollStatus.Active }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, StudentId = 1, ClassId = 1, Amount = 3000000, PaymentDate = new DateTime(2025, 1, 1), PaymentMethod = "Tiền mặt", Status = "Đã thanh toán" },
                new Payment { Id = 2, StudentId = 2, ClassId = 2, Amount = 5000000, PaymentDate = new DateTime(2025, 1, 6), PaymentMethod = "Chuyển khoản", Status = "Đã thanh toán" },
                new Payment { Id = 3, StudentId = 3, ClassId = 3, Amount = 4500000, PaymentDate = new DateTime(2025, 2, 2), PaymentMethod = "MoMo", Status = "Đã thanh toán" },
                new Payment { Id = 4, StudentId = 4, ClassId = 4, Amount = 2500000, PaymentDate = new DateTime(2025, 1, 12), PaymentMethod = "Tiền mặt", Status = "Đã thanh toán" },
                new Payment { Id = 5, StudentId = 5, ClassId = 5, Amount = 4000000, PaymentDate = new DateTime(2025, 3, 2), PaymentMethod = "Chuyển khoản", Status = "Chờ thanh toán" }
            );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = 1, ClassId = 1, DayOfWeek = EDateOfWeek.Monday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(10, 0, 0), Room = "A101" },
                new Schedule { Id = 2, ClassId = 2, DayOfWeek = EDateOfWeek.Tuesday, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(20, 0, 0), Room = "B202" },
                new Schedule { Id = 3, ClassId = 3, DayOfWeek = EDateOfWeek.Wednesday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), Room = "C303" },
                new Schedule { Id = 4, ClassId = 4, DayOfWeek = EDateOfWeek.Thursday, StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(16, 0, 0), Room = "D404" },
                new Schedule { Id = 5, ClassId = 5, DayOfWeek = EDateOfWeek.Friday, StartTime = new TimeSpan(19, 0, 0), EndTime = new TimeSpan(21, 0, 0), Room = "E505" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = ERoleName.Student },
                new Role { Id = 2, Name = ERoleName.Teacher },
                new Role { Id = 3, Name = ERoleName.Admin }
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
