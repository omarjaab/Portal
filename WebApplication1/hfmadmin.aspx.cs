using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Portal
{
    public partial class hfmadmin : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        DataTable dt = new DataTable(); // declearing dt as a global variable.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CreateDropDownList();
            }
            if (Controllers.login.data != null)
            {
                Controllers.login.ConstructNavigator(Navigator);
            }
            else { Response.Redirect("Logon.aspx"); }
            //DropDownSelectYear();
            //DropDownSelectMounth();
        }
        private void CreateDropDownList()
        {
            DropDownList DropDownDivision = new DropDownList();
            DropDownDivision.ID = "DropDownDivision";
            DropDownDivision.DataSource = dp.getHFMAdminitrationDivision();
            DropDownDivision.DataTextField = "Division descr";
            DropDownDivision.DataValueField = "Sort_order";
            DropDownDivision.DataBind();
            DropDownDivision.CssClass = "selectpicker";
            DropDownDivision.Attributes.Add("data-live-search", "true");
            DropDownDivisionPlace.Controls.Add(DropDownDivision);
            // ddl years 
            DropDownList DropDownYear = new DropDownList();
            DropDownYear.ID = "DropDownYear";
            for (int i = 2006; i < 2023; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                DropDownYear.Items.Add(li);
            }
            DropDownYear.CssClass = "selectpicker";
            DropDownYear.Attributes.Add("data-live-search", "true");
            DropDownYearPlace.Controls.Add(DropDownYear);
            // ddl months 
            DropDownList DropDownMounth = new DropDownList();
            DropDownMounth.ID = "DropDownMounth";
            var months = new CultureInfo("SV").DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)
            {
                ListItem li = new ListItem(months[i], (i + 1).ToString());
                DropDownMounth.Items.Add(li);
            }
            DropDownMounth.CssClass = "selectpicker";
            DropDownMounth.Attributes.Add("data-live-search", "true");
            DropDownMounthPlace.Controls.Add(DropDownMounth);
        }
    }
}