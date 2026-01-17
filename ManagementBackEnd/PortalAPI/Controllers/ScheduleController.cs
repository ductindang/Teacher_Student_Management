using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepo;

        public ScheduleController(IScheduleRepository scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAll()
        {
            var schedules = await _scheduleRepo.GetAll();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetById(int id)
        {
            var scd = await _scheduleRepo.GetById(id);
            if (scd == null)
                return NotFound();
            return Ok(scd);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> Insert([FromBody] Schedule schedule)
        {
            schedule.Id = 0;
            try
            {
                var scd = await _scheduleRepo.Insert(schedule);
                return Ok(scd);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> Update(int id, [FromBody] Schedule schedule)
        {
            var scd = await _scheduleRepo.GetById(id);
            try
            {
                if (scd == null)
                {
                    return NotFound();
                }
                scd = schedule;
                scd.Id = id;
                var result = await _scheduleRepo.Update(scd);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> Delete(int id)
        {
            var scd = await _scheduleRepo.GetById(id);
            try
            {
                if (scd == null)
                    return NotFound();

                await _scheduleRepo.Delete(scd);
                return Ok(scd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
