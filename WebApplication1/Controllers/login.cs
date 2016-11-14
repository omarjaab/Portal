using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Portal.Controllers
{
    public static class login
    {
        public static string uname { get; set; }
        public static string password { get; set; }
        public static DataTable data { get; set; }
        public static List<HtmlGenericControl> Navigator { get; set; }


        public static void ConstructNavigator(HtmlGenericControl Navigator)
        {

            DataTable dt = data;
            //LOOP THROUGH CATEGORIES
            List<string> Categories = new List<string>();
            List<string> Looped = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
                if (Categories.IndexOf(dt.Rows[i]["Category"].ToString()) == -1)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    Navigator.Controls.Add(li);
                    //li.Attributes.Add("runat", "server");
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", dt.Rows[i]["Category"].ToString());
                    anchor.InnerText = dt.Rows[i]["Category"].ToString();
                    Categories.Add(dt.Rows[i]["Category"].ToString());
                    li.Controls.Add(anchor);

                    for (int x = 0; x < Categories.Count; x++)
                        if (Looped.IndexOf(Categories[x]) == -1)
                        {
                            HtmlGenericControl ul = new HtmlGenericControl("ul");
                            for (int j = 0; j < dt.Rows.Count; j++)
                                if (Categories[x] == dt.Rows[j]["Category"].ToString())
                                {
                                    HtmlGenericControl subli = new HtmlGenericControl("li");
                                    Navigator.Controls.Add(subli);
                                    //li.Attributes.Add("runat", "server");
                                    HtmlGenericControl subanchor = new HtmlGenericControl("a");
                                    subanchor.Attributes.Add("href", dt.Rows[j]["AccessablePage"].ToString() + "x");
                                    subanchor.InnerText = dt.Rows[j]["Description"].ToString();
                                    subli.Controls.Add(subanchor);
                                    ul.Controls.Add(subli);
                                }
                            Looped.Add(Categories[x]);
                            li.Controls.Add(ul);
                        }

                }

        }
    }
}