using BLL.DTOs;
using BLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IClassService
    {
        public Task<IEnumerable<ClassResponse>> GetAllClasses();
        public Task<Class> GetClassById(int id);
        public Task<Class> InsertClass(Class obj);
        public Task<Class> UpdateClass(Class obj);
        public Task<Class> DeleteClass(int id);
    }
}
