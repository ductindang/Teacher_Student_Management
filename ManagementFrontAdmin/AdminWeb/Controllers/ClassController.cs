using BLL.DTOs;
using BLL.IServices;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminWeb.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public ClassController(
            IClassService classService, 
            ICourseService courseService, 
            ITeacherService teacherService)
        {
            _classService = classService;
            _courseService = courseService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _classService.GetAllClasses();
            return View(classes);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = await _courseService.GetAllCourses();
            ViewBag.Teachers = await _teacherService.GetAllTeachers();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Class obj)
        {
            if (obj.EndDate <= obj.StartDate)
            {
                ModelState.AddModelError("EndDate", "Ngày kết thúc phải lớn hơn ngày bắt đầu");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Courses = await _courseService.GetAllCourses();
                ViewBag.Teachers = await _teacherService.GetAllTeachers();
                return View(obj);
            }
            string resultMessage = "Lỗi không thể thêm lớp học này";
            try
            {
                var classObj = await _classService.InsertClass(obj);
                if (classObj != null)
                {
                    TempData["Success"] = "Thêm mới lớp học thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View(classObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["Error"] = resultMessage;
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var classObj = await _classService.GetClassById(id);
            ViewBag.Courses = await _courseService.GetAllCourses();
            ViewBag.Teachers = await _teacherService.GetAllTeachers();
            if (classObj == null)
            {
                TempData["Error"] = "Đã xảy ra lỗi khi truy cập lớp học này";
                return RedirectToAction("Index");
            }
            return View(classObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Class obj)
        {
            string resultMessage = "Lỗi không thể sửa lớp học này";
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = await _courseService.GetAllCourses();
                ViewBag.Teachers = await _teacherService.GetAllTeachers();
                return View(obj);
            }
            try
            {
                var classObj = await _classService.UpdateClass(obj);
                if( classObj != null)
                {
                    TempData["Success"] = "Chỉnh sửa lớp học thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View(classObj);
            }
            catch(Exception ex)
            {
                TempData["Error"] = resultMessage;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resultMessage = "Xóa lớp học không thành công";
            try
            {
                var classObj = await _classService.DeleteClass(id);
                if(classObj != null)
                {
                    TempData["Success"] = "Xóa lớp học thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = resultMessage;
                return View("Error");
            }
        }
    }
}
