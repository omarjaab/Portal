﻿using System;
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
                getGridView();
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
            // Grupp Drop Down List 
            ddlGrupp.DataSource = dp.getGroup();
            ddlGrupp.DataTextField = "Grupp";
            ddlGrupp.DataValueField = "Grupp";
            ddlGrupp.DataBind();
            // Avdelning Drop down list 
            ddlAvdelning.DataSource = dp.getAvdelning();
            ddlAvdelning.DataTextField = "fullAvdelning";
            ddlAvdelning.DataValueField = "Avdelning";
            ddlAvdelning.DataBind();
        }
        public void getGridView()
        {
            
            GvAllData.DataSource= dp.getAllData();
            GvAllData.DataBind();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (dp.CheckColumns(ddlGrupp.SelectedValue, int.Parse(ddlAvdelning.SelectedValue)).Rows.Count > 0)
            {
                lblMsg.Text = "item is already exist";
            }
            
            else
            dp.AddColumn(ddlGrupp.SelectedValue, int.Parse(ddlAvdelning.SelectedValue));
                lblMsg.Text = "item added ";
        }

        protected void GvAllData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dp.DeleteColumn(int.Parse(GvAllData.DataKeys[e.RowIndex]["ID"].ToString()));
            
        }

        //protected void GvAllData_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.Cells[0].Text=="")
        //        {
        //            System.Web.UI.WebControls.CommandField imgBtn = (System.Web.UI.WebControls.CommandField)e.Row.Cells[2].FindControl("");
        //            imgBtn.Visible = false;
        //        }
        //    }
        //}
    }
}