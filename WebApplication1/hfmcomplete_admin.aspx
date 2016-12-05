<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="hfmcomplete_admin.aspx.cs" Inherits="Portal.hfmcomplete_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
        <asp:Label ID="Versionlbl" runat="server" Text="Version"></asp:Label>
        
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownVersion" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Divisionlbl" runat="server" Text="Division"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownDivision" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Datelbl" runat="server" Text="År och månad"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownYears" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownMounths" runat="server">
        </asp:DropDownList>
    </form>
</asp:Content>
