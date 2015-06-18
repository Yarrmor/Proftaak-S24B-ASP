<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActiveerAccount.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 241px;
        }
        .auto-style3 {
            width: 256px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblValOngeldig" runat="server" ForeColor="Red" Text="Ingevoerde validatie code is ongeldig!" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="lblActivatieHashGebruikt" runat="server" ForeColor="Red" Text="ActivatieHash is al gebruikt!"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lblValInformatie" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Gebruikersnaam</td>
            <td class="auto-style3">
                <asp:TextBox ID="tbxGebruikersnaam" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvGebruikersnaam" runat="server" ControlToValidate="tbxGebruikersnaam" ErrorMessage="U moet een gebruikersnaam invoeren!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Wachtwoord</td>
            <td class="auto-style3">
                <asp:TextBox ID="tbxWachtwoord" runat="server" Enabled="False" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvWachtwoord" runat="server" ControlToValidate="tbxWachtwoord" ErrorMessage="U moet een wachtwoord invoeren!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Bevestig Wachtwoord</td>
            <td class="auto-style3">
                <asp:TextBox ID="tbxBevestigWachtwoord" runat="server" Enabled="False" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvBevestigWachtwoord" runat="server" ControlToValidate="tbxBevestigWachtwoord" ErrorMessage="U moet het wachtwoord nog een keer invullen voor bevestiging!" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="cvrWachtwoord" runat="server" ControlToCompare="tbxWachtwoord" ControlToValidate="tbxBevestigWachtwoord" ErrorMessage="Het wachtwoord moet in beide vakken hetzelfde zijn!" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="btnActiveer" runat="server" Enabled="False" Text="Activeer" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
