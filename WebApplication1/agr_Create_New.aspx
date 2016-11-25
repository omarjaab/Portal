<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agr_Create_New.aspx.cs" Inherits="Portal.agr_Create_New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server"></ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .ComponentCell {
            width: 65%;
            padding: 5px;
        }
        .LabelCell {
            padding: 5px;
            width: 35%;
        }

        #SectionContainer1 {
            width: 40%;
        }
    </style>
    <form id="form1" runat="server">

        <asp:Panel ID="agr_modify_Section" runat="server" Visible="true">
            <asp:ScriptManager ID="scrptmnger" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="updpnl" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>Avtalsnummer</td>
                            <td>
                                <asp:TextBox ID="new_AgreementNumber" runat="server"></asp:TextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Ansvarigt platskontor/stab: </td>

                            <td>
                                <asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Avtalsansvariga: </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DDL_AgreementResponsible"></asp:DropDownList>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Backup1: </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DDL_Backup_1"></asp:DropDownList></td>
                            <td>Backup2: </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DDL_Backup_2"></asp:DropDownList></td>
                            <td>Backup3: </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DDL_Backup_3"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Uppsägningstid(mån): </td>
                            <td>
                                <asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Betalningsvilkor:</td>
                            <td>
                                <asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Signatur: </td>
                            <td>
                                <asp:CheckBox runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Giltig from: </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtBox_New_Agr_Valid_From"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1"
                                    ClientIDMode="AutoID"
                                    runat="server"
                                    src="images/calendar2.png"
                                    Style="width: 20px; height: 20px;"
                                    OnClick="ImageButton1_Click" />
                                <asp:Calendar ID="Vaild_From_Calendar"
                                    runat="server"
                                    Visible="false"
                                    Style="position: -ms-page"
                                    OnSelectionChanged="Vaild_From_Calendar_SelectionChanged"
                                    CellPadding="4"
                                    BorderColor="#999999"
                                    Font-Names="Verdana"
                                    Font-Size="8pt"
                                    Height="180px"
                                    ForeColor="Black"
                                    DayNameFormat="FirstLetter"
                                    Width="200px"
                                    BackColor="White">
                                    <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
                                    <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                                    <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                                    <DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
                                    <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
                                    <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
                                    <WeekendDayStyle BackColor="LightSteelBlue"></WeekendDayStyle>
                                    <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
                                </asp:Calendar>
                            </td>



                            <td>Giltig tom: </td>
                            <td>
                                <asp:TextBox runat="server"></asp:TextBox>
                                <asp:Calendar runat="server"
                                    ID="Valid_Until_Calendar" 
                                    Visible="false"
                                    Style="position: -ms-page"
                                    OnSelectionChanged="Valid_Until_Calendar_SelectionChanged"
                                    CellPadding="4"
                                    BorderColor="#999999"
                                    Font-Names="Verdana"
                                    Font-Size="8pt"
                                    Height="180px"
                                    ForeColor="Black"
                                    DayNameFormat="FirstLetter"
                                    Width="200px"
                                    BackColor="White">
                                    <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
                                    <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                                    <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                                    <DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
                                    <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
                                    <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
                                    <WeekendDayStyle BackColor="LightSteelBlue"></WeekendDayStyle>
                                    <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
                                </asp:Calendar>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>PÖS-avtal: </td>
                            <td>
                                <asp:CheckBox runat="server" /><asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Bonusklausul: </td>
                            <td>
                                <asp:CheckBox runat="server" /><asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Varumärkes-klausul: </td>
                            <td>
                                <asp:CheckBox runat="server" /><asp:TextBox runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Övriga avvikelser mot standard: </td>
                            <td>
                                <asp:CheckBox runat="server" /><asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Övriga dokument: </td>
                            <td>
                                <asp:CheckBox runat="server" /><asp:TextBox runat="server"></asp:TextBox></td>
                            <td>Prisökningsmekanism: </td>
                            <td>
                                <asp:DropDownList runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>EDI-bokning: </td>

                            <td>
                                <asp:CheckBox runat="server" /></td>
                            <td>Lagringsavtal:</td>
                            <td>
                                <asp:CheckBox runat="server" /></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </form>
</asp:Content>
