<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventBeheerProductWijzigVerwijder.aspx.cs" Inherits="Proftaak_S24B_ASP.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divHlkEventBeheer">
        <asp:HyperLink ID="hlkEventBeheer" runat="server" NavigateUrl="~/EventBeheer.aspx">EventBeheer</asp:HyperLink>
    </div>
    <br />
    <div id="eventBeheerVerwijderWijzigProduct" style="width: 1000px; overflow: auto;">
        <h1 align="center">Product Wijzigen/Verwijderen</h1>
        <div id="listboxVerwijderWijzigProduct" style="float: left">
            <h2>ListBox Wijzig/Verwijder Product</h2>
            <asp:ListBox ID="lbxProductWV" runat="server" Height="300px" Width="400" OnSelectedIndexChanged="lbxProductWV_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
        </div>

        <div id="WijzigProductTabel" style="float: left; margin-left: 20px;">
            <h2>Wijzig Product</h2>
            <table>
                <tr>
                    <td>ID</td>
                    <td>
                        <asp:Label ID="lblProductWVID" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Product Categorie</td>
                    <td>
                        <asp:DropDownList ID="ddlWijzigProductCategorie" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductWVCategorie" runat="server" ControlToValidate="ddlWijzigProductCategorie" ErrorMessage="ProductCategorie is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Merk</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductMerk" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductWVMerk" runat="server" ControlToValidate="tbxWijzigProductMerk" ErrorMessage="Merk is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Serie</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductSerie" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductWVSerie" runat="server" ControlToValidate="tbxWijzigProductSerie" ErrorMessage="Serie is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Typenummer</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductTypenummer" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductWVTypeNR" runat="server" ControlToValidate="tbxWijzigProductTypenummer" ErrorMessage="TypeNR is vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Prijs</td>
                    <td>
                        <asp:TextBox ID="tbxWijzigProductPrijs" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProductWVPrijs" runat="server" ControlToValidate="tbxWijzigProductPrijs" ErrorMessage="Prijs is Vereist!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
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
</asp:Content>
