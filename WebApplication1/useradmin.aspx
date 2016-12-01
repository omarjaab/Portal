<%@ Page  Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="useradmin.aspx.cs" Inherits="Portal.useradmin" title="Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    


           
    <form runat="server" >
     <asp:ScriptManager ID="mngr" runat="server"></asp:ScriptManager>
        <div id="tabs">
  <ul>
    <li><a href="#tabs-1">Behörigheter</a></li>
    <li><a href="#tabs-2">Ny användare</a></li>
  </ul>
  <div id="tabs-1" >
  
        <div class="col-lg-12">
      <div class="custom-wrapper">
        <div class="col-lg-2"  ><b>Användarnamn</b></div>
            <div class="col-lg-2" ><b>Lösenord</b></div>
            <div class="col-lg-3" ><b>Tillåtna applikationer</b></div>
            <div class="col-lg-2" ><b>Avtalstyper</b></div>
            <div class="col-lg-3"  ><b>Divisioner</b></div>  
            <div  class="col-lg-2"   >
                <div id="UserListContainer" runat="server" style="width:auto; height:50px; position:-ms-page; vertical-align:top;" >
               
                    <asp:DropDownList   DataValueField="Id" DataTextField="Name" CssClass="selectpicker" data-live-search="true" ID="usersddl" AutoPostBack="true" runat="server" OnSelectedIndexChanged="usersddl_SelectedIndexChanged">
                    </asp:DropDownList>
            
                </div>
            </div>

            <div class="col-lg-2"  >
                <asp:UpdatePanel ID="Password_Panel" runat="server">
                    <ContentTemplate>
                         <div  id="passwordContainer" runat="server" style="width:auto; height:50px; position:-ms-page" >
                             <asp:TextBox ID="PasswordTextBox" runat="server"  Width="100%" BackColor="White"></asp:TextBox>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
              </div>
           
             <div   class="col-lg-3" >
                <asp:UpdatePanel ID="applic_listbox_Panel" runat="server">
                    <ContentTemplate>
                         <div   class="custom-dropdown-wrapper">
                             <asp:CheckBoxList ID="applicationschklbox"  DataValueField="Id" DataTextField="Name"  runat="server" CssClass="checkbox checkbox-success"></asp:CheckBoxList>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
              </div>
             
              <div  class="col-lg-2" >
                <asp:UpdatePanel ID="agr_listbox_Panel" runat="server">
                    <ContentTemplate>
                         <div class="custom-dropdown-wrapper" >
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
              </div>
              
             <div  class="col-lg-3">
                <asp:UpdatePanel ID="Division_Panel" runat="server">
                    <ContentTemplate>
                         <div class="custom-dropdown-wrapper" >
                           <asp:CheckBoxList  DataValueField="Id" DataTextField="Name"  ID="divisionerchklbox" runat="server" CssClass="checkbox checkbox-success"></asp:CheckBoxList>
                         </div>
           
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="usersddl" EventName ="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
              </div>
</div>
        </div>
      <br />
      <br />       
        
       <div class="col-lg-12" style="padding-top:25px;">
           <div class="col-lg-11">
                        <div class="col-lg-11" style="text-align:right;"></div><div class="col-lg-1" style="text-align:right;">
                           <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Spara"   UseSubmitBehavior="False" width="120px" />
                 </div>
                        </div><div class="col-lg-1">
                   <div> <asp:Button runat="server" ID="btnDeleteUser"  Text="Ta bort" OnClick="btnDeleteUser_Click" /></div> 
                         </Div></div>
 
  </div>
  <div id="tabs-2">
      
      
          <div>
                <asp:Panel ID="Panel1" runat="server" ><!--CssClass="auto-style17">-->
                    <br />
                    <br />
                    <div class="col-lg-6" >
                        <div class="col-lg-4"><b>Användarnamn</b> </div>
                        <div class="col-lg-8"> <asp:TextBox ID="txtUserNamePanel" runat="server"></asp:TextBox></div>

                        <div class="col-lg-4" style="padding-top:25px;"> <b>Lösenord</b></div>
                        <div class="col-lg-8" style="padding-top:25px;"> <asp:TextBox ID="txtPasswordPanel" runat="server"></asp:TextBox></div>
                    </div>
                   
                    <div class="col-lg-12" style="padding-top:25px;">
                        <div class="col-lg-10">

                        </div><div class="col-lg-2">
                   <div><asp:Button ID="btnAddUser" runat="server" Text="Lägg till" OnClick="btnAddUser_Click"  /></div> 
                         </Div></div>
                    <br />
                    <br />
                </asp:Panel>
            </div>
       </div>
  
</div>

                <br />
        <br />
        <br />
        <br />
               
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
        /*.LastCell {
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
            height: 141px;
        }
        .auto-style20 {
            width: 210px;
        }
        .auto-style21 {
            margin-left: 8px;
        }
        .auto-style22 {
            width: 217px;
            height: 141px;
        }
        .auto-style23 {
            width: 210px;
            height: 141px;
        }
        .auto-style24 {
            width: 377px;
            height: 141px;
        }
        .auto-style25 {
            width: 228px;
            height: 141px;
        }*/
        </style>

</asp:Content>

