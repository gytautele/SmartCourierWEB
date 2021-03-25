using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            System.Diagnostics.Debug.WriteLine("Paleido");
        }

        public IActionResult OnPost()
        {
            //čia išvedimas ar kodas
            System.Diagnostics.Debug.WriteLine("Funkcija");
            Database databaseObject = new Database();
            
            string username = Request.Form["email"];
            string password = Request.Form["Password"];
            System.Diagnostics.Debug.WriteLine(username);
            System.Diagnostics.Debug.WriteLine("LABUKAS");
            System.Diagnostics.Debug.WriteLine(password);
            databaseObject.OpenConnection();
            if (databaseObject.LogIn(username, password))
            {
                System.Diagnostics.Debug.WriteLine("duombaze suveike");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Nepraleido");
            }
            return null;
        }

        public void Button_Click()
        {
        }
    }

}
