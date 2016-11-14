using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace Portal
{
    public partial class valutaadmin : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        string connection =
            System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWAdmin"].ConnectionString;
        //TextBox txtAverage = new TextBox();
        //TextBox txtClosing = new TextBox();
        //private Label lblCurrencyCode = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {DateDropDown(); }
            

            if (Controllers.login.data != null)
            {
                Controllers.login.ConstructNavigator(Navigator);
                //// label CurrencyCode
                //lblCurrencyCode.ID = "lblCurrencyCode";

                //// txt box Average
                //txtAverage.ID = "txtAverage";
                //txtAverage.AutoPostBack = true;
                //txtAverage.TextChanged += new EventHandler(btnShow_Click);

                ////txt box Closing
                //txtClosing.ID = "txtClosing";
                //txtClosing.AutoPostBack = true;
                //txtClosing.TextChanged += new EventHandler(btnShow_Click);

                //// add these input to the page 
                //CurrCodeContainer.Controls.Add(lblCurrencyCode);
                //averageContainer.Controls.Add(txtAverage);
                //closingContainer.Controls.Add(txtClosing);

            }
            else { Response.Redirect("Logon.aspx"); }
        }

        private void DateDropDown()
        {
            // Months DropDown List 
            var months = new CultureInfo("SV").DateTimeFormat.MonthNames;
            //ddlMonth.Items.Clear();
            for (int i = 0; i < months.Length-1 ; i++)
            {
                ddlMonth.Items.Add(new ListItem(months[i], (i+1).ToString()));
            }
            
            ddlMonth.DataBind();

            // Years DropDown List 
            var startYear = 2006;
            ddlYear.DataSource = Enumerable.Range(startYear, DateTime.Now.Year - startYear + 10);
            
            ddlYear.DataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

            if (rblCurrency.Items[0].Selected )
            {
                firstPage.Visible=false;
                secondPage.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = false;
                
            }
            else if (rblCurrency.Items[1].Selected )
            {
                firstPage.Visible = false;
                thirdPage.Visible = true;
                btnBack.Visible = true;
                btnNext.Visible = false;
                btnAddValuta.Visible = true;
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            firstPage.Visible = true;
            secondPage.Visible = false;
            thirdPage.Visible = false;
            btnBack.Visible = false;
            btnNext.Visible = true;
            btnAddValuta.Visible = false;
            lblMsg.Text = "";
        }

        protected void btnAddValuta_Click(object sender, EventArgs e)
        {
            string valutaInput = txtvalutaInput.Text;
            if (dp.checkValuta(valutaInput).Rows.Count == 0)
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                     
                    SqlCommand cmd = new SqlCommand("exec sp_newCurrency @valuta", con);
                    cmd.Parameters.AddWithValue("@valuta", valutaInput);
                    cmd.ExecuteNonQuery();
                }
                lblMsg.Text = "Valuta' : " + valutaInput + "' added  ";

            }
            else
            {
                lblMsg.Text = "Valuta' : "+valutaInput+"' is already exist ";
            }
        }

        public void btnShow_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            string year = ddlYear.SelectedValue.ToString();
            string month = ddlMonth.SelectedValue.ToString();
            dt = dp.Currency(year, month);
            GridViewCurrency.DataSource = dp.Currency(year, month);
                
                GridViewCurrency.DataBind();
          
            
                for (int i = 0; i < GridViewCurrency.Rows.Count; i++)
                {
                    for (int j = 0; j < GridViewCurrency.Rows[i].Cells.Count; j++)
                    {
                        TextBox txtAverage = (TextBox)GridViewCurrency.Rows[i].Cells[j].FindControl("txtAverage");
                            txtAverage.Text = dt.Rows[i]["AverageRate"].ToString();
                        TextBox txtClosing = (TextBox)GridViewCurrency.Rows[i].Cells[j].FindControl("txtClosing");
                            txtClosing.Text = dt.Rows[i]["ClosingRate"].ToString();
                    }    
            }   
            if(dt.Rows.Count==0)
            {
                lblMsg.Text = "The date " + year + "/" + month + " is not exist in the DataBase";
            }
        }

        public void btnSpara_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewCurrency.Rows.Count; i++)
            {
                for (int j = 0; j < GridViewCurrency.Rows[i].Cells.Count; j++)
                {
                    string currCode = GridViewCurrency.Rows[i].Cells[0].Text;
                    double txtAverage = double.Parse(((TextBox)GridViewCurrency.Rows[i].Cells[j].FindControl("txtAverage")).Text);
                    double txtclosing = double.Parse(((TextBox)GridViewCurrency.Rows[i].Cells[j].FindControl("txtClosing")).Text);
                    int year = int.Parse(ddlYear.SelectedValue);
                    int month = int.Parse(ddlMonth.SelectedValue);
                    dp.Currency_Save(year, month, currCode, txtAverage, txtclosing);
            }
        }
    }
    }
}
