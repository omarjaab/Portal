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
    //Durgam rocks, Omar sucks
    public partial class agr_leverantor : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {

            // omars Commit TEST 
            if (Controllers.login.data !=null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }


    }
}