<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BestandPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.BestandPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table style="width: 100%;">
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
    <asp:ListView ID ="lvwBerichten" runat="server" OnSelectedIndexChanged="lvwBerichten_SelectedIndexChanged"></asp:ListView>
    <table>
        <tr>
            <td style="width: auto;">
                 <asp:Label ID="lblSelectedBericht" runat="server" Text="Niks geselecteerd." />
            </td>
            <td style="width: 136px;">
                <asp:Button ID="btnUnselect" runat="server" Text="Deselecteer" Enabled="False" OnClick="btnUnselect_Click" />
            </td>
            <td style="width: 110px;">
                <asp:Button ID="btnVerwijder" runat="server" Text="Verwijder" Enabled="False" OnClick="btnVerwijder_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    <table>
        <tr>
            <td>
                Titel:
            </td>
            <td>
                <asp:TextBox ID="tbxTitel" runat="server" Width="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Bericht:
            </td>
            <td>
                <asp:TextBox ID="tbxBericht" runat="server" Height="100" Width="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnBericht" runat="server" Text="Plaats" OnClick="btnBericht_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
