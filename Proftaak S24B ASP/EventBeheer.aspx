<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #plekVoegToe, #matVoegToe {
            margin-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="eventBeheerVerwijderWijzigProduct" style="width:900px;overflow:auto;">
        <h1 align="center">Product Wijzigen/Verwijderen</h1>
        <div id="listboxVerwijderWijzigProduct" style="float: left">
            <h2>ListBox Wijzig/Verwijder Product</h2>
            <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="400"></asp:ListBox>
        </div>

        <div id="WijzigProductTabel" style="float: left; margin-left: 20px;">
            <h2>Wijzig Plek</h2>
            <asp:Table ID="Table1" runat="server">
               <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Product Categorie</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:DropDownList ID="ddlWijzigProductCategorie" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Merk</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigProductMerk" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Serie</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigProductSerie" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Typenummer</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigProductTypenummer" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Prijs</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigProductPrijs" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnWijzigProduct" runat="server" Text="Wijzig" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnVerwijderProduct" runat="server" Text="Verwijder" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>

    <br />

    <div id="eventBeheerVerwijderWijzigPlek" style="width:900px;overflow:auto;">
        <br />
        <h1 align="center">Plek Wijzigen/Verwijderen</h1>
        <div id="listboxVerwijderWijzigPlek" style="float: left">
            <h2>ListBox Wijzig/Verwijder Plek</h2>
            <asp:ListBox ID="lbxVerwijderWijzigPlek" runat="server" Height="500px" Width="400"></asp:ListBox>
        </div>

        <div id="WijzigPlekTabel" style="float: left; margin-left: 20px;">
            <h2>Wijzig Plek</h2>
            <asp:Table ID="tblPlekWijzig" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><b>Locatie</b></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Naam</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekNaam" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Straat</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekStraat" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">NR</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekNR" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Postcode</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekPostcode" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Plaats</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekPlaats" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><b>Overige Plek Gegevens</b></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Nummer</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekNummer" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Capaciteit</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxWijzigPlekCapaciteit" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnWijzigPlek" runat="server" Text="Wijzig" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnVerwijderPlek" runat="server" Text="Verwijder" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>

    <br />

    <div id="eventBeheerVoegToe" style="width:900px;overflow:auto;">
        <h1 align="center">Plek/Product Toevoegen</h1>
        <div id="plekVoegToe" style="float: left;">
            <h2>Voeg Plek Toe</h2>
            <asp:Table ID="tblPlekVoegToe" runat="server">

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><b>Locatie</b></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Naam</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxLocatieNaam" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Straat</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxLocatieStraat" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">NR</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxLocatieNR" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Postcode</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxLocatiePostcode" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Plaats</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxLocatiePlaats" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><b>Overige Plek Gegevens</b></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Nummer</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxPlekNummer" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Capaciteit</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxCapaciteit" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnVoegPlekToe" runat="server" Text="Voeg Toe" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>

        <div id="matVoegToe" style="float: left;">
            <h2>Voeg Product Toe</h2>
            <asp:Table ID="tblProductVoegToe" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Product Categorie</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:DropDownList ID="ddlProductCategorieen" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Merk</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxProductMerk" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Serie</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxProductSerie" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Typenummer</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxProductTypenummer" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Prijs</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="tbxProductPrijs" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnVoegProductToe" runat="server" Text="Voeg Toe" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">Validator</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>
