using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Data;

namespace Portfolio.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var projects = _context.Projects.OrderByDescending(p => p.Id).ToList();
            return View(projects);
        }
    }
}
