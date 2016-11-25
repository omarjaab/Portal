<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bring_Cargo_Overdue_Invoices_Email.aspx.cs" Inherits="Portal.Bring_Cargo_Overdue_Invoices_Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <h3>Bring Cargo A/S - Förfallna fakturor</h3>
    <h5>Används för utskick av rapporten "Förfallna fakturor per lokasjon"</h5>
    <form runat="server">
       <asp:ScriptManager runat="server" ID="manager1"  ></asp:ScriptManager>
       <asp:UpdatePanel runat="server" ID="updatepanel1" ChildrenAsTriggers="true" UpdateMode="always" >
       <ContentTemplate>
        <asp:GridView ID="gvAllData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
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
                <asp:TemplateField  HeaderText="Lokasjon"><ItemTemplate><asp:label ID="Lokasjon" runat="server"></asp:label></ItemTemplate></asp:TemplateField> 
                <asp:TemplateField  HeaderText="E-mail"><ItemTemplate><asp:Textbox ID="txtEmail" runat="server" Height="70px" Width="220px" TextMode="MultiLine"></asp:Textbox></ItemTemplate></asp:TemplateField>
                <asp:TemplateField  HeaderText="cc" ><ItemTemplate ><asp:Textbox ID="txtcc" runat="server"  Height="70px" Width="220px" TextMode="MultiLine"></asp:Textbox></ItemTemplate></asp:TemplateField>
                <asp:TemplateField  HeaderText="Subject" ><ItemTemplate ><asp:Textbox ID="txtSubject" runat="server" Height="70px" Width="325px" TextMode="MultiLine"></asp:Textbox></ItemTemplate></asp:TemplateField>
                <asp:TemplateField  HeaderText="Text" ><ItemTemplate ><asp:Textbox ID="txtBody" runat="server"  Height="70px" Width="325px" TextMode="MultiLine"></asp:Textbox></ItemTemplate></asp:TemplateField>
                </Columns>
        </asp:GridView>
         &nbsp;<br />
           <br />
           <br />
        <asp:Button ID="BtnSave" runat="server" Text="Spara" OnClick="BtnSave_Click" />
            &nbsp;<br />
           <br />
           <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click"/>
            </Triggers>
</asp:UpdatePanel>
       <asp:UpdatePanel runat="server" ID="updatepanel11" ChildrenAsTriggers="true" UpdateMode="always">
       <ContentTemplate>
           <table>
        <tr>
            <td>Lokasjon</td>
            <td>E-mail</td>
            <td>cc</td>
            <td >Subject</td>
            <td >Text</td>
        </tr>
         <tr>
            <td>
                <asp:DropDownList ID="ddlLokasjon" runat="server" CssClass="selectpicker"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtEmailAdd" runat="server" Height="70px" Width="220px" TextMode="MultiLine"></asp:TextBox> 
            </td>
            <td>
                <asp:TextBox ID="txtccAdd" runat="server" Height="70px" Width="220px" TextMode="MultiLine"></asp:TextBox> 
            </td>
            <td >
                <asp:TextBox ID="txtSubjectAdd" runat="server" Height="70px" Width="220px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td >
                 <asp:TextBox ID="txtBodyAdd" runat="server" Height="70px" Width="300px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        </table>
               <asp:Button ID="BtnAdd" runat="server" Text="Lägg till" OnClick="BtnAdd_Click"  /> 
           <asp:Button ID="BtnDelete" runat="server" Text="Rensa" OnClick="BtnDelete_Click"/>
         </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click"/>
            </Triggers>
</asp:UpdatePanel>
    </form>
</asp:Content>
