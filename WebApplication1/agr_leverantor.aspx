<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agr_leverantor.aspx.cs" Inherits="Portal.agr_leverantor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Navigation" runat="server">
    <ul id="Navigator" runat="server">
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<form runat="server">
    <table>
        <tr>
            <td><label>Avtals-ID:</label></td>
            <td><asp:TextBox runat="server"></asp:TextBox></td>
            <td>delete button(nothing clear yet )</td>
            <td><label>Avtalsbenämning:</label></td>
            <td><asp:TextBox runat="server"></asp:TextBox></td>
            
        </tr>
        <br />
         <tr>
             <td><label>Ansvarig avdelning:</label></td>
            <td><asp:DropDownList runat="server"></asp:DropDownList></td>
                 <td><label>Avtalsansvarig:</label></td>
           <td><asp:DropDownList runat="server"></asp:DropDownList></td>
                     <td><label>Avtalstyp:</label></td>
            <td><asp:DropDownList runat="server"></asp:DropDownList></td>
        </tr>
        <br />
         <tr>
             <td><label>Betalningsvillkor: </label></td>
            <td><asp:TextBox runat="server"></asp:TextBox></td>
                 <td><label>Signerat:</label></td>
           <td><asp:CheckBox runat="server" /></td>
                     <td><label>Uppsägningstid(mån):</label></td>
            <td><asp:TextBox runat="server"></asp:TextBox></td>
        </tr>
        <br>
         <tr>
             <td><label>Giltigt from:</label></td>
            <td>
                <asp:TextBox runat="server"></asp:TextBox></td>
             <td>
                <asp:ImageButton runat="server" ImageUrl="~/images/calendar2.png" Style="width:20px; height:20px;"/>
                <asp:Calendar runat="server" Visible="false"></asp:Calendar>
            </td>
             <td><label> Giltigt tom:</label></td>
        
               <td><asp:TextBox runat="server"></asp:TextBox></td>
             <td>
                <asp:ImageButton runat="server" ImageUrl="~/images/calendar2.png" Style="width:20px; height:20px;"/>
                <asp:Calendar runat="server" Visible="false"></asp:Calendar>
            </td>
            
            
        </tr>
        <br />
          <tr>
                <td><label>Bevakningsdatum:</label></td>
                <td><asp:TextBox runat="server"></asp:TextBox></td>
               <td> <asp:ImageButton runat="server" ImageUrl="~/images/calendar2.png" Style="width:20px; height:20px;"/>
                <asp:Calendar runat="server" Visible="false"></asp:Calendar>
            </td>
              <td><label>Kommentar:</label> </td>
             <td> <asp:TextBox runat="server" TextMode="MultiLine"></asp:TextBox></td>
           
        </tr>
        <br />

    </table>
</form>
</asp:Content>
