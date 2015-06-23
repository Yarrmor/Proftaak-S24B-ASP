<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MateriaalReserveringPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.MateriaalPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        div {
            float:left;
        }
        #divHuren, #divMateriaal {
            margin-left:25px;
        }
        .ReserverenLabels {
            margin-left:10px;
        }
        #lbxMateriaal {
            margin-left:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <h1>Materiaal Reserveren</h1>
    <asp:Label ID="lblInfo" runat="server" Text="Hier kunt u materiaal reserveren indien u een plaats gereserveerd heeft."></asp:Label>
    <br />

    <div>
        <h2>Categorie:</h2>
        <asp:UpdatePanel ID="updPnlCategorie" runat="server">
            <ContentTemplate>
                  <asp:TreeView ID="tvwCategorieen" runat="server" OnSelectedNodeChanged="tvwCategorieen_SelectedNodeChanged">
                  </asp:TreeView>
            <asp:Button ID="btnVerversCategorieen" runat="server" Text="Ververs lijst" OnClick="btnVerversCategorieen_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="divMateriaal">
        
    <h2>Materiaal:</h2>
        <asp:UpdatePanel ID="updPnlMateriaal" runat="server">
            <ContentTemplate>
                  <asp:ListBox ID="lbxMateriaal" runat="server" OnSelectedIndexChanged="lbxMateriaal_SelectedIndexChanged" Width="300px" Height="300px" AutoPostBack="True">
        <asp:ListItem>Selecteer een categorie!</asp:ListItem>
    </asp:ListBox>
    <asp:Button ID="btnVerversMaterialen" runat="server" Text="Ververs lijst" OnClick="btnVerversMaterialen_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
  
     
        </div>

    <div id="divHuren">
        
        <h2>Huren:</h2>
        
        <!--  Details -->
        <asp:UpdatePanel ID="updPnlMateriaalDetails" runat="server">
            <ContentTemplate>
        <p>Materiaal:</p>
        <asp:Label CssClass="ReserverenLabels" ID="lblMateriaalNaam" runat="server" Text="Selecteer eerst een materiaal!"></asp:Label>
        <br />
        <p>Prijs:</p>
        <asp:Label CssClass="ReserverenLabels" ID="lblMateriaalPrijs" runat="server" Text="€0.00"></asp:Label>
        
                
        <br />
        <!--  Datum -->
        <h3>Datum:</h3>
        <p>Van:</p>
        <asp:DropDownList ID="cbxMateriaalDatumVan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbxMateriaalDatumVan_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <p>Tot:</p>
        <asp:DropDownList ID="cbxMateriaalDatumTot" runat="server" AutoPostBack="True">
        </asp:DropDownList>
                
        <br /><br />

        <!--  Plaats reservering -->
        <asp:Button ID="btnHuur" runat="server" Text="Huur" OnClick="btnHuur_Click" />
        <asp:Label runat="server" Visible="False" ID="lblHuurError">U moet ingelogd zijn om een product te huren!</asp:Label>
        </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>

