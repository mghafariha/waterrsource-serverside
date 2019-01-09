<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportTemplate.aspx.cs" Inherits="WaterResource.Reports.ReportTemplate" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>ASPXView</title>
</head>
<body>
    <div>
        <script runat="server">
            private void Page_Load(object sender, System.EventArgs e)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/SSRSReports/Table18.rdlc");
                ReportViewer1.LocalReport.Refresh();
            }
        </script>
        <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">          
        </asp:ScriptManager>
        <rsweb:reportviewer id="ReportViewer1" runat="server" height="80%" width="80%" AsyncRendering="false"></rsweb:reportviewer>
        </form>        
    </div>
</body>
</html>