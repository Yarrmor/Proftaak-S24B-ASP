<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BestandPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.BestandPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblNaam" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgBestand" runat="server" Visible="False" /><asp:Label ID="lblText" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:ListView ID ="lvwBerichten" runat="server"></asp:ListView>
</asp:Content>
