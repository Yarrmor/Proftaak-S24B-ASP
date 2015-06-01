<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MateriaalReserveren.aspx.cs" Inherits="Proftaak_S24B_ASP.MateriaalReserveren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListBox ID="lbMateriaal" runat="server">
        <asp:ListItem>Kon objecten niet ophalen!</asp:ListItem>
    </asp:ListBox>
    <asp:Button ID="btnVervers" runat="server" OnClick="btnVervers_Click" Text="Ververs" />
</asp:Content>
