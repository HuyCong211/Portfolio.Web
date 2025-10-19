using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portfolio.Web.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string name, string fromEmail, string message)
        {
            try
            {
                var settings = _config.GetSection("EmailSettings");

                string smtpServer = settings["SmtpServer"] ?? throw new InvalidOperationException("Missing EmailSettings:SmtpServer");
                string portStr = settings["Port"] ?? "587";
                string username = settings["Username"] ?? throw new InvalidOperationException("Missing EmailSettings:Username");
                string password = settings["Password"] ?? throw new InvalidOperationException("Missing EmailSettings:Password");
                string toEmail = settings["ToEmail"] ?? username;
                string fromName = settings["FromName"] ?? "Portfolio Contact";

                if (!int.TryParse(portStr, out int port))
                    port = 587;

                using var client = new SmtpClient(smtpServer, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };

                string subject = $"Liên hệ mới từ {name}";
                string body = $"<b>Tên:</b> {name}<br><b>Email:</b> {fromEmail}<br><b>Nội dung:</b><br>{message}";

                using var mail = new MailMessage
                {
                    From = new MailAddress(username, fromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mail.To.Add(toEmail);

                await client.SendMailAsync(mail);
                Console.WriteLine("✅ Email đã gửi thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi gửi mail: {ex.Message}");
                throw;
            }
        }
    }
}
