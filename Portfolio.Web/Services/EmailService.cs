using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Portfolio.Web.Services
{
    public class EmailService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;
        private readonly string? _toEmail;

        public EmailService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["RESEND_API_KEY"];
            _toEmail = configuration["TO_EMAIL"];
        }

        public async Task SendEmailAsync(string name, string fromEmail, string message)
        {
            if (string.IsNullOrEmpty(_apiKey) || string.IsNullOrEmpty(_toEmail))
                throw new InvalidOperationException("Missing RESEND_API_KEY or TO_EMAIL in environment variables.");

            var email = new
            {
                from = "Portfolio Contact <onboarding@resend.dev>",
                to = new[] { _toEmail },
                subject = $"📩 New message from {name}",
                html = $"<p><b>Name:</b> {name}</p><p><b>Email:</b> {fromEmail}</p><p>{message}</p>"
            };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            var response = await _httpClient.PostAsJsonAsync("https://api.resend.com/emails", email);

            response.EnsureSuccessStatusCode();
        }
    }
}
