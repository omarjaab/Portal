<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="hfmcomplete_admin.aspx.cs" Inherits="Portal.hfmcomplete_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navigation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
        <asp:Label ID="Label1" runat="server" Text="Version"></asp:Label>
        
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownVersion" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Division"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownDivision" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="År och månad"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownYears" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownMounths" runat="server">
        </asp:DropDownList>
    </form>
</asp:Content>
