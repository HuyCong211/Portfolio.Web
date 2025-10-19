using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Data;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public ContactController(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                // Lưu vào database
                _context.ContactMessages.Add(model);
                await _context.SaveChangesAsync();

                // Gửi email thật
                await _emailService.SendEmailAsync(model.Name, model.Email, model.Message);

                ViewBag.Success = "✅ Cảm ơn bạn! Tin nhắn đã được gửi và lưu thành công 🎉";
                ModelState.Clear();
            }
            return View();
        }
        [Route("test-mail")]
        public async Task<IActionResult> TestMail()
        {
            await _emailService.SendEmailAsync("Test User", "test@example.com", "Đây là mail test gửi từ ASP.NET Core");
            return Content("Đã thử gửi mail. Kiểm tra hộp thư đến.");
        }
    }
}
