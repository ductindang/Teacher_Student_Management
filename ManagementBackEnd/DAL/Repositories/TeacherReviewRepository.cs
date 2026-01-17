using DAL.Data;
using DAL.Models;
using DAL.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TeacherReviewRepository : GenericRepository<TeacherReview>, ITeacherReviewRepository
    {
        public TeacherReviewRepository(AppDbContext context) : base(context)
        {
        }
    }
}
