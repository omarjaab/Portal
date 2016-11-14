using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Portal
{
    public partial class agr_responsible : System.Web.UI.Page
    {
        string connection =
        System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWAdmin"].ConnectionString;
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.IsPostBack== true)
            //{
            //    Label3.Text = ("** Ny användare id och email inlagd");
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("INSERT into ResponsibleEmail(UserID, Email) VALUES(@UserID, @Email)", con);
                cmd.Parameters.AddWithValue("@UserID", txtuserId.Text);
                cmd.Parameters.AddWithValue("@Email", txtuserEmail.Text);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                


                if (IsPostBack)
                {
                    txtuserId.Text = "";
                    txtuserEmail.Text = "";
                }

            }
    }
    }
}