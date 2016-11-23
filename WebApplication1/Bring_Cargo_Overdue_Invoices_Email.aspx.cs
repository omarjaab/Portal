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

    public partial class Bring_Cargo_Overdue_Invoices_Email : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewData();

                getDDL();
            }

            if (Controllers.login.data != null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }

        public void getDDL()
        {
            ddlLokasjon.DataSource = dp.getLokasjon();
            ddlLokasjon.DataTextField = "Lokasjon";
            ddlLokasjon.DataBind();
        }
        public void GridViewData()
        {
            var dt = new DataTable();
            gvAllData.DataSource = dp.getOverdueInvoicesEmails();
            gvAllData.DataBind();
            dt = dp.getOverdueInvoicesEmails();

            for (int i = 0; i < gvAllData.Rows.Count; i++)
            {
                for (int j = 0; j < gvAllData.Rows[i].Cells.Count; j++)
                {
                    Label Lokasjon = (Label)gvAllData.Rows[i].Cells[j].FindControl("Lokasjon");
                    Lokasjon.Text = dt.Rows[i]["Lokasjon"].ToString();
                    TextBox txtEmail = (TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtEmail");

                    txtEmail.Text = dt.Rows[i]["mail_to"].ToString();
                    TextBox txtcc = (TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtcc");
                    txtcc.Text = dt.Rows[i]["cc_to"].ToString();
                    TextBox txtSubject = (TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtSubject");
                    txtSubject.Text = dt.Rows[i]["Subject"].ToString();
                    TextBox txtBody = (TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtBody");
                    txtBody.Text = dt.Rows[i]["Body"].ToString();
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvAllData.Rows.Count; i++)
            {
                for (int j = 0; j < gvAllData.Rows[i].Cells.Count; j++)
                {
                    string Lokasjon = (((Label)gvAllData.Rows[i].Cells[j].FindControl("Lokasjon")).Text).ToString();
                    string txtEmail = (((TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtEmail")).Text).ToString();
                    string txtcc = (((TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtcc")).Text).ToString();
                    string txtSubject = (((TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtSubject")).Text).ToString();
                    string txtBody = (((TextBox)gvAllData.Rows[i].Cells[j].FindControl("txtBody")).Text).ToString();
                    dp.UpdateData(txtEmail, txtcc, txtSubject, txtBody, Lokasjon);
                }
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            string txtLokasjon = ddlLokasjon.SelectedItem.ToString();
            string txtTO = txtEmailAdd.Text;
            string txtcc = txtccAdd.Text;
            string txtSubject = txtSubjectAdd.Text;
            string txtBody = txtBodyAdd.Text;
            dp.AddData(txtLokasjon, txtTO, txtcc, txtSubject, txtBody);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            dp.DeleteData(ddlLokasjon.SelectedItem.ToString());
        }
    }
}