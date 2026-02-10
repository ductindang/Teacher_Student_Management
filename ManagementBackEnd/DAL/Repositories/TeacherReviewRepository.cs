using DAL.Data;
using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TeacherReviewRepository : GenericRepository<TeacherReview>, ITeacherReviewRepository
    {
        private readonly AppDbContext _context;
        public TeacherReviewRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TeacherReview>> GetByTeacherId(int teacherId)
        {
            return await _context.TeachersReviews
                .Where(x => x.TeacherId == teacherId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        } 
    }
}
