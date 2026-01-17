using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepo;

        public ClassController(IClassRepository classRepo)
        {
            _classRepo = classRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetAll()
        {
            var classes= await _classRepo.GetAll();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetById(int id)
        {
            var cls = await _classRepo.GetById(id);
            if (cls == null)
                return NotFound();
            return Ok(cls);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> Insert([FromBody] Class classObj)
        {
            classObj.Id = 0;
            try
            {
                var cls = await _classRepo.Insert(classObj);
                return Ok(cls);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Class>> Update(int id, [FromBody] Class classObj)
        {
            var cls = await _classRepo.GetById(id);
            try
            {
                if (cls == null)
                {
                    return NotFound();
                }
                cls = classObj;
                cls.Id = id;
                var result = await _classRepo.Update(cls);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> Delete(int id)
        {
            var cls = await _classRepo.GetById(id);
            try
            {
                if (cls == null)
                    return NotFound();

                await _classRepo.Delete(cls);
                return Ok(cls);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
