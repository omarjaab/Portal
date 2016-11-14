<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pnbfileupload.aspx.cs" Inherits="Portal.pnbfileupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<form id="MainForm" runat="server">
   
    <asp:FileUpload id="FileUploadControl" runat="server" />
    <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
    <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
 <asp:ScriptManager ID="scrptmngr" runat=server></asp:ScriptManager>
    <asp:UpdatePanel ID="treeUpPnl" runat=server>
    <ContentTemplate>
    
    
 
    <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px"  />
</asp:TreeView>   </ContentTemplate>
<%--<Triggers>
<asp:AsyncPostBackTrigger ControlID="radioTest" EventName="radioTest_CheckedChanged" />
</Triggers>--%>
</asp:UpdatePanel>
    <asp:RadioButton GroupName="paths" Text="Production" ID="radioProd" runat="server" AutoPostBack=true OnCheckedChanged="radioProd_CheckedChanged"/>
    <asp:RadioButton GroupName="paths" Text="Development"  ID="radioDev" runat="server" AutoPostBack=true OnCheckedChanged="radioDev_CheckedChanged"/>
    <asp:RadioButton GroupName="paths" Text="Test"  ID="radioTest" runat="server" AutoPostBack=true OnCheckedChanged="radioTest_CheckedChanged"/>
   
    </form>
</asp:Content>
