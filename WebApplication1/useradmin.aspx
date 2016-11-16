<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="useradmin.aspx.cs" Inherits="Portal.useradmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    


    <form runat="server">
        <asp:ScriptManager ID="updatedata" runat="server"  ></asp:ScriptManager>
        <asp:UpdatePanel ID="update" runat="server" UpdateMode="Always" AutoPostBack="true">
           
            <ContentTemplate>  
<table>
        <tr>
            <td  >Användarnamn</td>
            <td class="auto-style15" >Lösenord</td>
            <td class="auto-style16" >Tillåtna applikationer</td>
            <td class="auto-style14" >AvtalsTyper</td>
            <td class="auto-style7"  >Divisioner</td>
        </tr>
        
        <tr>
            <br />
            <td   id="UserListContainer" runat="server"  ></td>
            <br />
            <td class="auto-style15" id="PasswordContainer" runat="server" >
             
            </td>
 
            <td class="auto-style16" ><div id="ApplicationContainer" runat="server" style="OVERFLOW-Y:scroll;width:auto; height:200px; position:-ms-page"></div></td>

            <td class="auto-style14"   ><div id="agreement" runat="server" style="width:auto; height:200px; position:-ms-page " ></div></td>
           
            <td ><div id="Division" runat="server" style="OVERFLOW-Y:scroll;width:auto; height:200px; position:-ms-page"></div></td>
        </tr>
            </table>
                <br /><br /><br /><br />
                <br /><br /><br /><br />
      <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Spara"   UseSubmitBehavior="False" /> 
                <br />
                <asp:Button runat="server" ID="btnDeleteUser"  Text="Delete" OnClick="btnDeleteUser_Click" />
           <%-- <label runat="server" id="lbl"></label>--%>
                <br />
                <br />
                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" CssClass="auto-style17">
                    <br />
                    <br />
                    <asp:Label ID="lblUserName" runat="server" Text="Användarnamn"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtUserNamePanel" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Lösenord"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPasswordPanel" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnAddUser" runat="server" Text="Lägg till" OnClick="btnAddUser_Click"  />
                    <br />
                    <br />
                </asp:Panel>
                <br />
                </ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnAddUser"  EventName="Click"   />
<asp:AsyncPostBackTrigger ControlID="btnSave"  EventName="Click"   />
</Triggers>
</asp:UpdatePanel>  
     
      
         
    </form>

         
    <br />
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        /*.auto-style16 {
            width: 398px;
        }
        .auto-style17 {
            height: 100px;

            width: 398px;
        }
        .auto-style18 {
            width: 1396px;

        }
        .auto-style20 {
            width: 167px;
        }
        .auto-style21 {
            width: 421px;
        }
        .auto-style22 {
            height: 100px;

            width: 421px;
        }
        .auto-style23 {
            width: 420px;
        }
        .auto-style24 {
            height: 100px;

            width: 420px;
        }
        .auto-style25 {
            width: 256px;
        }
        .auto-style26 {
            width: 444px;
        }
        .auto-style27 {*/

        /*}*/
        .auto-style7 {
            width: 413px;
        }
        .auto-style14 {
            width: 390px;
        }
        .auto-style15 {
            width: 200px;
        }
        .auto-style16 {
            width: 720px;
        }
        .auto-style17 {
            margin-bottom: 0px;
        }
        </style>

</asp:Content>

