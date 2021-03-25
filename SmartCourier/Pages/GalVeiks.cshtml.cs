using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartCourier.Pages
{
    public class GalVeiksModel : PageModel
    {
        public void OnGet()
        {
        }
        public void Labas ()
        {
            System.Diagnostics.Debug.WriteLine("duombaze suveike");
        }
    }
}
