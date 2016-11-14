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
    public partial class redovisning_danmark : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDdlData();
            }
            
            if (Controllers.login.data != null)
            {
                Controllers.login.ConstructNavigator(Navigator);

                
            }
                
            else { Response.Redirect("Logon.aspx"); }
        }

        public void getDdlData()
        {
            ddlGrupp.DataSource = dp.getGroup();
            ddlGrupp.DataTextField = "Grupp";
            ddlGrupp.DataBind();
        }
    }
}