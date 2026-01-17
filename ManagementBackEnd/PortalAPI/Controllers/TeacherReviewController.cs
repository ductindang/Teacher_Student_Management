using DAL.Models;
using DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherReviewController : ControllerBase
    {
        private readonly ITeacherReviewRepository _reviewRepo;

        public TeacherReviewController(ITeacherReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherReview>>> GetAll()
        {
            var rev = await _reviewRepo.GetAll();
            return Ok(rev);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReview>> GetById(int id)
        {
            var rev = await _reviewRepo.GetById(id);
            if (rev == null)
                return NotFound();
            return Ok(rev);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherReview>> Insert([FromBody] TeacherReview review)
        {
            review.Id = 0;
            try
            {
                var rev = await _reviewRepo.Insert(review);
                return Ok(rev);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherReview>> Update(int id, [FromBody] TeacherReview review)
        {
            var rev = await _reviewRepo.GetById(id);
            try
            {
                if (rev == null)
                {
                    return NotFound();
                }
                rev = review;
                rev.Id = id;
                var result = await _reviewRepo.Update(rev);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> Delete(int id)
        {
            var rev = await _reviewRepo.GetById(id);
            try
            {
                if (rev == null)
                    return NotFound();

                await _reviewRepo.Delete(rev);
                return Ok(rev);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
