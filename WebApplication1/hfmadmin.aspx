<%@ Page Title="HFM - Complete" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="hfmadmin.aspx.cs" Inherits="Portal.hfmadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <form id="form1" runat="server">
            <div class="col-lg-5">
                <div class="col-lg-3" style="padding-top:10px"><b>Division</b></div>
                <div class="col-lg-9"  style="padding-top:10px">
                    <asp:DropDownList ID="DropDownDivision" runat="server" CssClass="selectpicker" 
                        data-live-search="true" DataValueField="Sort_order" DataTextField="Division descr" Width="100%"></asp:DropDownList>
                     </div>
                <div class="col-lg-3"  style="padding-top:10px"><b>Välj år och månad</b></div>
                <div class="col-lg-4"  style="padding-top:10px">
                   
                    <asp:DropDownList ID="DropDownYear" runat="server" CssClass="selectpicker" 
                        data-live-search="true" DataValueField="Sort_order" DataTextField="Division descr" Width="100%"></asp:DropDownList>
                    
                       
                    </div>
                <div class="col-lg-4"  style="padding-top:10px">
                         <asp:DropDownList ID="DropDownMonth" runat="server" CssClass="selectpicker" 
                        data-live-search="true" DataValueField="Sort_order" DataTextField="Division descr" Width="100%"></asp:DropDownList>
                </div>
            </div>
        
        
                  <div class="col-lg-11" style="text-align:right;padding-left:10px;padding-top:10px;text-align:right">
                      <asp:Button ID="Submit" runat="server" Width="220px" Text="Generera fil" OnClick="Submit_Click" />
                  </div>
    </form>

</asp:Content>
