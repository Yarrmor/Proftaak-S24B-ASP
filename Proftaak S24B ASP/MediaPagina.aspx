<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MediaPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.MediaPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListView ID="lvwMedia" runat="server" OnSelectedIndexChanged="lvwMedia_SelectedIndexChanged"></asp:ListView>
</asp:Content>
