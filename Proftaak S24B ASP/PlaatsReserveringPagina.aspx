<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaatsReserveringPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.PlaatsReserveringPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divReserveren{
            margin-left:25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Plaats Reserveren</h1>
    <asp:Label ID="lblInfo" runat="server" Text="Hier kunt u een plaats reserveren voor dit evenement."></asp:Label>

    <div style="float:left;"">
        <h2>Kaart:</h2>
        <asp:Image ID="imgKaart" runat="server" ImageUrl="~/Afbeeldingen/Event1_Map.png" Width="587px" Height="587px"/>


        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    <div id="divReserveren">
        <h2>Reserveren:</h2>

        <asp:Button ID="Button2" runat="server" Text="Button" />
    </div>
    


</asp:Content>
