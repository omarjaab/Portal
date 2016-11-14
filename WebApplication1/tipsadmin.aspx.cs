using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Portal 
{
    public partial class tipsadmin : System.Web.UI.Page
    {
        // push test 
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {GetData(); }
            


            if (Controllers.login.data !=null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }
        public void GetData()
        {
            Gv_Avräkning.DataSource = dp.getAvräkning();
            Gv_Avräkning.DataBind();

            Gv_Fakturering.DataSource = dp.getFakturering();
            Gv_Fakturering.DataBind();
        }
        

        protected void Calendar2_Click(object sender, ImageClickEventArgs e)
        {
            
            //for (int i = 0; i < Gv_Avräkning.Rows.Count; i++)
            //{

                ImageButton lb =  /*Gv_Avräkning.Rows[0].FindControl("Calendar1") */ sender as ImageButton;
            //lb.ID = "" + i + "";
            //lb.Click += new EventHandler
            int rowIndex = Convert.ToInt32(lb.Attributes["RowIndex"]);

            if (Gv_Avräkning.Rows[0].FindControl("Calendar3").Visible == false)
                {
                    Gv_Avräkning.Rows[0].FindControl("Calendar3").Visible = true;
                }
                else if (Gv_Avräkning.Rows[0].FindControl("Calendar3").Visible == true)
                {
                    Gv_Avräkning.Rows[0].FindControl("Calendar3").Visible = false;

                }
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
            //}
            

   
            //Calendar calender = (Calendar)Gv_Avräkning.Rows[0].FindControl("Calendar3");
          
            // TextBox txtDatumAvräkning = (TextBox)Gv_Avräkning.Rows[0].FindControl("txtDatumAvräkning");
            //txtDatumAvräkning.Text = calender.SelectedDate.ToString();
            
           

        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {

            Calendar calender = (Calendar)Gv_Avräkning.Rows[0].FindControl("Calendar3");
            TextBox txtDatumAvräkning = (TextBox)Gv_Avräkning.Rows[0].FindControl("txtDatumAvräkning");
            txtDatumAvräkning.Text = calender.SelectedDate.ToString();
            //if (calender.SelectedDate != null)
            //{
            //    Gv_Avräkning.Rows[0].FindControl("Calendar3").Visible = false;
            //}
            
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(calender);

        }

        protected void Calendar3_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            Calendar calender = (Calendar)Gv_Avräkning.Rows[0].FindControl("Calendar3"); ;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(calender);
        }
    }
}