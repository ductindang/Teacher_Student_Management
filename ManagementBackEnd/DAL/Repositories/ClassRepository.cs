using DAL.Data;
using DAL.Models;
using DAL.Repositories.IRepository;
using DAL.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DAL.Repositories
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassResponse>> GetAllClassDetail()
        {
            var data = from c in _context.Classes
                       join course in _context.Courses on c.CourseId equals course.Id
                       join teacher in _context.Teachers on c.TeacherId equals teacher.Id
                       select new ClassResponse
                       {
                           Id = c.Id,
                           Name = c.Name,
                           CourseId = c.CourseId,
                           CourseName = course.Name,
                           TeacherId = c.TeacherId,
                           TeacherName = teacher.FullName,
                           StartDate = c.StartDate,
                           EndDate = c.EndDate,
                           MaxStudents = c.MaxStudents
                       };

            return await data.ToListAsync();
        }

        public async Task<ClassResponse> GetClassById(int id)
        {
            var data = await (from c in _context.Classes
                       where c.Id == id
                       join course in _context.Courses on c.CourseId equals course.Id
                       join teacher in _context.Teachers on c.TeacherId equals teacher.Id
                       select new ClassResponse
                       {
                           Id = c.Id,
                           Name = c.Name,
                           CourseId = c.CourseId,
                           CourseName = course.Name,
                           TeacherId = c.TeacherId,
                           TeacherName = teacher.FullName,
                           StartDate = c.StartDate,
                           EndDate = c.EndDate,
                           MaxStudents = c.MaxStudents
                       })
                       .FirstOrDefaultAsync();
            return data;
        }
    }
}
