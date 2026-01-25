using BLL.DTOs;
using BLL.IServices;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminWeb.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllTeachers();
            return View(teachers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher obj)
        {
            string resultMessage = "Lỗi không thể thêm giáo viên này";
            try
            {
                var teacher = await _teacherService.InsertTeacher(obj);
                if (teacher != null)
                {
                    TempData["Success"] = "Thêm mới giáo viên thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View(teacher);
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
            var teacher = await _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                TempData["Error"] = "Đã xảy ra lỗi khi truy cập giáo viên này";
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher obj)
        {
            string resultMessage = "Lỗi không thể sửa giáo viên này";
            try
            {
                var teacher = await _teacherService.UpdateTeacher(obj);
                if (teacher != null)
                {
                    TempData["Success"] = "Chỉnh sửa giáo viên thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View(teacher);
            }
            catch (Exception ex)
            {
                TempData["Error"] = resultMessage;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resultMessage = "Xóa giáo viên không thành công";
            try
            {
                var teacher = await _teacherService.DeleteTeacher(id);
                if (teacher != null)
                {
                    TempData["Success"] = "Xóa giáo viên thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = resultMessage;
                return View();
            }
        }
    }
}
