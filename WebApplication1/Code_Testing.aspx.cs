using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Code_Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable uniquemgmtcmdetails = meetingdetails.AsEnumerable() // Getting 2 rows to datatable uniquemgmtcmdetails 
                               .GroupBy(r => r.Field<string>("Title"))
                               .Select(g => g.First())
                               .CopyToDataTable();

            if (uniquemgmtcmdetails.Rows.Count > 0)  // since count is 2 this condition is ture
            {
                if (!string.IsNullOrEmpty(uniquemgmtcmdetails.Rows[0]["Title"].ToString()))  // first row title field is empty so it is exiting but i have value in second row how can i take second row value.
                {
                    writer.WriteStartElement("ManagementCompanyAttendees");

                    for (int k = 0; k < uniquemgmtcmdetails.Rows.Count; k++)
                    {
                        writer.WriteStartElement("Attendee");
                        writer.WriteAttributeString("Title", null, uniquemgmtcmdetails.Rows[k]["Title"].ToString());
                        writer.WriteFullEndElement();

                    }
                    writer.WriteEndElement();// end Management Compnay Attendences
                }
            }




            DataTable uniquemgmtcmdetails = meetingdetails.AsEnumerable() // Getting 2 rows to datatable uniquemgmtcmdetails 
                               .GroupBy(r => r.Field<string>("Title"))
                               .Select(g => g.First())
                               .CopyToDataTable();

            if (uniquemgmtcmdetails.Rows.Count > 0)  // since count is 2 this condition is ture
                                {
                writer.WriteStartElement("ManagementCompanyAttendees");

                //Use for statement to loop through each row.
                for (int k = 0; k < uniquemgmtcmdetails.Rows.Count; k++)
                {
                    //Check whether the title in current row is empty. If it is not empty, generate xml file.
                    if (!string.IsNullOrEmpty(uniquemgmtcmdetails.Rows[k]["Title"].ToString()))  // first row title field is empty so it is exiting but i have value in second row how can i take second row value.
                                    {

                        writer.WriteStartElement("Attendee");
                        writer.WriteAttributeString("Title", null, uniquemgmtcmdetails.Rows[k]["Title"].ToString());
                        writer.WriteFullEndElement();

                        writer.WriteEndElement();// end Management Compnay Attendences
                    }
                }
            }
        }
    }
}


