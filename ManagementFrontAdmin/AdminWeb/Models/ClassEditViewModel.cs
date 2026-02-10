using BLL.DTOs;
using BLL.Response;

namespace AdminWeb.Models
{
    public class ClassEditViewModel
    {
        public Class Class { get; set; }
        public IEnumerable<StudentEnrollmentRequest> Students { get; set; }
    }
}
