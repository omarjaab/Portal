<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="redovisning_danmark.aspx.cs" Inherits="Portal.redovisning_danmark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<form runat="server">
    <h3>Redovisning Danmark</h3>
    <table>
        <tr>
            <td>Grupp</td>
            <td>Avdelning</td>
            <td>       </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlGrupp" runat="server"></asp:DropDownList>

            </td>
            <td>
                <asp:DropDownList ID="ddlAvdelning" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Lägg till" />
            </td>
        </tr>
    </table>

    gridview here 
</form>
</asp:Content>
