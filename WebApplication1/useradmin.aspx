<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="useradmin.aspx.cs" Inherits="Portal.useradmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    


    <form runat="server" >
     <asp:ScriptManager ID="mngr" runat="server"></asp:ScriptManager>
<table>
        <tr>
            <td class="auto-style18"  >Användarnamn</td>
            <td class="auto-style20" >Lösenord</td>
            <td class="auto-style16" >Tillåtna applikationer</td>
            <td class="auto-style14" >AvtalsTyper</td>
            <td class="auto-style7"  >Divisioner</td>
        </tr>
        
        <tr>
            <td class="auto-style18" >
                <div id="UserListContainer" runat="server" style="width:auto; height:250px; position:-ms-page" >
               
                    <asp:DropDownList   DataValueField="Id" DataTextField="Name" CssClass="selectpicker" data-live-search="true" ID="usersddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="usersddl_SelectedIndexChanged">
                    </asp:DropDownList>
            
                </div>
            </td>

            <td class="auto-style20" >
                <asp:UpdatePanel ID="t1" runat="server">
                    <ContentTemplate>
                         <div  id="passwordContainer" runat="server" style="width:auto; height:250px; position:-ms-page" >
                             <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="auto-style21" Width="147px"></asp:TextBox>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
              </td>
            <td class="auto-style16" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <div   style="width:auto; height:250px; position:-ms-page; overflow-y:scroll" >
                             <asp:CheckBoxList ID="applicationschklbox"  DataValueField="Id" DataTextField="Name"  runat="server" CssClass="checkbox checkbox-success"></asp:CheckBoxList>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
              </td>
               <td class="auto-style14" >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                         <div  style="width:auto; height:250px; position:-ms-page;"  >
                           <asp:CheckBoxList DataValueField="Id" DataTextField="Name"  ID="agreementchklbox" runat="server" CssClass="checkbox checkbox-success"></asp:CheckBoxList>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                         <asp:AsyncPostBackTrigger ControlID="btnSave" EventName ="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDeleteUser" EventName ="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAddUser" EventName ="Click" />
                    </Triggers>
                </asp:UpdatePanel>
              </td>
               <td class="auto-style19" >
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                         <div  style="width:auto; height:250px; position:-ms-page; overflow-y:scroll" >
                           <asp:CheckBoxList  DataValueField="Id" DataTextField="Name"  ID="divisionerchklbox" runat="server" CssClass="checkbox checkbox-success"></asp:CheckBoxList>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
              </td>
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
            width: auto;
        }
        .auto-style14 {
            width: 228px;
        }
        .auto-style16 {
            width: 377px;
        }
        .auto-style17 {
            margin-bottom: 0px;
        }
        .auto-style18 {
            width: 217px;
        }
        .auto-style19 {
            width: auto;
        }
        .auto-style20 {
            width: 210px;
        }
        .auto-style21 {
            margin-left: 8px;
        }
        </style>

</asp:Content>

