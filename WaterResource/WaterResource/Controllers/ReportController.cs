using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WaterResource.Models;

namespace WaterResource.Controllers
{
    public class ReportController : Controller
    {
        //  
        // GET: /Report/  

        public ActionResult Index(string reportName)
        //public ActionResult Index()
        {

            DataAccessBase base2 = new DataAccessBase();

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(90);
            reportViewer.Height = Unit.Percentage(90);
 
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"SSRSReports\" + reportName + ".rdl";

            DataSet ds = base2.ReaderSp(reportName);

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(reportName, ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}