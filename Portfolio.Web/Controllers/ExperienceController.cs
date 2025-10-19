using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Data;

namespace Portfolio.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly AppDbContext _context;

        public ExperienceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var work = _context.Experiences
                .Where(x => x.Type == "Work")
                .OrderByDescending(x => x.Id)
                .ToList();

            var education = _context.Experiences
                .Where(x => x.Type == "Education")
                .OrderByDescending(x => x.Id)
                .ToList();

            ViewBag.Work = work;
            ViewBag.Education = education;
            return View();
        }
    }
}
