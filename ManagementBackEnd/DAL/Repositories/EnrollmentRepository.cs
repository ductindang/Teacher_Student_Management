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

namespace DAL.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnrollmentResponse>> GetAllEnrollmentDetail()
        {
            var data = from e in _context.Enrollments
                       join student in _context.Students on e.StudentId equals student.Id
                       join classObj in _context.Classes on e.ClassId equals classObj.Id
                       select new EnrollmentResponse
                       {
                           Id = e.Id,
                           EnrollDate = e.EnrollDate,
                           Status = e.Status,
                           StudentId = student.Id,
                           StudentName = student.FullName,
                           ClassId = classObj.Id,
                           ClassName = classObj.Name
                       };
            return await data.ToListAsync();
        }
    }
}
