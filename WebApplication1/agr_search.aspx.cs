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
    public partial class agr_search : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        DataTable dt = new DataTable(); // declearing dt as a global variable.
        //DropDownList dll_AgreementType = new DropDownList();
        //DropDownList dll_Company_Division = new DropDownList();
        //TextBox businessPartner_txtBox = new TextBox();
        //TextBox /*namn_txtBox*/ = new TextBox();
        //TextBox orgNr_txtBox = new TextBox();
        //TextBox agreementNr_txtBox = new TextBox();
        //TextBox agreementResponsible_txtBox = new TextBox();
        //TextBox department_txtBox = new TextBox();
        internal void Page_Load(object sender, EventArgs e)
        {
            //dt = dp.get_TxtBox_Data();
            // Agreement type & Company Divisions DropDownLists method **(Not sure if it's complet yet)**
            ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(gv_Result);
            CreateDropDownsLists();
            //BusinessPartner_TxtBox();
            //Namn_TxtBox();
            //OrgNr_TxtBox();
            //AgreementNr_TxtBox();
            //AgreementResponsible_TxtBox();
            //Department_TxtBox();

            dt = dp.Get_AgreementResponsible_Create();

            for (int i = 0; i <dt.Rows.Count; i++)
            {
                dt.Rows[i]["UserID"].ToString();
                DDL_AgreementResponsible.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
                DDL_Backup_1.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
                DDL_Backup_2.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
                DDL_Backup_3.Items.Add(new ListItem(dt.Rows[i]["UserID"].ToString()));
            }

        }
        private void CreateDropDownsLists()
        {
            //DataTable dt = new DataTable(); // Is it better to decleare dt as a global variable?
            dt = dp.getAgreement("");  // <-----What should i write here?

            
            for (int i = 0; i < dt.Rows.Count; i++) // A for_Loop that use's if-sats to populate the DropDownList's
            {
                if (dt.Rows[i]["Type"].ToString() == "AgreementType")
                {
                    dll_AgreementType.Items.Add(new ListItem(dt.Rows[i]["Description"].ToString(), dt.Rows[i]["AgreementType"].ToString()));
                    DDL_Create_Agr.Items.Add(new ListItem(dt.Rows[i]["Description"].ToString(), dt.Rows[i]["AgreementType"].ToString()));

                }
                else if (dt.Rows[i]["Type"].ToString() == "Division")
                {
                    dll_Company_Division.Items.Add(new ListItem(dt.Rows[i]["Division name - current"].ToString(), dt.Rows[i]["CompanyDivision"].ToString()));
                    DDL_Create_DIV.Items.Add(new ListItem(dt.Rows[i]["Division name - current"].ToString(), dt.Rows[i]["CompanyDivision"].ToString()));
                }
            }
            
        }
        //private void BusinessPartner_TxtBox()
        //{

        //    businessPartner_txtBox.ID = "businessPartner_txtBox";
        //    //partNum_txtBox.AutoPostBack = true; //<--- no need for autopost back? Becuase it will get data when we press a button...right?
        //    businessPartner_txtBox.Text = "*";
        //    businessPartner_txtBox.Width = 100;

        //    partNum_txtBox_Container.Controls.Add(businessPartner_txtBox);
        //}
        //private void Namn_TxtBox()
        //{

        //    namn_txtBox.ID = "namn_txtBox";
        //    namn_txtBox.Text = "*";
        //    namn_txtBox.Width = 100;

        //    namn_txtBox_Container.Controls.Add(namn_txtBox);
        //}
        //private void OrgNr_TxtBox()
        //{

        //    orgNr_txtBox.ID = "orgNr_txtBox";
        //    orgNr_txtBox.Text = "*";
        //    orgNr_txtBox.Width = 100;

        //    org_Nr_txtBox_Container.Controls.Add(orgNr_txtBox);
        //}
        //private void AgreementNr_TxtBox()
        //{

        //    agreementNr_txtBox.ID = "agreementNr_txtBox";
        //    agreementNr_txtBox.Text = "*";
        //    agreementNr_txtBox.Width = 100;

        //    avtals_Nr_txtBox_Container.Controls.Add(agreementNr_txtBox);
        //}
        //private void AgreementResponsible_TxtBox()
        //{

        //    agreementResponsible_txtBox.ID = "agreementResponsible_txtBox";
        //    agreementResponsible_txtBox.Text = "*";
        //    agreementResponsible_txtBox.Width = 100;

        //    avtals_Ansv_txtBox_Container.Controls.Add(agreementResponsible_txtBox);//<--- Where to display TextBox
        //}
        //private void Department_TxtBox()
        //{

        //    department_txtBox.ID = "department_txtBox";
        //    department_txtBox.Text = "*";
        //    department_txtBox.Width = 100;

        //    avdelning_txtBox_Container.Controls.Add(department_txtBox);//<--- Where to display TextBox
        //}


        protected void SokAvtal_btn_Click(object sender, EventArgs e)
        {
            GetAgreements();
        }

        public void GetAgreements()
        { 
            string UID = Session["UserID"].ToString();
            string agreementType = dll_AgreementType.SelectedValue;
            //string company_Division = dll_Company_Division.SelectedValue;

            string CompanyDivision = dll_Company_Division.SelectedValue;
            string Company = CompanyDivision.Substring(0, CompanyDivision.IndexOf("-"));
            string Division = CompanyDivision.Substring(CompanyDivision.IndexOf("-")+1); //CompanyDivision.Length
            string businessPartner = businessPartner_txtBox.Text;
            string name = namn_txtBox.Text;
            string orgNr = orgNr_txtBox.Text;
            string agreementNr = agreementNr_txtBox.Text;
            string agreementResponsible = agreementResponsible_txtBox.Text;
            string department = department_txtBox.Text;
            gv_Result.DataSource = dp.get_TxtBox_Data(UID, agreementType, Company, Division, businessPartner, name, orgNr, agreementNr, agreementResponsible, department);
            gv_Result.DataBind();
            
        }

        //trying to use autogenerated delete button.
        protected void gv_Result_RowDeleting(object sender, EventArgs e)
        {
           
                GridViewDeleteEventArgs args = e as GridViewDeleteEventArgs;
                string AgreementNumber = gv_Result.Rows[args.RowIndex].Cells[4].Text.ToString();
                string Company = gv_Result.Rows[args.RowIndex].Cells[8].Text.ToString();
                string Division = gv_Result.Rows[args.RowIndex].Cells[9].Text.ToString();
                dp.Agreement_search_Delete(AgreementNumber, Company, Division);
                GetAgreements();
              
        }

        protected void Create_btn_Click(object sender, EventArgs e)
        {
            string AgreementType = DDL_Create_Agr.SelectedValue;
            string CompanyDivision = DDL_Create_DIV.SelectedValue;
            string Company = CompanyDivision.Substring(0, CompanyDivision.IndexOf("-"));
            string Division = CompanyDivision.Substring(CompanyDivision.IndexOf("-")+1, CompanyDivision.Length);
            dp.CreateAgreement(AgreementType, Company, Division);
            GetAgreements();
        }
    }
}