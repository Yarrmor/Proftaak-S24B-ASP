<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inloggen.aspx.cs" Inherits="Proftaak_S24B_ASP.Inloggen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="lblLoginError" runat="server"></asp:Label><br />
    <table>
        <tr>
            <td>
                Gebruikersnaam:
            </td>
            <td>
                <asp:TextBox ID="tbxLogin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Wachtwoord:
            </td>
            <td>
                <asp:TextBox ID="tbxPassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="btnLogin" Text="Inloggen" runat="server" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
    </asp:Content>
