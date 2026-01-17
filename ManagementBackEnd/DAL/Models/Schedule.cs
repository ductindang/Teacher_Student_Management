using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public DateTime StudyDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room {  get; set; }
    }
}
