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
            dt = dp.Get_AgreementResponsible_Create();
            // Use this to stop the page from backposting? ---> if (!Page.IsPostBack) { GetData(); }
            // checks if the user is logedin via logon site before showing this site.
            LoginAuthentication();
            // population for  agreement responsible, backup1,backup2 and backup3 DDL. (Data from dw_Admin / SP_Agreement_Create_Responsible_DDL)            
            agr_Responsible_DDL();

        }

        private void LoginAuthentication()
        {
            if (Controllers.login.data != null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }

        private void agr_Responsible_DDL()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["UserID"].ToString();
                DDL_AgreementResponsible.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
                DDL_Backup_1.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
                DDL_Backup_2.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
                DDL_Backup_3.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
            }
        }

        /*Not working as wished*/
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            if (Vaild_From_Calendar.Visible == false)
            {
                Vaild_From_Calendar.Visible = true;
            }
            else if (Vaild_From_Calendar.Visible == true)
            {
                Vaild_From_Calendar.Visible = false;
            }
       

        }
        /*Not working as wished*/
        //protected void Vaild_From_Calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        //{
        //    //TextBox textbox = (TextBox)txtBox_New_Agr_Valid_From.FindControl("Vaild_From_Calendar");
        //    //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(textbox);
        //}
        /*Not working as wished*/
        protected void Vaild_From_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            string txtVaildFrom = txtBox_New_Agr_Valid_From.ToString();
            txtBox_New_Agr_Valid_From.Text = Vaild_From_Calendar.SelectedDate.ToString();
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(txtBox_New_Agr_Valid_From);
        }

        protected void Valid_Until_Calendar_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}