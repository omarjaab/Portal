<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agr_responsible.aspx.cs" Inherits="Portal.agr_responsible" %>
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
            <asp:UpdatePanel ChildrenAsTriggers="true" ID="MyUppdateDDR" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" PageSize="5"
                        AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55"  Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />                    
                         <Columns>
                            <asp:TemplateField HeaderText="Användar ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblstid" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
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
            <table  id="SubTable" >
                <tr>
                    <td >
                        <asp:Label ID="lblName" runat="server" Font-Bold="True" Text="Användare ID"></asp:Label>
                        <asp:TextBox ID="new_UserId" CellPadding="7"  runat="server" Width="433px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblEmailId" runat="server" Font-Bold="True" Text="Email"></asp:Label>
                        <asp:TextBox ID="new_EmailId" CellPadding="7" runat="server" Width="131px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"   />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>