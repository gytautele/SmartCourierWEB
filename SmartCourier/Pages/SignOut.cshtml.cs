using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Text;
using System.Configuration;

namespace SmartCourier.Pages
{
    public class SignOutModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public SignOutModel(ILogger<PrivacyModel> logger)
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
            Globals.username = null;
            Response.Redirect("Index");
            return null;
        }

    }
}