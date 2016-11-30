<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bring_Cargo_Overdue_Invoices_Email.aspx.cs" Inherits="Portal.Bring_Cargo_Overdue_Invoices_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bring Cargo A/S - Förfallna fakturor</h3>
    <h5>Används för utskick av rapporten "Förfallna fakturor per lokasjon"</h5>
    <form runat="server">
        <asp:ScriptManager runat="server" ID="manager1"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updatepanel1" ChildrenAsTriggers="true" UpdateMode="always">
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
                        <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                                <asp:Label ID="Lokasjon" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail">
                            <ItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="250px" TextMode="Email"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="cc">
                            <ItemTemplate>
                                <asp:TextBox ID="txtcc" runat="server" Height="30px" Width="250px" TextMode="Email"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSubject" runat="server" Height="70px" Width="200px" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Text">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBody" runat="server" Height="200px" Width="200px" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="updatepanel11" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>Lokasjon</td>
                        <td>

                            <caption>
                                
                                <asp:DropDownList ID="ddlLokasjon" runat="server" CssClass="selectpicker">
                                </asp:DropDownList>
                                <br />
                            </caption>
                        </td>
                        <caption>
                            <tr>
                                <td>E-mail</td>
                                <td>

                                    <caption>
                                        
                                        <asp:TextBox ID="txtEmailAdd" runat="server" Height="40px" TextMode="Email" Width="300px"></asp:TextBox>
                                        <br />
                                    </caption>
                                </td>
                                <caption>
                                    <tr>
                                        <td>
                                            <td>cc</td>
                                            <caption>
                                                
                                                <asp:TextBox ID="txtccAdd" runat="server" Height="40px" TextMode="Email" Width="300px"></asp:TextBox>
                                                <br />
                                            </caption>
                                        </td>
                                        <caption>
                                            <tr>
                                                <td>
                                                    <td>Subject</td>
                                                    <caption>
                                                        
                                                        <asp:TextBox ID="txtSubjectAdd" runat="server" Height="100px" TextMode="MultiLine" Width="220px"></asp:TextBox>
                                                        <br />
                                                    </caption>
                                                </td>
                                                <caption>
                                                    <tr>
                                                        <td>
                                                            <td>Text</td>
                                                            <caption>
                                                                
                                                                <asp:TextBox ID="txtBodyAdd" runat="server" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                                <br />
                                                            </caption>
                                                        </td>
                                                    </tr>
                                                </caption>
                                            </tr>
                                        </caption>
                                    </tr>
                                </caption>
                            </tr>
                        </caption>
                    </tr>
                </table>
                <asp:Button ID="BtnAdd" runat="server" Text="Lägg till" OnClick="BtnAdd_Click" />
                <asp:Button ID="BtnDelete" runat="server" Text="Rensa" OnClick="BtnDelete_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</asp:Content>
