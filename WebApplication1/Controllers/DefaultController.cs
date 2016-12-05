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
        string connectionGlobal =
            System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringDWGlobal"].ConnectionString;

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
        // LMC
        // Agreement/Search and mangment
        internal DataTable getAgreement(string uid)
        {
            try
            {
                dt = new DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter("exec [sp_Agr_Info] @userID", connection);
                Adapter.SelectCommand.Parameters.AddWithValue("@userID", uid);
                Adapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return new DataTable();//<--- Not finished yet
            }
        }
        internal DataTable get_TxtBox_Data(string UID, string AgreementType, string Company, string Division, string BusinessPartner, string Name, string OrgNr, string AgreementNr, string AgreementResponsible, string Department)
        {
            try
            {
                dt = new DataTable();
                //SqlConnection con = new SqlConnection(connection);
                //con.Open();
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = 60;
                SqlDataAdapter Adapter = new SqlDataAdapter("exec [sp_Agreement_Search]@UID,@AgreementType,@Company,@Division,@BusinessPartner,@Name,@OrgNr,@AgreementNr,@AgreementResponsible,@Department", con);
                Adapter.SelectCommand.Parameters.AddWithValue("@UID", UID);
                Adapter.SelectCommand.Parameters.AddWithValue("@AgreementType", AgreementType);
                Adapter.SelectCommand.Parameters.AddWithValue("@Company", Company);
                Adapter.SelectCommand.Parameters.AddWithValue("@Division", Division);
                Adapter.SelectCommand.Parameters.AddWithValue("@BusinessPartner", BusinessPartner);
                Adapter.SelectCommand.Parameters.AddWithValue("@Name", Name);
                Adapter.SelectCommand.Parameters.AddWithValue("@OrgNr", OrgNr);
                Adapter.SelectCommand.Parameters.AddWithValue("@AgreementNr", AgreementNr);
                Adapter.SelectCommand.Parameters.AddWithValue("@AgreementResponsible", AgreementResponsible);
                Adapter.SelectCommand.Parameters.AddWithValue("@Department", Department);
                Adapter.Fill(dt);
                return dt;
                con.Close();
            }
            catch (Exception e)
            {
                return new DataTable(); //<--- Not finished yet
            }
        }
        internal DataTable Agreement_search_Delete(string AgreementNumber, string Company, string Division)
        {
            try
            {
                dt = new DataTable();
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("exec [sp_Agr_Search_Delete] @AgreementNumber,@Company , @Division", con);
                cmd.Parameters.AddWithValue("@AgreementNumber", AgreementNumber);
                cmd.Parameters.AddWithValue("@Company", Company);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.ExecuteNonQuery();
                con.Close();
                return dt;
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        internal void CreateAgreement(string AgreementNumber, string Company, string Division)
        {
            try
            {
                dt = new DataTable();
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("exec [sp_Agr_Search_Delete] @AgreementNumber,@Company , @Division", con);
                cmd.Parameters.AddWithValue("@AgreementNumber", AgreementNumber);
                cmd.Parameters.AddWithValue("@Company", Company);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.ExecuteNonQuery();
                con.Close();
                //return dt;
            }
            catch (Exception e)
            {
                //Do a logging to file.
                //  return new DataTable();
            }
        }
        internal DataTable Get_AgreementResponsible_Create()
        {
            try
            {
                dt = new DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter("exec [SP_Agreement_Create_Responsible_DDL]", connection);
                Adapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return (dt);
            }
        }
        internal void Create_New_Contract()
        {
   
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
        // Bring_Cargo_Overdue_Invoices_Email 
        internal DataTable getOverdueInvoicesEmails()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("SELECT T1.[Lokasjon], T1.[TO] as mail_to, T1.[CC] as cc_to, T1.[Subject], T1.Body FROM DW_ADMIN.dbo.Bring_Cargo_Overdue_Invoices_Email_Adress_Incl_Body T1", connection);
            AC.Fill(dt);
            return dt;
        }

        internal void UpdateData(string email, string cc, string Subject, string body, string Lokasjon)

        {

            try

            {

                dt = new DataTable();

                SqlConnection con = new SqlConnection(connection);

                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE DW_ADMIN.dbo.Bring_Cargo_Overdue_Invoices_Email_Adress_Incl_Body SET [TO] = '" + email + "',[CC] = '" + cc + "',[Subject] = '" + Subject + "', [Body] = '" + body + "' WHERE Lokasjon = '" + Lokasjon + "'", con);

                cmd.ExecuteNonQuery();

                con.Close();



            }

            catch (Exception e)

            {

            }

        }

        internal void AddData(string Lokasjon, string TO, string CC, string Subject, string Body)

        {

            try

            {

                dt = new DataTable();

                SqlConnection con = new SqlConnection(connection);

                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT DW_ADMIN.dbo.Bring_Cargo_Overdue_Invoices_Email_Adress_Incl_Body ([Lokasjon],[TO],[CC],[Subject],[Body]) VALUES ('" + Lokasjon + "','" + TO + "','" + CC + "','" + Subject + "','" + Body + "')", con);

                cmd.ExecuteNonQuery();

                con.Close();
            }

            catch (Exception e)

            {

            }

        }

        internal void DeleteData(string Lokasjon)

        {

            try

            {

                dt = new DataTable();

                SqlConnection con = new SqlConnection(connection);

                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM DW_ADMIN.dbo.Bring_Cargo_Overdue_Invoices_Email_Adress_Incl_Body WHERE [Lokasjon] ='" + Lokasjon + "'", con);

                cmd.ExecuteNonQuery();

                con.Close();
            }

            catch (Exception e)

            {

            }

        }

        internal DataTable getLokasjon()

        {

            dt = new DataTable();

            SqlDataAdapter AC = new SqlDataAdapter("SELECT DISTINCT Avdelning as [Lokasjon] FROM DW_ADMIN.dbo.BRINGDK_Redovisning_Danmark ORDER BY Avdelning", connection);

            AC.Fill(dt);

            return dt;

        }

        public DataTable Get_Agreement_Responsible()
        {
            dt = new DataTable();
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter adp = new SqlDataAdapter("Select * from ResponsibleEmail", con);
            con.Open();
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        public void Update_Agreement_Responsible(string RowId, string EmailId)
        {
            SqlConnection con = new SqlConnection(connection);
             SqlCommand cmd = new SqlCommand("exec sp_UpdateResponsible @UserId, @EmailId", con);
            cmd.Parameters.AddWithValue("@UserId", RowId);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            con.Open();
            cmd.ExecuteNonQuery();
            
            con.Close();
        }

        public void Delete_Agreement_Responsible (string RowId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("EXEC sp_DeleteResponsible @UserId", con);
            cmd.Parameters.AddWithValue("@UserId", RowId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        internal DataTable getHFMCompleteTransactionForexport()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("Execute sp_HFMCOMPLETE_TRANSACTION_FOREXPORT", connection);
            AC.Fill(dt);
            return dt;
        }
        internal DataTable getHFMCompleteAadmin()
        {
            dt = new DataTable();
            SqlDataAdapter AC = new SqlDataAdapter("Execute sp_HFMComplete_Admin_Division_DropDown", connectionGlobal);
            AC.Fill(dt);
            return dt;
        }

        public void Insert_Agreement_Responsible(string UserId, string Email)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Execute sp_NewResponsible @UserId, @EmailId",con);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@EmailId", Email);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}