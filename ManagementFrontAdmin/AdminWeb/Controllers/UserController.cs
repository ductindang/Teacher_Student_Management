using AdminWeb.Models;
using BLL.DTOs;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AdminWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public PagedGetAllRequest GetPage()
        {
            PagedGetAllRequest pagedGetAllRequest = new PagedGetAllRequest
            {
                Offset = 0,
                Count = 1000
            };

            return pagedGetAllRequest;
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult SignIn()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckSignIn([FromForm] string email, [FromForm] string password)
        {
            try
            {
                var userCheck = await _userService.GetUserByEmailPass(email, password);
                if (userCheck != null)
                {
                    var userCheckJson = JsonConvert.SerializeObject(userCheck);
                    HttpContext.Session.SetString("UserLogin", userCheckJson);
                    return Ok("Login successful!");
                }
                return NotFound("Invalid email or password");
            }
            catch
            {
                return StatusCode(500, "System error. Please try again later");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmailExist([FromForm] string email)
        {
            var user = await _userService.GetUserByEmail(email);
            return Ok(user != null);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] User user)
        {
            try
            {
                var newUser = await _userService.InsertUser(user);
                if (newUser == null)
                {
                    return BadRequest("Create user failed");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Create user failed");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index(int offset = 0, int count = 1000)
        {
            //PagedGetAllRequest pagedGetAllRequest = new PagedGetAllRequest();
            //pagedGetAllRequest.Offset = offset;
            //pagedGetAllRequest.Count = count;
            
            var users = await _userService.GetAllUsers();

            ViewData["page"] = "user";
            ViewData["users"] = users;

            return View(users);
        }
    }
}
