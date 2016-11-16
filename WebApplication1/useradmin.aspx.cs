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
    public partial class useradmin : System.Web.UI.Page
    {
        string connection =
        System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWAdmin"].ConnectionString;
        Controllers.DefaultController dp = new Controllers.DefaultController(); 
        List<Object> UserList = new List<Object>();
        List<Object> ApplicationList = new List<Object>();
        List<Object> AgreementList = new List<Object>();
        List<Object> DivisionsList = new List<Object>();
        DropDownList usersddl = new DropDownList();// CreateDropDown("usersddl");
        CheckBoxList applicationschklbox = new CheckBoxList();
        CheckBoxList agreementchklbox = new CheckBoxList();
        CheckBoxList divisionerchklbox = new CheckBoxList();
        TextBox PasswordTextBox = new TextBox();

        public CheckBoxList CreateDropDown(string Id)
        {
            CheckBoxList ddl = new CheckBoxList();
            ddl.AutoPostBack = true;
            ddl.ID = "usersddl";
            return ddl;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
         
            //Controllers.login.data = dp.Login("admin", "ufodis");

            if (Controllers.login.data != null)
            {
                Controllers.login.ConstructNavigator(Navigator);
                DataTable tempdt = new DataTable();
                tempdt = dp.GetAdminInformation();
                ///*usersddl*/.Items.Clear();
                //HtmlGenericControl usersddl = new HtmlGenericControl("DropDownList");
   
                usersddl.AutoPostBack = true;
                usersddl.ID = "usersddl";
               
                usersddl.SelectedIndexChanged += new EventHandler(usersddl_SelectedIndexChanged);
                
  
                applicationschklbox.ID = "applicationschklbox";
                agreementchklbox.ID = "agreementchklbox";
                divisionerchklbox.ID = "divisionerchklbox";

                PasswordTextBox.ID = "PasswordTextBox";
                PasswordTextBox.AutoPostBack = true;
                
                PasswordTextBox.TextChanged += new EventHandler(PasswordTextBox_TextChanged);
                PasswordContainer.Controls.Add(PasswordTextBox);


                UserListContainer.Controls.Add(usersddl);
                ApplicationContainer.Controls.Add(applicationschklbox);
                agreement.Controls.Add(agreementchklbox);
                Division.Controls.Add(divisionerchklbox);

                for (int i = 0; i < tempdt.Rows.Count; i++)
                {
                    if (tempdt.Rows[i]["Type"].ToString() == "User")
                    {
                       usersddl.Items.Add(new ListItem(tempdt.Rows[i]["Name"].ToString(), tempdt.Rows[i]["Id"].ToString()));
                       UserList.Add(new Object(tempdt.Rows[i]["Type"].ToString(), tempdt.Rows[i]["Name"].ToString(), tempdt.Rows[i]["Id"].ToString(), tempdt.Rows[i]["Password"].ToString()));
                    }
                    else if (tempdt.Rows[i]["Type"].ToString() == "Application")
                    {
                       /// applicationschklbox.Items.Add(tempdt.Rows[i]["Name"].ToString());
                        ApplicationList.Add(new Object(tempdt.Rows[i]["Type"].ToString(), tempdt.Rows[i]["Name"].ToString(), tempdt.Rows[i]["Id"].ToString(), tempdt.Rows[i]["Password"].ToString()));
                    }
                    else if (tempdt.Rows[i]["Type"].ToString() == "Agreement")
                        AgreementList.Add(new Object(tempdt.Rows[i]["Type"].ToString(), tempdt.Rows[i]["Name"].ToString(), tempdt.Rows[i]["Id"].ToString(), tempdt.Rows[i]["Password"].ToString()));
                    else if (tempdt.Rows[i]["Type"].ToString() == "Division")
                        DivisionsList.Add(new Object(tempdt.Rows[i]["Type"].ToString(), tempdt.Rows[i]["Name"].ToString(), tempdt.Rows[i]["Id"].ToString(), tempdt.Rows[i]["Password"].ToString()));
                }

                if (ApplicationList.Count > 0)
                {
                    applicationschklbox.DataValueField = "oId";
                    applicationschklbox.DataTextField = "oName";
                    applicationschklbox.DataSource = ApplicationList;
                    applicationschklbox.DataBind();
                }
                //if (UserList.Count > 0)
                //{


                //usersddl.DataSource = UserList;
                //usersddl.DataBind();
                //}
                if (AgreementList.Count > 0)
                {
                    agreementchklbox.DataValueField = "oId";
                    agreementchklbox.DataTextField = "oName";
                    agreementchklbox.DataSource = AgreementList;
                    agreementchklbox.DataBind();
                }
                if (DivisionsList.Count > 0)
                {
                    divisionerchklbox.DataValueField = "oId";
                    divisionerchklbox.DataTextField = "oName";
                    divisionerchklbox.DataSource = DivisionsList;
                    divisionerchklbox.DataBind();
                }



            }
            else { Response.Redirect("Logon.aspx"); }

        }

        public void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void usersddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            //lbl.InnerText = ddl.SelectedIndex.ToString();
            DataTable dt = new DataTable();
            ApplicationContainer.Controls.Remove(applicationschklbox);
            agreement.Controls.Remove(agreementchklbox);
            Division.Controls.Remove(divisionerchklbox);

            applicationschklbox.ClearSelection();
            agreementchklbox.ClearSelection();
            divisionerchklbox.ClearSelection();

            if (ddl.SelectedIndex > -1)
            {
                PasswordTextBox.Text= "";
                PasswordTextBox.Text = UserList[ddl.SelectedIndex].oPassword;
                dt = dp.getuserapplication(UserList[ddl.SelectedIndex].oId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < applicationschklbox.Items.Count; j++)
                    {
                        if (applicationschklbox.Items[j].Value == dt.Rows[i]["Id"].ToString())
                        {
                            applicationschklbox.Items[j].Selected = true;
                        }
                    }

                }
            }
         
            ApplicationContainer.Controls.Add(applicationschklbox);
            dt = dp.getuserAgreement(UserList[ddl.SelectedIndex].oId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < agreementchklbox.Items.Count; j++)
                {
                    if (agreementchklbox.Items[j].Value == dt.Rows[i]["Id"].ToString())
                    {
                        agreementchklbox.Items[j].Selected = true;
                    }
                }
            }
            agreement.Controls.Add(agreementchklbox);
            dt = dp.getuserDivision(UserList[ddl.SelectedIndex].oId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < divisionerchklbox.Items.Count; j++)
                {
                    if (divisionerchklbox.Items[j].Value == dt.Rows[i]["Id"].ToString())
                    {
                        divisionerchklbox.Items[j].Selected = true;
                    }
                }
            }
            Division.Controls.Add(divisionerchklbox);

            //}

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<Object> InputList = new List<Object>();

            InputList.Add(new Object("Password", usersddl.SelectedValue, PasswordTextBox.Text));
            
            for(int i=0;i<applicationschklbox.Items.Count;i++)
                if(applicationschklbox.Items[i].Selected == true)
                    InputList.Add(new Object("Application", usersddl.SelectedValue, applicationschklbox.Items[i].Value));


            for (int i = 0; i < divisionerchklbox.Items.Count; i++)
                if (divisionerchklbox.Items[i].Selected == true)
                    InputList.Add(new Object("Division", usersddl.SelectedValue, divisionerchklbox.Items[i].Value));



            for (int i = 0; i < agreementchklbox.Items.Count; i++)
                if (agreementchklbox.Items[i].Selected == true)
                    InputList.Add(new Object("Agreement", usersddl.SelectedValue, agreementchklbox.Items[i].Value));

            dp.InsertObjectsIntoDB(InputList);
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            
            using(SqlConnection con = new SqlConnection(connection))
            {
                SqlDataReader reader;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT Admin_Users(uname, password) VALUES('" +txtUserNamePanel.Text+ "', '" +txtPasswordPanel.Text+ "')", con);
                reader = cmd.ExecuteReader();
            }
        }

        public void btnDeleteUser_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataReader reader;
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Admin_Users where uid='"+ UserList[usersddl.SelectedIndex].oId+ "'", con);
                reader = cmd.ExecuteReader();
            }
        }
    }
}