<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InlogPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.InlogPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Inloggen</h1>
    <asp:Table ID="tblInlogGegevens" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                Email:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Wachtwoord:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ID="btnLogin" runat="server" Text="Inloggen" OnClick="btnLogin_Click" />
</asp:Content>
