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
        SqlDataAdapter da;
        SqlConnection con;
        DataTable ds = new DataTable();
        SqlCommand cmd = new SqlCommand();
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
            con = new SqlConnection(connection);
            cmd.CommandText = "Select * from ResponsibleEmail";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            RefreshPage(GridView1.PageIndex);
            con.Close();
        }
        public void RefreshPage(int PageNumber)
        {
            int min = 0;
            if (PageNumber > 0)
                min = PageNumber * GridView1.PageSize;
            int max = ((PageNumber + 1) * GridView1.PageSize) - 1;
            int mod = ds.Rows.Count % 5;
            int maxPage = 0;
            maxPage = ds.Rows.Count / 5;
            int looper = 0;
            if (PageNumber == maxPage)
                looper = ds.Rows.Count % 5;
            else
                looper = (GridView1.PageSize + 1);
            for (int i = 0; i < looper; i++)
            {
                Label stId = new Label();
                stId = GridView1.Rows[i].Cells[0].FindControl("lblstid") as Label;
                TextBox EmailId = new TextBox();
                EmailId = GridView1.Rows[i].Cells[0].FindControl("txtEmailId") as TextBox;
                stId.Text = ds.Rows[min]["UserID"].ToString();
                EmailId.Text = ds.Rows[min]["Email"].ToString();
                min++;
                if (min == (max + 1))
                    break;
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            BindData();
            RefreshPage(e.NewPageIndex);
        }

        protected void SaveButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            con = new SqlConnection(connection);
            string RowId = (GridView1.Rows[Convert.ToInt32(((ImageButton)sender).CommandArgument)].Cells[0].FindControl("lblstId") as Label).Text;

            string EmailId = (GridView1.Rows[Convert.ToInt32(((ImageButton)sender).CommandArgument)].FindControl("txtEmailId") as TextBox).Text;
            cmd.Connection = con;
            cmd.CommandText = "exec sp_UpdateResponsible @UserId, @EmailId";
            cmd.Parameters.AddWithValue("@UserId", RowId);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            BindData();
            con.Close();
        }
        protected void DeleteButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            con = new SqlConnection(connection);
            cmd.Connection = con;
            string RowId = (GridView1.Rows[Convert.ToInt32(((ImageButton)sender).CommandArgument)].Cells[0].FindControl("lblstId") as Label).Text;
            cmd.CommandText = "EXEC sp_DeleteResponsible @UserId";
            cmd.Parameters.AddWithValue("@UserId", RowId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindData();
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string UserId = new_UserId.Text;
            string Email = new_EmailId.Text;
            con = new SqlConnection(connection);
            cmd.Connection = con;
            cmd.CommandText = "Execute sp_NewResponsible @UserId, @EmailId";
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@EmailId", Email);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindData();
        }
    }
}