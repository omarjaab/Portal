<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="valutaadmin.aspx.cs" Inherits="Portal.valutaadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="manager1"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
        
    <asp:Panel ID="firstPage" runat="server">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Välj uppgift: "></asp:Label>
        <br />
        <br />
        <asp:RadioButtonList ID="rblCurrency" runat="server">
            <asp:ListItem >Lägg in kursinformation</asp:ListItem>
            <asp:ListItem  >Lägg till ny valutakod</asp:ListItem>
        </asp:RadioButtonList>

        <br />
        <br />
        

    </asp:Panel>

        <asp:Panel ID="secondPage" runat="server" Visible="false">
            <br />
            <asp:Label ID="Label2" runat="server" Text="Välj valutaperiod: "></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlYear" runat="server">
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="ddlMonth" runat="server">
            </asp:DropDownList>
                 <br />
            <br />
            &nbsp;
            <br />

                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    <asp:Button ID="btnSpara" runat="server" Text="Save" OnClick="btnSpara_Click" />
                        <br />
            <br />
            &nbsp;
            <br />

            <asp:GridView ID="GridViewCurrency" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
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
                    <asp:BoundField HeaderText="CurrencyCode" ShowHeader="true" DataField="CurrencyCode"  />
                    
                    <asp:TemplateField  HeaderText="AverageRate"><ItemTemplate><asp:Textbox ID="txtAverage" runat="server"></asp:Textbox></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField  HeaderText="ClosingRate" ><ItemTemplate ><asp:Textbox ID="txtClosing" runat="server"></asp:Textbox></ItemTemplate></asp:TemplateField>
                    <asp:BoundField HeaderText="From Date" ShowHeader="true" DataField="FromDate" />
                    <asp:BoundField HeaderText="To Date" ShowHeader="true" DataField="ToDate"  />
                </Columns>
            </asp:GridView>
<%--            <div>
                <table>
        <tr>
            <td  >Currency Code</td>
            <td  >Average</td>
            <td  >Closing</td>

        </tr>
        
        <tr>
            <td id="CurrCodeContainer" runat="server" ></td>
            <td id="averageContainer" runat="server"></td>
            <td id="closingContainer" runat="server"></td>
        </tr>
      </table>
            </div>--%>
            
            <br />
            <br />

        </asp:Panel>


        <asp:Panel ID="thirdPage" runat="server" Visible="false">
                        <br />
            <h3>Mata in ny valutakod:</h3>
            <br />
            <br />
            <asp:TextBox ID="txtvalutaInput" runat="server"></asp:TextBox>
            
            &nbsp;
            
            
            

        </asp:Panel>

        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Visible="false" />

        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddValuta" runat="server" Text="Add"  Visible="false" OnClick="btnAddValuta_Click"/>
        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
             <br />
           
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click"/>
            </Triggers>
</asp:UpdatePanel>

    </form>
</asp:Content>
