using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Portal
{
    public class Object
    {
        public string oType { get; set; }
        public string oValue { get; set; }
        public string oId { get; set; }
        public string oPassword { get; set; }
        public string oName { get; set; }

        public Object(string oType, string oName, string oId, string oPassword)
    {
        this.oType= oType;
        this.oName = oName;
        this.oId = oId;
        this.oPassword = oPassword;
    }
        public Object(string oType, string oId, string oValue)
        {
            this.oType = oType;
            this.oValue = oValue;
            this.oId = oId;
        }

        public Object()
        {
          
        }

        public void RefreshPage(int PageNumber,GridView gv)
        {
            DataTable ds = new DataTable();
            ds = ((DataTable)gv.DataSource);
            int min = 0;
            if (PageNumber > 0)
                min = PageNumber * gv.PageSize;
            int max = ((PageNumber + 1) * gv.PageSize) - 1;
            int mod = ds.Rows.Count % 10;
            int maxPage = 0;
            maxPage = ds.Rows.Count / 10;
            if ((PageNumber != maxPage))
                maxPage = (gv.PageSize + 1);
            for (int i = 0; i < maxPage; i++)
            {
                Label stId = new Label();
                stId = gv.Rows[i].Cells[0].FindControl("lblstid") as Label;
                TextBox EmailId = new TextBox();
                EmailId = gv.Rows[i].Cells[0].FindControl("txtEmailId") as TextBox;
                stId.Text = ds.Rows[min]["UserID"].ToString();
                EmailId.Text = ds.Rows[min]["Email"].ToString();
                min++;
                if (min == (max + 1))
                    break;
            }
        }
    }

  
}