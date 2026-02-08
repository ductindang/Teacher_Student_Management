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

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserById(id);
            if(user == null)
            {
                TempData["Error"] = "An error occured while accessing this user";
                return View("Error");
            }

            return View(user);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(User user)
        //{
        //    user.PasswordHash = user.PasswordHash ?? "";
        //    string resultMessage = "Cannot update this user";
        //    var userUpdate = await _userService.UpdateUser(user);
        //    if(userUpdate != null)
        //    {
        //        TempData["Success"] = "Update this user success";
        //        return RedirectToAction("Index");
        //    }

        //    TempData["Error"] = resultMessage;
        //    return View(user);
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            user.PasswordHash ??= "";

            var userUpdate = await _userService.UpdateUser(user);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                if (userUpdate != null)
                {
                    return Json(new
                    {
                        success = true,
                        message = "Update this user success"
                    });
                }

                return Json(new
                {
                    success = false,
                    message = "Cannot update this user"
                });
            }

            if (userUpdate != null)
            {
                TempData["Success"] = "Update this user success";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Cannot update this user";
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User request)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Dữ liệu không hợp lệ"
                });
            }

            var result = await _userService.InsertUser(request);

            if (result == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Không thể tạo tài khoản"
                });
            }

            return Json(new
            {
                success = true,
                message = "Tạo tài khoản thành công",
                userId = result.Id
            });
        }

    }
}
