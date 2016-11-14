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
    public partial class index : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (Controllers.login.data !=null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {

        }
    }
}