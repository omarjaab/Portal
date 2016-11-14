<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="tipsadmin.aspx.cs" Inherits="Portal.tipsadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<form runat="server">
    <asp:ScriptManager runat="server" ID="manager1"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
    <h2>Administration körningsdatum TIPS </h2>

    <div> 
        <h4>Avräkning</h4>
        <asp:GridView ID="Gv_Avräkning" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" >
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
                <asp:BoundField HeaderText="Period" ShowHeader="true" DataField="Period"  />
                <asp:TemplateField  HeaderText="Datum"><ItemTemplate><asp:Textbox ID="txtDatumAvräkning" runat="server"></asp:Textbox></ItemTemplate></asp:TemplateField>
                <asp:TemplateField  HeaderText="Calender"><ItemTemplate>
                    <asp:ImageButton ID="Calendar1" ClientIDMode="AutoID" runat="server"  src="images/calendar2.png" Style="width:20px; height:20px;" OnClick="Calendar2_Click" /> <asp:Calendar OnVisibleMonthChanged="Calendar3_VisibleMonthChanged"  OnSelectionChanged="Calendar3_SelectionChanged" ID="Calendar3" runat="server" Visible="false" Style="position:-ms-page ; width:100px;height:auto; background-color:white" ></asp:Calendar></ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br /><br /><br /><br />
    <div> 
        <h4>Fakturering</h4>
        <asp:GridView ID="Gv_Fakturering" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
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
                <asp:BoundField HeaderText="Period" ShowHeader="true" DataField="Period"  />
                <asp:TemplateField  HeaderText="Datum"><ItemTemplate><asp:Textbox ID="txtDatumFakturering" runat="server"></asp:Textbox></ItemTemplate></asp:TemplateField>
                 <asp:TemplateField  HeaderText="Calender"><ItemTemplate>
                    <asp:ImageButton ID="Calendar2" runat="server" src="images/calendar2.png" Style="width:20px; height:20px;" OnClick="Calendar2_Click"/></ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
               
                                </ContentTemplate>
         
</asp:UpdatePanel>
</form>
</asp:Content>
