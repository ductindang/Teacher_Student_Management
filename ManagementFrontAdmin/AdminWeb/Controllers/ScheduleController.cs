using BLL.DTOs;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AdminWeb.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await _scheduleService.GetAllSchedules();
            return View(schedules);
        }

        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await _scheduleService.GetScheduleById(id);
            return Ok(schedule);
        }

        public async Task<IActionResult> GetByClass(int classId)
        {
            var schedules = await _scheduleService.GetByClass(classId);
            return Ok(schedules);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Schedule obj)
        {
            string resultMessage = "Lỗi không thể thêm lịch học này";
            try
            {
                var schedule = await _scheduleService.InsertSchedule(obj);
                if (schedule != null)
                {
                    TempData["Success"] = "Thêm mới lịch học thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View(schedule);
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
            var schedule = await _scheduleService.GetScheduleById(id);
            if (schedule == null)
            {
                TempData["Error"] = "Đã xảy ra lỗi khi truy cập lịch học này";
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Schedule obj)
        {
            string resultMessage = "Lỗi không thể sửa lịch học này";
            try
            {
                var schedule = await _scheduleService.UpdateSchedule(obj);
                if (schedule != null)
                {
                    TempData["Success"] = "Chỉnh sửa lịch học thành công";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = resultMessage;
                return View(schedule);
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
            var resultMessage = "Xóa lịch học không thành công";
            try
            {
                var schedule = await _scheduleService.DeleteSchedule(id);
                if (schedule != null)
                {
                    TempData["Success"] = "Xóa lịch học thành công";
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
