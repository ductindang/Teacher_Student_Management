using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _studentRepo.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var std = await _studentRepo.GetById(id);
            if (std == null)
                return NotFound();
            return Ok(std);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Insert([FromBody] Student student)
        {
            student.Id = 0;
            try
            {
                var std = await _studentRepo.Insert(student);
                return Ok(std);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Update(int id, [FromBody] Student student)
        {
            var std = await _studentRepo.GetById(id);
            try
            {
                if (std == null)
                {
                    return NotFound();
                }
                std = student;
                std.Id = id;
                var result = await _studentRepo.Update(std);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var std = await _studentRepo.GetById(id);
            try
            {
                if (std == null)
                    return NotFound();

                await _studentRepo.Delete(std);
                return Ok(std);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
