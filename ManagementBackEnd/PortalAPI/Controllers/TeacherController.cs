using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;

        public TeacherController(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            var teachers = await _teacherRepo.GetAll();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetById(int id)
        {
            var tec = await _teacherRepo.GetById(id);
            if (tec == null)
                return NotFound();
            return Ok(tec);
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> Insert([FromBody] Teacher teacher)
        {
            teacher.Id = 0;
            try
            {
                var tec = await _teacherRepo.Insert(teacher);
                return Ok(tec);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> Update(int id, [FromBody] Teacher teacher)
        {
            var tec = await _teacherRepo.GetById(id);
            try
            {
                if (tec == null)
                {
                    return NotFound();
                }
                tec = teacher;
                tec.Id = id;
                var result = await _teacherRepo.Update(tec);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> Delete(int id)
        {
            var tec = await _teacherRepo.GetById(id);
            try
            {
                if (tec == null)
                    return NotFound();

                await _teacherRepo.Delete(tec);
                return Ok(tec);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
