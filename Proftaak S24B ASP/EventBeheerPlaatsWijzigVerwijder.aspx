<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventBeheerPlaatsWijzigVerwijder.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divHlkEventBeheer">
        <asp:HyperLink ID="hlkEventBeheer" runat="server" NavigateUrl="~/EventBeheer.aspx">EventBeheer</asp:HyperLink>
    </div>
    <br />
    <div id="eventBeheerVerwijderWijzigPlek" style="width: 1000px; overflow: auto;">
        <br />
        <h1 align="center">Plek Wijzigen/Verwijderen</h1>
        <div id="listboxVerwijderWijzigPlek" style="float: left">
            <h2>ListBox Wijzig/Verwijder Plek</h2>
            <asp:ListBox ID="lbxVerwijderWijzigPlek" runat="server" Height="500px" Width="400" OnSelectedIndexChanged="lbxVerwijderWijzigPlek_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
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
                        <asp:TextBox ID="tbxWijzigPlekLocatieNaam" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvWVLocatieNaam" runat="server" ControlToValidate="tbxWijzigPlekLocatieNaam" ErrorMessage="LocatieNaam is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Straat</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekLocatieStraat" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>NR</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekLocatieNR" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Postcode</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekLocatiePostcode" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Plaats</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekLocatiePlaats" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td><b>Overige Plek Gegevens</b></td>
                </tr>

                <tr>
                    <td>ID</td>
                    <td>
                        <asp:Label ID="lblPlekID" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvWVPlekPrijs" runat="server" ControlToValidate="tbxWijzigPlekPrijs" ErrorMessage="Prijs is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Nummer</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekNummer" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvWVPlekNR" runat="server" ControlToValidate="tbxWijzigPlekNummer" ErrorMessage="Nummer is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Capaciteit</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigPlekCapaciteit" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvWVPlekCapaciteit" runat="server" ControlToValidate="tbxWijzigPlekCapaciteit" ErrorMessage="Capaciteit is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Filters</td>
                    <td>
                        <asp:CheckBoxList ID="cblFilters" runat="server">
                        </asp:CheckBoxList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnWijzigPlek" runat="server" Text="Wijzig" OnClick="btnWijzigPlek_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblWijzigError" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVerwijderPlek" runat="server" Text="Verwijder" OnClick="btnVerwijderPlek_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblVerwijderError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
