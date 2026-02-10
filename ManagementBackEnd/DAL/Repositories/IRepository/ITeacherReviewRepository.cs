using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepository
{
    public interface ITeacherReviewRepository : IGenericRepository<TeacherReview>
    {
        Task<List<TeacherReview>> GetByTeacherId(int teacherId);
    }
}
