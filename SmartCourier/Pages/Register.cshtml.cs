using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class RegisterhModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public RegisterhModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Database databaseObject = new Database();
            databaseObject.OpenConnection();
            string country = Request.Form["country"];
            string address = Request.Form["address"];
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];
            string email = Request.Form["email"];
            string postal = Request.Form["postal"];
            string password = Request.Form["password"];

            databaseObject.Register(email, password);
            databaseObject.insertUser(firstName, lastName, address, postal, country);

            databaseObject.CloseConnection();
            Response.Redirect("Privacy");
            return null;
        }
    }
}
