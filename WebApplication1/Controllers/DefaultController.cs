using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
 
using System.Web.UI.HtmlControls;

namespace Portal.Controllers
{
    public class DefaultController
    {
        DataTable dt = new DataTable();

        string connection =
            System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWAdmin"].ConnectionString;


        public DataTable Login(string username, string password)
        {

            dt = new DataTable();
            //if (u.uname != null)
            //{
            SqlDataAdapter Adapter = new SqlDataAdapter("exec sp_logon @uname, @password", connection);
            Adapter.SelectCommand.Parameters.AddWithValue("@uname", username);
            Adapter.SelectCommand.Parameters.AddWithValue("@password", password);
            Adapter.Fill(dt);
            //    if (dt != null)
            //    {
            //         return dt;
            //    }
            //    //return RedirectToAction("index");
            ////}
            return dt;
        }

        public DataTable GetAdminInformation()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("Execute sp_Admin_Information", connection);
            AC.Fill(dt);
            return dt;
        }

        internal DataTable GetUserPermissionInfo(string userId)
        {

            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("Execute [sp_GetUserPermissionInfo] @userId", connection);
            AC.SelectCommand.Parameters.AddWithValue("@userId", userId);
            AC.Fill(dt);
            return dt;

        }
        //internal DataTable getuserapplication(string userId)
        //{

        //    dt = new DataTable();
        //    SqlDataAdapter AC = new SqlDataAdapter("Execute sp_UserApplication @userId", connection);
        //    AC.SelectCommand.Parameters.AddWithValue("@userId", userId);
        //    AC.Fill(dt);
        //    return dt;

        //}

        //internal DataTable getuserAgreement(string userId)
        //{

        //    dt = new DataTable();
        //    SqlDataAdapter AC = new SqlDataAdapter("Execute sp_UserAgreement @userId", connection);
        //    AC.SelectCommand.Parameters.AddWithValue("@userId", userId);
        //    AC.Fill(dt);
        //    return dt;

        //}

        //internal DataTable getuserDivision(string userId)
        //{

        //    dt = new DataTable();
        //    SqlDataAdapter AC = new SqlDataAdapter("Execute sp_UserDivision2 @userId", connection);
        //    AC.SelectCommand.Parameters.AddWithValue("@userId", userId);
        //    AC.Fill(dt);
        //    return dt;

        //}

        internal string InsertObjectsIntoDB(List<Object> inputList)
        {
            try
            {
                string query = "";
                for (int i = 0; i < inputList.Count; i++)
                {
                    query += "<row>";
                    query += "<Type>" + inputList[i].oType + "</Type>";
                    query += "<Id>" + inputList[i].oId + "</Id>";
                    query += "<Value>" + inputList[i].oValue + "</Value>";
                    query += "</row>";
                }
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("EXEC sp_SaveObjects @Xml", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Xml", query);

                cmd.ExecuteNonQuery();

                conn.Close();

                return "success";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
       
        //internal DataTable getCurrency()
        //{
        //    dt = new DataTable();
        //    SqlDataAdapter AC = new SqlDataAdapter("select DISTINCT   month ([Rate date from]) as Month  from[dbo].[Currency_rates] order by Month Asc ", connection);
        //    AC.Fill(dt);
        //    return dt;
        //}
        internal DataTable checkValuta(string valuta)
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter(" SELECT * FROM Currency WHERE Currency='"+valuta+"' ", connection);
            AC.Fill(dt);
            return dt;
        }
        internal DataTable getHFMAdminitrationDivision()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("Execute sp_HFM_AdminitrationDivision_DropDown", connection);
            AC.Fill(dt);
            return dt;
        }

        internal DataTable Currency(string year ,string month)
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("exec[dbo].[sp_GetCurrency] @year,@month", connection);
            AC.SelectCommand.Parameters.AddWithValue("@year", year);
            AC.SelectCommand.Parameters.AddWithValue("@month", month);
            AC.Fill(dt);
           
            return dt;
        }

        internal void Currency_Save(int year, int month, string Currency_code, double Average_rate, double Closing_rate)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("exec [dbo].[sp_Currency] @Year,@Period,@Currency_code,@Average_rate,@Closing_rate", con);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@Period", month);
                cmd.Parameters.AddWithValue("@Currency_code", Currency_code);
                cmd.Parameters.AddWithValue("@Average_rate", Average_rate);
                cmd.Parameters.AddWithValue("@Closing_rate", Closing_rate);
                cmd.ExecuteNonQuery();
            }

        }
        



        // Redovisning Denmark 
        internal DataTable getGroup()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("SELECT DISTINCT [Avdelning] as [Grupp] FROM DW_ADMIN.dbo.BRINGDK_Redovisning_Danmark", connection);
            AC.Fill(dt);
            return dt;
        }
        internal DataTable getAvdelning()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("select distinct [Balance dimension 2]as Avdelning, ([Balance dimension 2] +' - '+ [Balance dimension 2 name])as fullAvdelning from DW_GLOBAL..Dim_Accounting_Structure where Division='341' order by 1 ", connection);
            AC.Fill(dt);
            return dt;
        }

        internal DataTable getAllData()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("select ID,Grupp,Avdelningskod,Avdelningsnamn from [BRINGDK_Redovisning_Danmark_View] where Avdelningskod > -1 order by Grupp_sort, Sort, Avdelningskod", connection);
            AC.Fill(dt);
            return dt;
        }
        internal DataTable CheckColumns(string Group,int avdelning)
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("select * from BRINGDK_Redovisning_Danmark where Avdelning='"+Group+"' and Redkod="+avdelning+"", connection);
            AC.Fill(dt);
            return dt;
            

            

        }
        internal void AddColumn(string Group, int avdelning)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT BRINGDK_Redovisning_Danmark (Redkod,Avdelning) VALUES('" + avdelning + "','" + Group + "') ", con);

                cmd.ExecuteNonQuery();

            }
        }

        internal void DeleteColumn (int id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM BRINGDK_Redovisning_Danmark WHERE [ID] ="+id+" ", con);

                cmd.ExecuteNonQuery();

            }
        }




        // Tips Admin Page 
        internal DataTable getAvräkning()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("SELECT Period FROM TIPS_Avrakningsdatum WHERE Status = 'EJ KÖRD' ORDER BY Period", connection);
            AC.Fill(dt);
            return dt;
        }
        internal DataTable getFakturering()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("SELECT Period FROM TIPS_Faktureringsdatum WHERE Status = 'EJ KÖRD' ORDER BY Period", connection);
            AC.Fill(dt);
            return dt;
        }
    }
}