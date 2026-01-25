using DAL.Models;
using DAL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepository
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        public Task<IEnumerable<ClassResponse>> GetAllClassDetail();
    }
}
