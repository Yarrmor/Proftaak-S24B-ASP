<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InlogPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.InlogPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Inloggen</h1>
    <table class="auto-style1">
        <tr>
            <td>Email</td>
            <td>
    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvEmailIngevult" runat="server" ControlToValidate="tbEmail" ErrorMessage="U moet een Email invoeren om in te kunnen loggen!" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="U moet een geldig Email invoeren!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Wachtwoord</td>
            <td>
    <asp:TextBox ID="tbWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvWachtwoordInvoeren" runat="server" ControlToValidate="tbWachtwoord" ErrorMessage="U moet een wachtwoord invoeren om te kunnen inloggen!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
    <asp:Button ID="btnLogin" runat="server" Text="Inloggen" OnClick="btnLogin_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Content>
