using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Portal
{
    public partial class agr_responsible : System.Web.UI.Page
    {
        string connection =
System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWAdmin"].ConnectionString;
        Controllers.DefaultController dp = new Controllers.DefaultController();

        DataTable ds = new DataTable();
        Object obj = new Object();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
            if (Controllers.login.data != null)
            {
                Controllers.login.ConstructNavigator(Navigator);
            }
            else { Response.Redirect("Logon.aspx"); }
        }
        public void BindData()
        {
            ds = dp.Get_Agreement_Responsible();
            EmailResponsibleGrid.DataSource = ds;
            EmailResponsibleGrid.DataBind();
            obj.RefreshPage(EmailResponsibleGrid.PageIndex, EmailResponsibleGrid);
           
        }
     
        protected void EmailResponsibleGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmailResponsibleGrid.PageIndex = e.NewPageIndex;
            BindData();
            obj.RefreshPage(e.NewPageIndex, EmailResponsibleGrid);
        }

        protected void SaveButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string RowId = (EmailResponsibleGrid.Rows[Convert.ToInt32(((ImageButton)sender).CommandArgument) % 10].Cells[0].FindControl("lblstId") as Label).Text;
            string EmailId = (EmailResponsibleGrid.Rows[Convert.ToInt32(((ImageButton)sender).CommandArgument) % 10].FindControl("txtEmailId") as TextBox).Text;
            dp.Update_Agreement_Responsible(RowId, EmailId);
            EmailResponsibleGrid.EditIndex = -1;
            BindData();
        }
        protected void DeleteButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string RowId = (EmailResponsibleGrid.Rows[Convert.ToInt32(((ImageButton)sender).CommandArgument)%10].Cells[0].FindControl("lblstId") as Label).Text;
            dp.Delete_Agreement_Responsible(RowId);
            BindData();
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string UserId = new_UserId.Text;
            string Email = new_EmailId.Text;
            dp.Insert_Agreement_Responsible(UserId, Email);
            BindData();
        }
    }
}