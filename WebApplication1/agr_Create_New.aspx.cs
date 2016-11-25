using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class agr_Create_New : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        DataTable dt = new DataTable();
        internal void Page_Load(object sender, EventArgs e)
        {
            LoginAuthentication();
        }
        private void LoginAuthentication()
        {
            if (Controllers.login.data != null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (FindControl("Vaild_From_Calendar").Visible==false)
            {
                FindControl("Vaild_From_Calendar").Visible = true;
            }
            else if (FindControl("Vaild_From_Calendar").Visible == true)
            {
                FindControl("Vaild_From_Calendar").Visible = false;
            }
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(ib);
        }
        protected void Vaild_From_Calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            TextBox textbox = (TextBox)txtBox_New_Agr_Valid_From.FindControl("Vaild_From_Calendar");
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(textbox);
        }
        protected void Vaild_From_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            string txtVaildFrom = txtBox_New_Agr_Valid_From.ToString();
            txtBox_New_Agr_Valid_From.Text = Vaild_From_Calendar.SelectedDate.ToString();
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(txtBox_New_Agr_Valid_From);
        }
    }
}