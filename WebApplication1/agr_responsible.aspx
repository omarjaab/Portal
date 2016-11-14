<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agr_responsible.aspx.cs" Inherits="Portal.agr_responsible" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        index good news
        <asp:UpdatePanel ID="uppdateGrid" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnStringDWAdmin %>" DeleteCommand="DELETE FROM [ResponsibleEmail] WHERE [UserID] = @original_UserID AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL))" InsertCommand="INSERT INTO [ResponsibleEmail] ([UserID], [Email]) VALUES (@UserID, @Email)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [ResponsibleEmail] ORDER BY [UserID]" UpdateCommand="UPDATE [ResponsibleEmail] SET [Email] = @Email WHERE [UserID] = @original_UserID AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_UserID" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserID" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="original_UserID" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        &nbsp;<br />
        <asp:UpdatePanel ID="InputInfo" runat="server">
            <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text="Användar Id"></asp:Label>
        <asp:TextBox ID="txtuserId" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtuserEmail" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lägg till" />
            </ContentTemplate>
                </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #form1 {
            height: 281px;
        }
    </style>
</asp:Content>

