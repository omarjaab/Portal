<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agr_responsible.aspx.cs" Inherits="Portal.agr_responsible" Title="Avtalsansvariga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #SubTable{
            width:50%;
        }
         #SubTable td{
            width: 472px;
            Padding: 5px ;
        }
    </style>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="NotDDR" runat="server"></asp:ScriptManager>
               <div id="tabs">
  <ul>
    <li><a href="#tabs-1">Ansvariga</a></li>
    <li><a href="#tabs-2">Ny ansvarig</a></li>
  </ul>
  <div id="tabs-1" >
            <asp:UpdatePanel ChildrenAsTriggers="true" ID="MyUppdateDDR" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="EmailResponsibleGrid" runat="server" PageSize="10" Width="100%"
                        AllowPaging="true" OnPageIndexChanging="EmailResponsibleGrid_PageIndexChanging" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                        
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55"  Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Height="40px" />
                <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center"  VerticalAlign="Bottom"/>
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />                    
                         <Columns>
                            <asp:TemplateField HeaderText="Användarnamn">
                                <ItemTemplate>
                                    <asp:Label ID="lblstid" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="E-post">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEmailId" runat="server"> </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate >
                                    <asp:ImageButton  CommandArgument='<%# Container.DataItemIndex %>' CommandName="Row_Updating" ID="SaveButton" OnClick="SaveButton_Click" runat="server" ImageUrl="~/images/SaveIcon.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton  CommandArgument='<%# Container.DataItemIndex %>' CommandName="Row_Deleting" ID="DeleteButton" OnClick="DeleteButton_Click" runat="server" ImageUrl="~/images/DeleteIcon.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        
                    </asp:GridView>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
      </div>
                   <div id="tabs-2">
            <div class="col-lg-5">
                <div class="col-lg-2"  style="padding-top:5px; padding-left:0px"><asp:Label ID="lblName" runat="server" Font-Bold="True" Text="Användarnamn"></asp:Label></div>
                <div class="col-lg-10" style="padding-top:5px; padding-left:10px"> <asp:TextBox ID="new_UserId" CellPadding="7"  runat="server"></asp:TextBox></div>
                  <div class="col-lg-2"  style="padding-top:5px; padding-left:0px"><asp:Label ID="lblEmailId" runat="server" Font-Bold="True" Text="E-post"></asp:Label></div>
                <div class="col-lg-10"  style="padding-top:5px; padding-left:10px"><asp:TextBox ID="new_EmailId" CellPadding="7" runat="server" ></asp:TextBox></div>
             </div>
                  <div class="col-lg-11" style="text-align:right;padding-left:10px;padding-top:10px;text-align:right"><asp:Button ID="Submit" runat="server" Width="120px" Text="Lägg till" OnClick="Submit_Click"   /></div>
                    
                       
                 
        </div>
                   </div>
            </div>
    </form>
</asp:Content>