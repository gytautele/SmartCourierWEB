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

        

        public void LogInButton(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Funkcija");
            Database databaseObject = new Database();
            string username = Request.Form["UserName"];
            string password = Request.Form["Password"];
            if (databaseObject.LogIn(username, password))
            {
                System.Diagnostics.Debug.WriteLine("duombaze suveike");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Nepraleido");
            }

        }

        public void Button_Click()
        {
            System.Diagnostics.Debug.WriteLine("eikit naxui visi");
        }
    }

}
