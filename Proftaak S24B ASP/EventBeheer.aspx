<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divButtonsEventBeheer {
            border: 1px groove #050709;
            border-radius: 10px;
            margin-top: 40px;
        }

        #plekVoegToe, #matVoegToe, #divdivBtnEventAanmaken, #divBtnPlaatsMateriaalToevoegen, #divBtnMateriaalVerwijderenWijzigen, #divBtnPlaatsVerwijderenWijzigen, #divBtnVerhuur {
            margin-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divButtonsEventBeheer">
        <table>
            <thead><h1>Event beheer</h1></thead>
            <tr>
                <td>
                    <!-- Eventbeheer nr1 -->
                    <asp:Button ID="btnEventAanmaken" runat="server" Text="Maak nieuw event" Width="210px" />
                </td>

                <td>
                    <!-- Eventbeheer nr3 -->
                    <asp:Button ID="btnPlaatsMateriaalToevoegen" runat="server" Text="Plaats/Materiaal toevoegen" Width="210px" />
                </td>

                <td>
                    <!-- Eventbeheer nr4/5/12/13 -->
                    <asp:Button ID="btnMateriaalVerwijderenWijzigen" runat="server" Text="Materiaal verwijderen/wijzigen" Width="210px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <!-- Eventbeheer nr4/5/  -->
                    <asp:Button ID="btnPlaatsVerwijderenWijzigen" runat="server" Text="Plaats verwijderen/wijzigen" Width="210px"/>
                </td>

                <td>
                    <!-- Eventbeheer nr6/7/8/9/10/11  -->
                    <asp:Button ID="btnVerhuur" runat="server" Text="Verhuur" Width="210px"/>
                </td>
            </tr>
        </table>
    </div>

    <!--
    <div id="eventBeheerVerwijderWijzigProduct" style="width: 900px; overflow: auto;">
        <h1 align="center">Product Wijzigen/Verwijderen</h1>
        <div id="listboxVerwijderWijzigProduct" style="float: left">
            <h2>ListBox Wijzig/Verwijder Product</h2>
            <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="400"></asp:ListBox>
        </div>

        <div id="WijzigProductTabel" style="float: left; margin-left: 20px;">
            <h2>Wijzig Product</h2>
            <table>
                <tr>
                    <td>Product Categorie</td>
                    <td>
                        <asp:DropDownList ID="ddlWijzigProductCategorie" runat="server"></asp:DropDownList>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Merk</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductMerk" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td>Serie</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductSerie" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Typenummer</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductTypenummer" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnWijzigProduct" runat="server" Text="Wijzig" />
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVerwijderProduct" runat="server" Text="Verwijder" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>

    <br />

    <div id="eventBeheerVerwijderWijzigPlek" style="width: 900px; overflow: auto;">
        <br />
        <h1 align="center">Plek Wijzigen/Verwijderen</h1>
        <div id="listboxVerwijderWijzigPlek" style="float: left">
            <h2>ListBox Wijzig/Verwijder Plek</h2>
            <asp:ListBox ID="lbxVerwijderWijzigPlek" runat="server" Height="500px" Width="400"></asp:ListBox>
        </div>

        <div id="WijzigPlekTabel" style="float: left; margin-left: 20px;">
            <h2>Wijzig Plek</h2>
            <table>
                <tr>
                    <td><b>Locatie</b></td>
                </tr>

                <tr>
                    <td>Naam</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekNaam" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Straat</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekStraat" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>NR</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekNR" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Postcode</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekPostcode" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Plaats</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekPlaats" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td><b>Overige Plek Gegevens</b></td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Nummer</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekNummer" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Capaciteit</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekCapaciteit" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnWijzigPlek" runat="server" Text="Wijzig" />
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVerwijderPlek" runat="server" Text="Verwijder" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>

    <br />

    <div id="eventBeheerVoegToe" style="width: 900px; overflow: auto;">
        <h1 align="center">Plek/Product Toevoegen</h1>
        <div id="plekVoegToe" style="float: left;">
            <h2>Voeg Plek Toe</h2>
            <table>

                <tr>
                    <td><b>Locatie</b></td>
                </tr>

                <tr>
                    <td>Naam</td>
                    <td>
                        <asp:TextBox ID="tbxLocatieNaam" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Straat</td>
                    <td>
                        <asp:TextBox ID="tbxLocatieStraat" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>NR</td>
                    <td>
                        <asp:TextBox ID="tbxLocatieNR" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Postcode</td>
                    <td>
                        <asp:TextBox ID="tbxLocatiePostcode" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Plaats</td>
                    <td>
                        <asp:TextBox ID="tbxLocatiePlaats" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td runat="server"><b>Overige Plek Gegevens</b></td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxPlekPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Nummer</td>
                    <td>
                        <asp:TextBox ID="tbxPlekNummer" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Capaciteit</td>
                    <td>
                        <asp:TextBox ID="tbxCapaciteit" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVoegPlekToe" runat="server" Text="Voeg Toe" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>

        <div id="matVoegToe" style="float: left;">
            <h2>Voeg Product Toe</h2>
            <table>
                <tr>
                    <td>Product Categorie</td>
                    <td>
                        <asp:DropDownList ID="ddlProductCategorieen" runat="server"></asp:DropDownList>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Merk</td>
                    <td>
                        <asp:TextBox ID="tbxProductMerk" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Serie</td>
                    <td>
                        <asp:TextBox ID="tbxProductSerie" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Typenummer</td>
                    <td>
                        <asp:TextBox ID="tbxProductTypenummer" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxProductPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>Validator</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVoegProductToe" runat="server" Text="Voeg Toe" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div> -->
</asp:Content>
