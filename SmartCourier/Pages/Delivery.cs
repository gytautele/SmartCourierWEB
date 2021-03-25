using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class PrivacyModel1 : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel1(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        protected void LogInButton(object sender, EventArgs e)
        {
            string username = Request.Form["UserName"];
            string password = Request.Form["Password"];
            System.Diagnostics.Debug.WriteLine("duombaze suveike");
        }

        public void OnGet()
        {
        }
    }
}
