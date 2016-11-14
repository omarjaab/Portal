<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>
 
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <asp:label id="lbl" runat="server" ></asp:label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:DropDownList ID="ddl" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
            <asp:ListItem Text="aa"></asp:ListItem>
                        <asp:ListItem Text="bb"></asp:ListItem>
                        <asp:ListItem Text="cc"></asp:ListItem>

        </asp:DropDownList>
    </div>
    </div>
    </form>
</body>
</html>
