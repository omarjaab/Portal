using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//hej ahmed test omar durgam
namespace Portal
{
    public partial class useradmin : System.Web.UI.Page
    {
        string connection =
        System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWAdmin"].ConnectionString;
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Controllers.login.data != null)
            {
                if (!IsPostBack)
                {
                    Controllers.login.ConstructNavigator(Navigator);
                    GetAdminInformation();



                }
            }
            else { Response.Redirect("Logon.aspx"); }

        }
        public void GetAdminInformation()
        {
            DataTable tempdt = new DataTable();
            tempdt = dp.GetAdminInformation();

            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                if (tempdt.Rows[i]["Type"].ToString() == "User")
                {
                    usersddl.Items.Add(new ListItem(tempdt.Rows[i]["Name"].ToString(),
                        tempdt.Rows[i]["Id"].ToString()));

                }
                else if (tempdt.Rows[i]["Type"].ToString() == "Application")
                    applicationschklbox.Items.Add(new ListItem(tempdt.Rows[i]["Name"].ToString(),
                        tempdt.Rows[i]["Id"].ToString()));
                else if (tempdt.Rows[i]["Type"].ToString() == "Agreement")
                    agreementchklbox.Items.Add(new ListItem(tempdt.Rows[i]["Name"].ToString(),
                        tempdt.Rows[i]["Id"].ToString()));
                else if (tempdt.Rows[i]["Type"].ToString() == "Division")
                    divisionerchklbox.Items.Add(new ListItem(tempdt.Rows[i]["Name"].ToString(),
                        tempdt.Rows[i]["Id"].ToString()));
            }

        }

        public void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void Rebind()
        {
            applicationschklbox.ClearSelection();
            agreementchklbox.ClearSelection();
            divisionerchklbox.ClearSelection();
            applicationschklbox.Items.Clear();
            agreementchklbox.Items.Clear();
            divisionerchklbox.Items.Clear();
            usersddl.Items.Clear();
            PasswordTextBox.Text = "";
            GetAdminInformation();
        }

        public void usersddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            applicationschklbox.ClearSelection();
            agreementchklbox.ClearSelection();
            divisionerchklbox.ClearSelection();
            PasswordTextBox.Text = "";
            dt = dp.GetUserPermissionInfo(usersddl.SelectedValue);
            if (usersddl.SelectedIndex > -1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Type"].ToString() == "Password")
                        PasswordTextBox.Text = dt.Rows[i]["Value"].ToString();
                    else if (dt.Rows[i]["Type"].ToString() == "Application")
                    {
                        for (int j = 0; j < applicationschklbox.Items.Count; j++)
                        {
                            if (applicationschklbox.Items[j].Value == dt.Rows[i]["Value"].ToString())
                            {
                                applicationschklbox.Items[j].Selected = true;
                                break;
                            }
                        }
                    }
                    else if (dt.Rows[i]["Type"].ToString() == "Agreement")
                    {
                        for (int j = 0; j < agreementchklbox.Items.Count; j++)
                        {
                            if (agreementchklbox.Items[j].Value == dt.Rows[i]["Value"].ToString())
                            {
                                agreementchklbox.Items[j].Selected = true;
                                break;
                            }
                        }
                    }
                    else if (dt.Rows[i]["Type"].ToString() == "Division")
                    {
                        for (int j = 0; j < divisionerchklbox.Items.Count; j++)
                        {
                            if (divisionerchklbox.Items[j].Value == dt.Rows[i]["Value"].ToString())
                            {
                                divisionerchklbox.Items[j].Selected = true;
                                break;
                            }
                        }
                    }

                }

            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> InputList = new List<Object>();

                InputList.Add(new Object("Password", usersddl.SelectedValue, PasswordTextBox.Text));

                for (int i = 0; i < applicationschklbox.Items.Count; i++)
                    if (applicationschklbox.Items[i].Selected == true)
                        InputList.Add(new Object("Application", usersddl.SelectedValue,
                            applicationschklbox.Items[i].Value));


                for (int i = 0; i < divisionerchklbox.Items.Count; i++)
                    if (divisionerchklbox.Items[i].Selected == true)
                        InputList.Add(new Object("Division", usersddl.SelectedValue, divisionerchklbox.Items[i].Value));



                for (int i = 0; i < agreementchklbox.Items.Count; i++)
                    if (agreementchklbox.Items[i].Selected == true)
                        InputList.Add(new Object("Agreement", usersddl.SelectedValue, agreementchklbox.Items[i].Value));

                dp.InsertObjectsIntoDB(InputList);
                Rebind();
            }
            catch (Exception ex)
            {
                string es = ex.Message;
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlDataReader reader;
                    con.Open();
                    SqlCommand cmd =
                        new SqlCommand(
                            "INSERT Admin_Users(uname, password) VALUES('" + txtUserNamePanel.Text + "', '" +
                            txtPasswordPanel.Text + "')", con);
                    reader = cmd.ExecuteReader();

                }
                Rebind();
            }
            catch (Exception ex)
            {
                string es = ex.Message;
            }
        }

        public void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    SqlDataReader reader;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Admin_Users where uid='" + usersddl.SelectedValue.ToString() + "'", con);
                    reader = cmd.ExecuteReader();
                }

                Rebind();
            }
            catch (Exception ex)
            {
                string es = ex.Message;
            }
        }
    }
}