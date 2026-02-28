using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ITeacherReviewService
    {
        public Task<IEnumerable<TeacherReview>> GetAllTeacherReviews();
        public Task<TeacherReview> GetTeacherReviewById(int id);
        public Task<IEnumerable<TeacherReview>> GetByTeacher(int teacherId);
        public Task<TeacherReview> InsertTeacherReview(TeacherReview obj);
        public Task<TeacherReview> UpdateTeacherReview(TeacherReview obj);
        public Task<TeacherReview> DeleteTeacherReview(int id);
    }
}
