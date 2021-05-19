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
using System.Data.SqlClient;

namespace SmartCourier.Pages
{
    public class ManagementModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public String YourText {get;set;}
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

        Database databaseObject = new Database();

        public IActionResult OnPost()
        {
            databaseObject.OpenConnection();
            string idData = Request.Form["dispatch_id_data"];
            System.Diagnostics.Debug.WriteLine("Data");
            var data = databaseObject.select();
            while (data.Read())
            {
                if (data.GetInt32(0) == Int32.Parse(idData))
                {
                    System.Diagnostics.Debug.WriteLine("ID: " + data.GetInt32(0) + " Time Chosen: " + data.GetInt32(2) + " Price: " + data.GetInt32(3) + " Status " + data.GetString(5));
                    Table();
                }
            }
            return null;
        }
        public void Table()
        {
            YourText = "Labas";
            System.Windows.Forms.MessageBox.Show("My message here");


            //    databaseObject.OpenConnection();
            //    var idData = Request.Form["html"];
            //    //Populating a DataTable from database.
            //    DataTable dt = databaseObject.GetData();

            //    //Building an HTML string.
            //    StringBuilder html = new StringBuilder();

            //    //Table start.
            //    html.Append("<table border = '1'>");

            //    //Building the Header row.
            //    html.Append("<tr>");
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        html.Append("<th>");
            //        html.Append(column.ColumnName);
            //        html.Append("</th>");
            //    }
            //    html.Append("</tr>");

            //    //Building the Data rows.
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        html.Append("<tr>");
            //        foreach (DataColumn column in dt.Columns)
            //        {
            //            html.Append("<td>");
            //            html.Append(row[column.ColumnName]);
            //            html.Append("</td>");
            //        }
            //        html.Append("</tr>");
            //    }

            //    //Table end.
            //    html.Append("</table>");

            //    //idData.Text = html;

            //    //Append the HTML string to Placeholder.
            //    //PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}