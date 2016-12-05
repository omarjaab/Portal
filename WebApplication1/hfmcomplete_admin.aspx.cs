using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class hfmcomplete_admin : System.Web.UI.Page
    {
        Portal.Controllers.DefaultController dp = new Portal.Controllers.DefaultController();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateDropDown();
            VersionDropDownList();
            DivisionDropDownList();
        }

        private void VersionDropDownList()
        {
            DropDownVersion.DataSource = dp.getHFMCompleteAadmin();
            DropDownVersion.DataTextField = "Division descr";
            DropDownVersion.DataValueField = "Division descr";
            DropDownVersion.DataBind();
            DropDownVersion.CssClass = "selectpicker";
            DropDownVersion.Attributes.Add("data-live-search", "true");
        }

        private void DivisionDropDownList()
        {
            DropDownDivision.DataSource = dp.getHFMCompleteAadmin();
            DropDownDivision.DataTextField = "Division";
            DropDownDivision.DataValueField = "Division";
            DropDownDivision.DataBind();
            DropDownDivision.CssClass = "selectpicker";
        }

        private void DateDropDown()
        {
            // Months DropDown List 
            var months = new CultureInfo("SV").DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)
            {
                DropDownMounths.Items.Add(new ListItem(months[i], (i+1).ToString()));
            }

            DropDownMounths.DataBind();
            DropDownMounths.CssClass = "selectpicker";


            // Years DropDown List 
            var startYear = 2012;
            DropDownYears.DataSource = Enumerable.Range(startYear, DateTime.Now.Year - startYear + 10);

            DropDownYears.DataBind();
            DropDownYears.CssClass = "selectpicker";

        }
    }
}