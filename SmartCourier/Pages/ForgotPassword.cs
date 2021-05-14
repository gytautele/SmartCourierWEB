using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class ManagementModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;

        public ManagementModel(ILogger<PrivacyModel> logger)
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
            string idData = Request.Form["dispatch_id_data"];
            System.Diagnostics.Debug.WriteLine("Data");
            var data = databaseObject.select();
            while (data.Read())
            {
                if (data.GetInt32(0) == Int32.Parse(idData))
                {
                    System.Diagnostics.Debug.WriteLine("ID: " + data.GetInt32(0) + " Time Chosen: " + data.GetInt32(2) + " Price: " + data.GetInt32(3) + " Status " + data.GetString(5));
                }
            }
            return null;
        }
    }
}
