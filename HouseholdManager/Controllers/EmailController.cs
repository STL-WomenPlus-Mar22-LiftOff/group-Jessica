using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using static System.Net.WebRequestMethods;

namespace HouseholdManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail (string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("edison.reichel36@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("edison.reichel36@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("edison.reichel36@ethereal.email", "bZ6SBgVZ3zc89z2CUg");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
