<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="hfmadmin.aspx.cs" Inherits="Portal.hfmadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <form id="form1" runat="server">
        <p >Division:</p><p id="DropDownDivisionPlace" runat="server"></p>
            <br />
        <p>Välj år och månad:</p><p id="DropDownYearPlace" runat="server"></p><p id="DropDownMounthPlace" runat="server"></p>
        <br />
        <br />
        Go to
    </form>

</asp:Content>
