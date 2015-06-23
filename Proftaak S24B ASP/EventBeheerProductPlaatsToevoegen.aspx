<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventBeheerProductPlaatsToevoegen.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #plekVoegToe, #productVoegToe {
            border: 1px groove #050709;
            border-radius: 10px;
        }

        input[type="number"] {
            background-color: #fff;
            border-radius: 4px;
            border: 1px solid #ccc;
            color: #555;
            font-size: 14px;
            line-height: 20px;
            padding: 6px 12px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="eventBeheerVoegToe" style="width: 1100px; overflow: auto;">
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
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekNaam" runat="server" ErrorMessage="Naam is vereist!" ForeColor="Red" ControlToValidate="tbxLocatieNaam" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Straat</td>
                    <td>
                        <asp:TextBox ID="tbxLocatieStraat" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekStraat" runat="server" ErrorMessage="Straat is vereist!" ForeColor="Red" ControlToValidate="tbxLocatieStraat" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Huisnummer</td>
                    <td>
                        <asp:TextBox ID="tbxLocatieNR" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekHuisNR" runat="server" ErrorMessage="HuisNR is vereist!" ForeColor="Red" ControlToValidate="tbxLocatieNR" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Postcode</td>
                    <td>
                        <asp:TextBox ID="tbxLocatiePostcode" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekPostcode" runat="server" ErrorMessage="Postcode is vereist!" ForeColor="Red" ControlToValidate="tbxLocatiePostcode" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Plaats</td>
                    <td>
                        <asp:TextBox ID="tbxLocatiePlaats" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekPlaats" runat="server" ErrorMessage="Plaats is vereist!" ForeColor="Red" ControlToValidate="tbxLocatiePlaats" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td runat="server"><b>Overige Plek Gegevens</b></td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxPlekPrijs" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekPrijs" runat="server" ErrorMessage="Prijs is Vereist!" ForeColor="Red" ControlToValidate="tbxPlekPrijs" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Nummer</td>
                    <td>
                        <asp:TextBox ID="tbxPlekNummer" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekNummer" runat="server" ErrorMessage="Nummer is vereist!" ForeColor="Red" ControlToValidate="tbxPlekNummer" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Capaciteit</td>
                    <td>
                        <asp:TextBox ID="tbxCapaciteit" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPlekCapaciteit" runat="server" ErrorMessage="Capaciteit is vereist!" ForeColor="Red" ControlToValidate="tbxCapaciteit" ValidationGroup="Merk"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblPlekError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnVoegPlekToe" runat="server" Text="Voeg Toe" OnClick="btnVoegPlekToe_Click" ValidationGroup="Merk"/>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>

        <div id="productVoegToe" style="float: left;">
            <h2>Voeg Product Toe</h2>
            <table>
                <tr>
                    <td>Product Categorie</td>
                    <td>
                        <asp:DropDownList ID="ddlProductCategorieen" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductCategorie" runat="server" ErrorMessage="Productcategorie is vereist!" ControlToValidate="ddlProductCategorieen" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Merk</td>
                    <td>
                        <asp:TextBox ID="tbxProductMerk" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductMerk" runat="server" ControlToValidate="tbxProductMerk" ErrorMessage="Merk is vereist!" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Serie</td>
                    <td>
                        <asp:TextBox ID="tbxProductSerie" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductSerie" runat="server" ControlToValidate="tbxProductSerie" ErrorMessage="Serie is vereist!" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Typenummer</td>
                    <td>
                        <asp:TextBox ID="tbxProductTypenummer" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductTypeNR" runat="server" ControlToValidate="tbxProductTypenummer" ErrorMessage="TypeNR is vereist!" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxProductPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductPrijs" runat="server" ControlToValidate="tbxProductPrijs" ErrorMessage="rfvProductPrijs" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVoegProductToe" runat="server" Text="Voeg Toe" OnClick="btnVoegProductToe_Click" ValidationGroup="Product"/>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
