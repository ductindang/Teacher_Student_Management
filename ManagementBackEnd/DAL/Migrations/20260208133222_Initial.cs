using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    EnrollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "CourseId", "EndDate", "MaxStudents", "Name", "StartDate", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "C# Basic - Morning", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "C# Advanced - Evening", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "ASP.NET Core", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, "SQL Server", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Clean Architecture", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Description", "Duration", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, "Learn C# basic", 30, "C# Basic", 3000000m, 1 },
                    { 2, "Advanced C#", 45, "C# Advanced", 5000000m, 1 },
                    { 3, "Web API", 40, "ASP.NET Core", 4500000m, 1 },
                    { 4, "Database", 25, "SQL Server", 2500000m, 1 },
                    { 5, "Best practice", 20, "Clean Architecture", 4000000m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "Id", "ClassId", "EnrollDate", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 3, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, 4, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, 5, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Amount", "ClassId", "PaymentDate", "PaymentMethod", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, 3000000m, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 1 },
                    { 2, 5000000m, 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banking", "Paid", 2 },
                    { 3, 4500000m, 3, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Momo", "Paid", 3 },
                    { 4, 2500000m, 4, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 4 },
                    { 5, 4000000m, 5, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banking", "Pending", 5 }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "ClassId", "DayOfWeek", "EndTime", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 10, 0, 0, 0), "A101", new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, 2, 2, new TimeSpan(0, 20, 0, 0, 0), "B202", new TimeSpan(0, 18, 0, 0, 0) },
                    { 3, 3, 3, new TimeSpan(0, 11, 0, 0, 0), "C303", new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, 4, 4, new TimeSpan(0, 16, 0, 0, 0), "D404", new TimeSpan(0, 14, 0, 0, 0) },
                    { 5, 5, 5, new TimeSpan(0, 21, 0, 0, 0), "E505", new TimeSpan(0, 19, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Address", "DateOfBirth", "FullName", "Gender", "UserId" },
                values: new object[,]
                {
                    { 1, "Ha Noi", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student One", 0, 0 },
                    { 2, "HCM", new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Two", 1, 0 },
                    { 3, "Da Nang", new DateTime(1999, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Three", 0, 0 },
                    { 4, "Hue", new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Four", 1, 0 },
                    { 5, "Can Tho", new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Five", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Degree", "Experience", "FullName", "UserId" },
                values: new object[,]
                {
                    { 1, "Master", 5, "Nguyen Van A", 0 },
                    { 2, "PhD", 8, "Tran Thi B", 0 },
                    { 3, "Bachelor", 3, "Le Van C", 0 },
                    { 4, "Master", 6, "Pham Thi D", 0 },
                    { 5, "PhD", 10, "Hoang Van E", 0 }
                });

            migrationBuilder.InsertData(
                table: "TeacherReview",
                columns: new[] { "Id", "ClassId", "Comment", "CreatedAt", "Rating", "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, "Teacher is very dedicated", new DateTime(2025, 2, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 2, 1, "Easy to understand", new DateTime(2025, 2, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 4, 2, 1 },
                    { 3, 1, "Very friendly teacher", new DateTime(2025, 2, 3, 14, 45, 0, 0, DateTimeKind.Unspecified), 5, 3, 1 },
                    { 4, 2, "Good teaching method", new DateTime(2025, 2, 4, 8, 20, 0, 0, DateTimeKind.Unspecified), 4, 1, 2 },
                    { 5, 2, "Very professional", new DateTime(2025, 2, 5, 13, 10, 0, 0, DateTimeKind.Unspecified), 5, 2, 2 },
                    { 6, 2, "Clear explanation", new DateTime(2025, 2, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 7, 3, "Helpful and patient", new DateTime(2025, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 3 },
                    { 8, 3, "Good class structure", new DateTime(2025, 2, 8, 11, 25, 0, 0, DateTimeKind.Unspecified), 4, 4, 3 },
                    { 9, 3, "Excellent knowledge", new DateTime(2025, 2, 9, 15, 40, 0, 0, DateTimeKind.Unspecified), 5, 5, 3 },
                    { 10, 4, "Nice teaching style", new DateTime(2025, 2, 10, 10, 5, 0, 0, DateTimeKind.Unspecified), 4, 2, 4 },
                    { 11, 4, "Very supportive", new DateTime(2025, 2, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), 5, 3, 4 },
                    { 12, 4, "Good interaction", new DateTime(2025, 2, 12, 17, 15, 0, 0, DateTimeKind.Unspecified), 4, 4, 4 },
                    { 13, 5, "Great experience", new DateTime(2025, 2, 13, 9, 50, 0, 0, DateTimeKind.Unspecified), 5, 1, 5 },
                    { 14, 5, "Well organized class", new DateTime(2025, 2, 14, 13, 35, 0, 0, DateTimeKind.Unspecified), 4, 4, 5 },
                    { 15, 5, "Highly recommended", new DateTime(2025, 2, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "TeacherReview");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
