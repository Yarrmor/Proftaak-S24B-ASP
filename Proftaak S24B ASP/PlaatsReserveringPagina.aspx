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
        /* http://stackoverflow.com/questions/3790935/can-i-hide-the-html5-number-input-s-spin-box 
            Verbergt de arrows voor input["number"] in browsers die dit ondersteunen, is namelijk raar voor telefoonnummer */
        input::-webkit-outer-spin-button, input::-webkit-inner-spin-button {
            /* display: none; <- Crashes Chrome on hover */
            -webkit-appearance: none;
            margin: 0; /* <-- Apparently some margin are still there even though it's hidden */
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
                                    <asp:DropDownList ID="cbxDatumTot" OnSelectedIndexChanged="cbxDatumTot_SelectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
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
                                <asp:TableCell runat="server" ID="tbcDagprijs"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">Totaalprijs:</asp:TableCell>
                                <asp:TableCell runat="server" ID="tbcTotaalprijs"></asp:TableCell>
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
                            <asp:TextBox ID="tbxVoornaam" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvVoornaam" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxVoornaam"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Tussenvoegsel:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxTussenvoegsel" runat="server"></asp:TextBox>
                     </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Achternaam:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxAchternaam" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAchternaam" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxAchternaam"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Telefoonnummer:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxTelefoonnummer" TextMode="Number" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTelefoonnummer" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxTelefoonnummer"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Woonplaats:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxWoonplaats" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvWoonplaats" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxWoonplaats"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Straatnaam:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxStraatnaam" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStraatnaam" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxStraatnaam"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Huisnummer:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxHuisnummer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvHuisnummer" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxHuisnummer"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Email adres:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxEmailAdres" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmailAdres" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxEmailAdres"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmailAdres" runat="server" ErrorMessage="Ongeligd email adres!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxEmailAdres" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Bankrekeningnumer:</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="tbxBankrekeningnummer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBankrekeningnummer" runat="server" ErrorMessage="Veld moet ingevuld zijn!" Display="Dynamic" ForeColor="Red" ControlToValidate="tbxBankrekeningnummer"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="tbxEmail2" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail3" runat="server">
                                <asp:TableCell>
                               Email lid 3:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbxEmail3" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail4" runat="server">
                                <asp:TableCell>
                               Email lid 4:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbxEmail4" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail5" runat="server">
                                <asp:TableCell>
                               Email lid 5:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbxEmail5" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail6" runat="server">
                                <asp:TableCell>
                               Email lid 6:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbxEmail6" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail7" runat="server">
                                <asp:TableCell>
                               Email lid 7:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbxEmail7" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false" ID="tbrEmail8" runat="server">
                                <asp:TableCell>
                               Email lid 8:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tbxEmail8" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Button ID="btnReserveren" runat="server" Text="Plaats reservering" OnClick="btnReserveren_Click" />
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"/>
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </div>

</asp:Content>
