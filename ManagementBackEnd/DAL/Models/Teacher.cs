using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public string FullName { get; set; }
        public string Degree { get; set; }
        public int Experience { get; set; }
    }
}
