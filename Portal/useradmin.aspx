<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="useradmin.aspx.cs" Inherits="Portal.useradmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <label id="lbl" runat="server" ></label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:DropDownList ID="ddl" runat="server" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
            <asp:ListItem Text="aa"></asp:ListItem>
                        <asp:ListItem Text="bb"></asp:ListItem>
                        <asp:ListItem Text="cc"></asp:ListItem>

        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
