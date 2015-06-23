<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventBeheerNieuwEvent.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #divNieuwEvent {
            border: 1px groove #050709;
            border-radius: 10px;
            margin-top: 20px;
        }

        #divHlkEventBeheer {
            margin-top: 20px;
        }

        input[type="date"] {
            background-color: #fff;
            border-radius: 4px;
            border: 1px solid #ccc;
            color: #555;
            font-size: 14px;
            line-height: 20px;
            padding: 6px 12px;
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

        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divHlkEventBeheer">
        <asp:HyperLink ID="hlkEventBeheer" runat="server" NavigateUrl="~/EventBeheer.aspx">EventBeheer</asp:HyperLink>
    </div>

    <div id="divNieuwEvent">

        <table class="auto-style1">
            <thead>
                <h1>Nieuw Event</h1>
            </thead>
            <tr>
                <td>Naam</td>
                <td>
                    <asp:TextBox ID="tbxEventNaam" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEventNaam" runat="server" ControlToValidate="tbxEventNaam" ErrorMessage="U moet het event een naam geven!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Start Datum</td>
                <td>
                    <asp:TextBox ID="tbxStartDatum" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvStartDatum" runat="server" ControlToValidate="tbxStartDatum" ErrorMessage="Er moet een StartDatum worden ingevult!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Eind Datum</td>
                <td>
                    <asp:TextBox ID="tbxEindDatum" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEindDatum" runat="server" ControlToValidate="tbxEindDatum" ErrorMessage="Er moet een EindDatum worden ingevult!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Max Bezoekers</td>
                <td>
                    <asp:TextBox ID="tbxMaxBezoekers" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEventMaxBezoekers" runat="server" ControlToValidate="tbxMaxBezoekers" ErrorMessage="U moet aangeven hoeveel bezoekers het event kunnen attenderen!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><b>Locatie</b></td>
            </tr>
            <tr>
                <td>Naam</td>
                <td>
                    <asp:TextBox ID="tbxLocatieNaam" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvLocatieNaam" runat="server" ControlToValidate="tbxLocatieNaam" ErrorMessage="U moet de locatie een naam geven!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Straat</td>
                <td>
                    <asp:TextBox ID="tbxStraat" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvLocatieStraat" runat="server" ControlToValidate="tbxStraat" ErrorMessage="De locatie moet een straat hebben!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Huisnummer</td>
                <td>
                    <asp:TextBox ID="tbxHuisNummer" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvLocatieHuisNR" runat="server" ControlToValidate="tbxHuisNummer" ErrorMessage="Er moet een huisnummer worden ingevult!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Postcode</td>
                <td>
                    <asp:TextBox ID="tbxPostcode" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvLocatiePostcode" runat="server" ControlToValidate="tbxPostcode" ErrorMessage="De locatie moet een postcode hebben!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Woonplaats</td>
                <td>
                    <asp:TextBox ID="tbxWoonplaats" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvLocatieWoonplaats" runat="server" ControlToValidate="tbxWoonplaats" ErrorMessage="De locatie moet een woonplaats hebben!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnNieuwEvent" runat="server" Text="Maak aan" OnClick="btnNieuwEvent_Click" />
                </td>
                <td>
                    <asp:Label ID="lblEventError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
