using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepo;

        public AttendanceController(IAttendanceRepository attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }
        // GET: api/<AttendanceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendances()
        {
            var attendances = await _attendanceRepo.GetAll();
            return Ok(attendances);
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
        {
            var att = await _attendanceRepo.GetById(id);
            if (att == null)
                return NotFound();
            return Ok(att);
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task<ActionResult<Attendance>> InsertAttendance([FromBody] Attendance attendance)
        {
            attendance.Id = 0;
            try
            {
                var att = await _attendanceRepo.Insert(attendance);
                return Ok(att);
            } catch (Exception ex) {
                return BadRequest(error: ex.Message);
            }
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Attendance>> Update(int id, [FromBody] Attendance attendance)
        {
            var att = await _attendanceRepo.GetById(id);
            try
            {
                if (att == null)
                {
                    return NotFound();
                }
                att = attendance;
                att.Id = id;
                var result = await _attendanceRepo.Update(att);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
            
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Attendance>> Delete(int id)
        {
            var att = await _attendanceRepo.GetById(id);
            try
            {
                if (att == null)
                    return NotFound();

                await _attendanceRepo.Delete(att);
                return Ok(att);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
