<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaatsReserveringPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.PlaatsReserveringPagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #cbxDatumVan {
            float: right;
        }

        #divPlaats, #divGegevens, #divGroepsgegevens {
            margin-left: 10px;
        }

        input[type="checkbox"] {
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Plaats Reserveren</h1>
    <asp:Label ID="lblInfo" runat="server" Text="Hier kunt u een plaats reserveren voor dit evenement."></asp:Label>

    <div>
        <h2>Kaart:</h2>
        <asp:Image ID="imgKaart" runat="server" ImageUrl="~/Afbeeldingen/Event1_Map.png" Width="587px" Height="587px" />
    </div>
    <div id="divReserveren">
        <h2>Reserveren:</h2>
        <div id="divReserverenTabel" style="display: table-row; border-collapse: separate; border-spacing: 5px;">
            <div id="divDatum" style="display: table-cell; padding-left: 20px;">
                <h3>Datum:</h3>

                <asp:UpdatePanel ID="updPnlDatums" runat="server">
                    <ContentTemplate>
                        <asp:Table ID="tblDatum" runat="server">
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">Van:</asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:DropDownList ID="cbxDatumVan" OnSelectedIndexChanged="cbxDatumVan_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">Tot en met:</asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:DropDownList ID="cbxDatumTot" runat="server"></asp:DropDownList></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div id="divPlaats" style="display: table-cell; padding-left: 20px;">
                <h3>Plaats:</h3>
                <asp:UpdatePanel ID="updPnlPlaats" runat="server">
                    <ContentTemplate>
                        <asp:Table ID="tblPlaats" runat="server">
                            <asp:TableRow runat="server" VerticalAlign="Top">
                                <asp:TableCell runat="server">Filters:</asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:CheckBoxList ID="clbPlaatsFilters" OnSelectedIndexChanged="clbPlaatsFilters_SelectedIndexChanged" runat="server" AutoPostBack="True">
                                    </asp:CheckBoxList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">Plaatsnummer:</asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:DropDownList ID="cbxPlaatsnummer" OnSelectedIndexChanged="cbxPlaatsnummer_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">Dagprijs:</asp:TableCell>
                                <asp:TableCell runat="server"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">Totaalprijs:</asp:TableCell>
                                <asp:TableCell runat="server"></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="divGegevens" style="display: table-cell; padding-left: 20px;">
                <h3>Gegevens:</h3>
                <asp:Table ID="tblGegevens" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Voornaam:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Achternaam:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Telefoonnummer:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Woonplaats:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Straatnaam:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Huisnummer:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Email adres:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div id="divGroepsgegevens" style="display: table-cell; padding-left: 20px;">
                <h3>Groepsgegevens:</h3>

                <asp:UpdatePanel ID="pnlGroepsgegevens" runat="server">
                    <ContentTemplate>
                        <asp:Table ID="tblGroepsAantal" runat="server">
                            <asp:TableRow runat="server">
                                <asp:TableCell Wrap="false" runat="server">Aantal personen:</asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:DropDownList ID="cbxAantalPersonen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbxAantalPersonen_SelectedIndexChanged"></asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Label ID="lblEmailsLeden" runat="server" Visible="false" Text="Email adressen leden:"></asp:Label>
                        <asp:Table ID="tblGroepsgegevens" runat="server">
                            <asp:TableRow Visible="false" ID="tbrEmail2" runat="server">
                                <asp:TableCell Wrap="False">
                               Email lid 2:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail2" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail3" runat="server">
                                <asp:TableCell>
                               Email lid 3:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail3" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail4" runat="server">
                                <asp:TableCell>
                               Email lid 4:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail4" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail5" runat="server">
                                <asp:TableCell>
                               Email lid 5:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail5" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail6" runat="server">
                                <asp:TableCell>
                               Email lid 6:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail6" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail7" runat="server">
                                <asp:TableCell>
                               Email lid 7:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail7" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail8" runat="server">
                                <asp:TableCell>
                               Email lid 8:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbEmail8" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <asp:Button ID="btnReserveren" runat="server" Text="Plaats reservering" OnClick="btnReserveren_Click" />
    </div>

</asp:Content>
