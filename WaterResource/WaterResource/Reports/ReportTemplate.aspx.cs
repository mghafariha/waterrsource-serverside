using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterResource.Reports
{
    public partial class ReportTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //try
                //{
                //    String reportFolder = System.Configuration.ConfigurationManager.AppSettings["SSRSReports"].ToString();

                //    rvSiteMapping.Height = Unit.Pixel(800);
                //    rvSiteMapping.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

                //    rvSiteMapping.ServerReport.ReportServerUrl = new Uri("http://172.16.33.252"); // Add the Reporting Server URL  
                //    rvSiteMapping.ServerReport.ReportPath = String.Format("/{0}/{1}", reportFolder, "Table18.rdl");

                //    rvSiteMapping.ServerReport.Refresh();
                //}
                //catch (Exception ex)
                //{

                //}
            }  
        }
    }
}