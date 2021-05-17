using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCourier.Pages
{
    public class DeliveryModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public DeliveryModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if(Globals.username == null)
            {
                Response.Redirect("Privacy");
            }
        }

        public IActionResult OnPost()
        {
            Database databaseObject = new Database();
            databaseObject.OpenConnection();
            string idMap = Request.Form["dispatch_id"];
            System.Diagnostics.Debug.WriteLine("Data");
            var data = databaseObject.select();
            double x = 0;
            double y = 0;
            while (data.Read())
            {
                //if (data.GetInt32(0) == Int32.Parse(idMap))
                {
                    x = data.GetDouble(6);
                    y = data.GetDouble(7);
                }
            }
            
            System.Diagnostics.Debug.WriteLine(x + " " + y);
            databaseObject.CloseConnection();
            return null;
        }
    }
}
