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
    public partial class Logon : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Controllers.login.uname = txtUserName.Text;
            Controllers.login.password = txtPassword.Text;
            Controllers.login.data = dp.Login(Controllers.login.uname, Controllers.login.password);
            if (Controllers.login.data.Rows.Count > 0)
            {
                Response.Redirect("index.aspx");
            }
            

        //    //GetDivElements();
        //    DataTable dt = dp.Login();
        //    //string navigator = " ";


        //    //LOOP THROUGH CATEGORIES
        //    List<string> Categories = new List<string>();
        //    List<string> Looped = new List<string>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //        if (Categories.IndexOf(dt.Rows[i]["Category"].ToString()) == -1)
        //        {
        //            HtmlGenericControl li = new HtmlGenericControl("li");
        //            Navigator.Controls.Add(li);
        //            //li.Attributes.Add("runat", "server");
        //            HtmlGenericControl anchor = new HtmlGenericControl("a");
        //            anchor.Attributes.Add("href", dt.Rows[i]["Category"].ToString());
        //            anchor.InnerText = dt.Rows[i]["Category"].ToString();
        //            Categories.Add(dt.Rows[i]["Category"].ToString());
        //            li.Controls.Add(anchor);

        //            for (int x = 0; x < Categories.Count; x++)
        //                if (Looped.IndexOf(Categories[x]) == -1)
        //                {
        //                    HtmlGenericControl ul = new HtmlGenericControl("ul");
        //                    for (int j = 0; j < dt.Rows.Count; j++)
        //                        if (Categories[x] == dt.Rows[j]["Category"].ToString())
        //                        {
        //                            HtmlGenericControl subli = new HtmlGenericControl("li");
        //                            Navigator.Controls.Add(subli);
        //                            //li.Attributes.Add("runat", "server");
        //                            HtmlGenericControl subanchor = new HtmlGenericControl("a");
        //                            subanchor.Attributes.Add("href", dt.Rows[j]["AccessablePage"].ToString() + "x");
        //                            subanchor.InnerText = dt.Rows[j]["Description"].ToString();
        //                            subli.Controls.Add(subanchor);
        //                            ul.Controls.Add(subli);
        //                        }
        //                    Looped.Add(Categories[x]);
        //                    li.Controls.Add(ul);
        //                }
        //        }

        }
    }
}