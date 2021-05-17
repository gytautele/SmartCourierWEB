using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class ForgotModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;

        public ForgotModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Database databaseObject = new Database();
            string email = Request.Form["email"];
            databaseObject.OpenConnection();
            var result = databaseObject.Remember(email);

            if (email != null)
            {
                if (result != null)
                {
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(Globals.email, Globals.password),
                        EnableSsl = true,
                    };
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(Globals.email),
                        Subject = "subject",
                        Body = "<h1>"+result["password"].ToString()+"</h1>",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(result["eMail"].ToString());

                    smtpClient.Send(mailMessage);

                    Response.Redirect("Privacy");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Netinkamas emailas");
                }
            }
            databaseObject.CloseConnection();

            return null;
        }
    }
}
