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
    public partial class hfmadmin : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        DataTable dt = new DataTable(); // declearing dt as a global variable.
        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownSelectYear();
            //DropDownSelectMounth();
            CreateDropDownList();
        }

        private void CreateDropDownList()
        {
            DropDownList DropDownDivision = new DropDownList();
            DropDownDivision.ID = "DropDownDivision";
            DropDownDivision.DataSource = dp.getHFMAdminitrationDivision();
            DropDownDivision.DataTextField = "Division descr";
            DropDownDivision.DataValueField = "Sort_order";
            DropDownDivision.DataBind();
            DropDownDivisionPlace.Controls.Add(DropDownDivision);

            // ddl years 
            DropDownList DropDownYear = new DropDownList();
            DropDownYear.ID = "DropDownYear";
            for (int i = 2006; i < 2023; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                DropDownYear.Items.Add(li);
            }
            DropDownYearPlace.Controls.Add(DropDownYear);


            // ddl months 
            DropDownList DropDownMounth = new DropDownList();
            DropDownMounth.ID = "DropDownMounth";
            var months = new CultureInfo("SV").DateTimeFormat.MonthNames;

            for (int i = 0; i < months.Length -1; i++)
            {
                ListItem li = new ListItem(months[i], (i+1).ToString());
                DropDownMounth.Items.Add(li);
            }
            DropDownMounthPlace.Controls.Add(DropDownMounth);
        }

        //private void DateDropDown()
        //{
        //    // Months DropDown List 
        //    var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        //    for (int i = 0; i < months.Length - 1; i++)
        //    {
        //        ddlMonth.Items.Add(new ListItem(months[i], i.ToString()));
        //    }

        //    ddlMonth.DataBind();

        //    // Years DropDown List 
        //    var startYear = 2006;
        //    ddlYear.DataSource = Enumerable.Range(startYear, DateTime.Now.Year - startYear + 10);

        //    ddlYear.DataBind();
        //}
        //------------------------------------
        //private void DropDownSelectYear()
        // {
        //     for (int i = 2006; i < 2023; i++)
        //     {
        //         ListItem li = new ListItem(i.ToString(), i.ToString());
        //         DropDownYear.Items.Add(li);
        //     }
        //IEnumerable<int> numbers = Enumerable.Range(2006, 2022);
        //DropDownYear.DataSource = numbers;
        //DropDownYear.DataBind();

        //var source = Enumerable.Range(1, 1000)
        //.Select(i => new { Text = i.ToString(), Value = i.ToString() });
        //DropDownYear.DataSource = source;
        //DropDownYear.DataTextField = "Text";
        //DropDownYear.DataValueField = "Value";
        //DropDownYear.DataBind();
        //}

        //private void DropDownSelectMounth()
        //{
        //    for (int i = 01; i < 13; i++)
        //    {
        //        ListItem li = new ListItem(i.ToString(), i.ToString());
        //        DropDownMounth.Items.Add(li);
        //    }
        //}

    }
}
