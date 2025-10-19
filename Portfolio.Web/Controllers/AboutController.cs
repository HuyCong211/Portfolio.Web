using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Data;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var profile = _context.Profiles.FirstOrDefault();
            return View(profile);
        }
        public IActionResult DownloadCv(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return NotFound();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CV", fileName);
            if (!System.IO.File.Exists(path)) return NotFound();

            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/pdf", fileName);
        }
    }
}
