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
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
