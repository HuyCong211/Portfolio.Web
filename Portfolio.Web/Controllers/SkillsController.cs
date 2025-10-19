using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Data;

namespace Portfolio.Web.Controllers
{
    public class SkillsController : Controller
    {
        private readonly AppDbContext _context;

        public SkillsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var technical = _context.Skills.Where(s => s.Category == "Technical").ToList();
            var soft = _context.Skills.Where(s => s.Category == "Soft").ToList();

            ViewBag.TechnicalSkills = technical;
            ViewBag.SoftSkills = soft;

            return View();
        }
    }
}
