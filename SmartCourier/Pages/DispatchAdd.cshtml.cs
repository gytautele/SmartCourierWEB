using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class DispatchModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public DispatchModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (Globals.username == null)
            {
                Response.Redirect("Privacy");
            }
        }

        public IActionResult OnPost()
        {
            Database databaseObject = new Database();
            databaseObject.OpenConnection();
            string x = Request.Form["xCoordinates"];
            string y = Request.Form["yCoordinates"];
            string time = Request.Form["time"];
            string email = Request.Form["email"];

            databaseObject.addPackage(Int32.Parse(time), x, y, email);

            databaseObject.CloseConnection();

            return null;
        }
    }
}
