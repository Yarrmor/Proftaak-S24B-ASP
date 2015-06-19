<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MateriaalReserveringPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.MateriaalPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #Content {
            width:auto;
        }
        div {
            float:left;
        }
        #divReserveren, #divMateriaal {
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
            <asp:Button ID="btnVerversCategorieen" runat="server" Text="Ververs lijst" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="divMateriaal">
        
    <h2>Materiaal:</h2>
        <asp:UpdatePanel ID="updPnlMateriaal" runat="server">
            <ContentTemplate>
                  <asp:ListBox ID="lbxMateriaal" runat="server" OnSelectedIndexChanged="lbxMateriaal_SelectedIndexChanged" Width="300px" Height="300px" AutoPostBack="True">
        <asp:ListItem>Kon materialen niet ophalen!</asp:ListItem>
    </asp:ListBox>
    <asp:Button ID="btnVerversMeterialen" runat="server" Text="Ververs lijst" />
            </ContentTemplate>
        </asp:UpdatePanel>
  
     
        </div>

    <div id="divReserveren">
        
        <h2>Reserveren:</h2>
        
        <!--  Details -->
        <asp:UpdatePanel ID="updPnlMateriaalDetails" runat="server">
            <ContentTemplate>
        <p>Materiaal:</p>
        <asp:Label CssClass="ReserverenLabels" ID="lblMateriaalNaam" runat="server" Text="Selecteer eerst een materiaal!"></asp:Label>
        <br />
        <p>Voorraad:</p>
        <asp:Label CssClass="ReserverenLabels" ID="lblMateriaalVoorraad" runat="server" Text="0"></asp:Label>
        <br />
        <p>Prijs:</p>
        <asp:Label CssClass="ReserverenLabels" ID="lblMateriaalPrijs" runat="server" Text="€0.00"></asp:Label>
        
                </ContentTemplate>
            </asp:UpdatePanel>
        <br />
        <!--  Datum -->
        <h3>Datum:</h3>
        <p>Van:</p>
        <asp:DropDownList ID="cbxMateriaalDatumVan" runat="server">
        </asp:DropDownList>
        <br />
        <p>Tot:</p>
        <asp:DropDownList ID="cbxMateriaalDatumTot" runat="server">
        </asp:DropDownList>
        <br /><br />

        <!--  Plaats reservering -->
        <asp:Button ID="btnReserveer" runat="server" Text="Reserveer" OnClick="btnReserveer_Click" />
    </div>
</asp:Content>

