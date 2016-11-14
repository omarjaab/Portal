<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="hfmadmin.aspx.cs" Inherits="Portal.hfmadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navigation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <form id="form1" runat="server">
        <p >Division:</p><p id="DropDownDivisionPlace" runat="server"></p>
<%--        <asp:DropDownList ID="DropDownDivision" runat="server" DataSourceID="sp_HFM_AdminitrationDivision_DropDown" DataTextField="Division descr" DataValueField="Sort_order">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sp_HFM_AdminitrationDivision_DropDown" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringDWAdmin %>" SelectCommand="sp_HFM_AdminitrationDivision_DropDown" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <br />--%>
            <br />
        <p>Välj år och månad:</p><p id="DropDownYearPlace" runat="server"></p><p id="DropDownMounthPlace" runat="server"></p>
<%--        <asp:DropDownList ID="DropDownYear" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownMounth" runat="server" OnSelectedIndexChanged="DropDownMounth_SelectedIndexChanged">
        </asp:DropDownList>--%>
        <br />
        <br />
        Go to
    </form>

</asp:Content>
