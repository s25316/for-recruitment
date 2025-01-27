using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace SimpleApp14__smtp_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleMessagesController : ControllerBase
    {
        private readonly string _email = "";
        private readonly string _password = "";// Even AppPassword


        [HttpPost("app")]
        public IActionResult Post2
            (
            [EmailAddress] string toEmail = "odbiorca_email@gmail.com",
            string subject = "Temat wiadomości",
            string body = "Treść wiadomości"
            )
        {
            try
            {
                MailMessage mail = new MailMessage(_email, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Jeśli chcesz wysłać wiadomość w formacie HTML
                };

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(_email, _password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

                return Ok("E-mail został wysłany pomyślnie.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
