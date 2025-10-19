using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Models;
using System.Diagnostics;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["FullName"] = "Nguyễn Huy Công";
            ViewData["Profession"] = "Web Developer (.NET Core)";
            ViewData["Goal"] = "Mục tiêu: Trở thành lập trình viên web chuyên nghiệp, xây dựng ứng dụng .NET Core tối ưu, bảo mật và dễ mở rộng.";
            // Dữ liệu cho các phần
            ViewData["Profile"] = _context.Profiles.FirstOrDefault();
            // ✅ Thêm tách riêng Work và Education cho Experience
            var experiences = _context.Experiences.ToList();
            ViewBag.Work = experiences.Where(e => e.Type == "Work").ToList();
            ViewBag.Education = experiences.Where(e => e.Type == "Education").ToList();
            ViewData["Projects"] = _context.Projects.ToList();
            ViewData["TechnicalSkills"] = _context.Skills.Where(s => s.Category == "Technical").ToList();
            ViewData["SoftSkills"] = _context.Skills.Where(s => s.Category == "Soft").ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
