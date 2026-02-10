using DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Response
{
    public class StudentEnrollmentResponse
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public EGender Gender { get; set; }
        public DateTime EnrollDate { get; set; }
        public EEnrollStatus EnrollStatus { get; set; }

    }
}
