using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class PrivacyModel : PageModel
    {
        Database databaseObject = new Database();
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (Globals.username != null)
            {
                Response.Redirect("Index");
            }
        }

        public IActionResult OnPost()
        {
            System.Diagnostics.Debug.WriteLine("Ka?");
            //čia išvedimas ar kodas
            databaseObject.OpenConnection();
            string username = Request.Form["email"];
            string password = Request.Form["Password"];
            Globals.username = username;

            if (username != null)
            {
                if (databaseObject.LogIn(username, password))
                {
                    //databaseObject.update("True", Globals.username);
                    Response.Redirect("Management");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Nepraleido");
                }
            }
            databaseObject.CloseConnection();
            return null;
        }
    }
}
