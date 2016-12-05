<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="redovisning_danmark.aspx.cs" Inherits="Portal.redovisning_danmark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<form runat="server">
                  <asp:ScriptManager runat="server" ID="manager2" EnablePartialRendering="true"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="updatepanel2" UpdateMode="Always" ChildrenAsTriggers="true" >
            <ContentTemplate>
    <h3>Redovisning Danmark</h3>
    <table>
        <tr>
            <td>Grupp</td>
            <td>Avdelning</td>
            <td>       </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlGrupp" runat="server" CssClass="selectpicker" data-live-search="true"></asp:DropDownList>

            </td>
            <td>
                <asp:DropDownList ID="ddlAvdelning" runat="server" CssClass="selectpicker" data-live-search="true"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Lägg till" OnClick="btnAdd_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <br />

    <asp:GridView ID="GvAllData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"   OnRowDeleting="GvAllData_RowDeleting" OnRowDataBound="GvAllData_RowDataBound" DataKeyNames="ID" width="100%">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
        
         <Columns>
        <asp:BoundField HeaderText="ID" ShowHeader="true" DataField="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" >
             <HeaderStyle CssClass="hiddencol" />
             <ItemStyle CssClass="hiddencol" />
             </asp:BoundField>
        <asp:BoundField HeaderText="Grupp" ShowHeader="true" DataField="Grupp"  />
        <asp:BoundField HeaderText="Avdelningskod" ShowHeader="true" DataField="Avdelningskod"  />
        <asp:BoundField HeaderText="Avdelningsnamn" ShowHeader="true" DataField="Avdelningsnamn"  /> 
            
           
             <asp:CommandField  DeleteImageUrl="~/images/DeleteIcon.png" ShowDeleteButton="True" ButtonType="Image" ControlStyle-Height="25px" ControlStyle-Width="25px"  />
            
           
         </Columns>
        
    </asp:GridView>
  </ContentTemplate>
            <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"/>
              <asp:AsyncPostBackTrigger ControlID="GvAllData" EventName="RowCommand" />
            </Triggers>
</asp:UpdatePanel>
</form>
</asp:Content>
