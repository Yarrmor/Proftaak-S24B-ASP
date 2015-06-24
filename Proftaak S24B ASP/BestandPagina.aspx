<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BestandPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.BestandPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblNaam" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgBestand" runat="server" Visible="False" /><asp:Label ID="lblText" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />
                <asp:Button ID="btnVerwijder" runat="server" Text="Verwijder" Enabled="False" OnClick="btnVerwijder_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:ListView ID ="lvwBerichten" runat="server">
        <LayoutTemplate>
            <table>
                <tr runat="server">
                    <th>Bericht ID</th>
                    <th>Account</th>
                    <th>Reactie Op</th>
                    <th>Bericht</th>
                </tr>
                <tr runat="server" id="itemPlaceholder" />
            </table>
            <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server">
                <td>
                    <asp:Label ID="lblBerichtID" runat="server" Text='<%#Eval("ID") %>' />
                </td>
                <td>
                    <asp:Label ID="lblAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account.Gebruikersnaam") %>' />
                </td>
                <td>
                    <asp:Label ID="lblQuote" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "HoofdBijdrage.ID") %>' />
                </td>
                <td>
                    <asp:Label ID="lblTitel" runat="server" Text='<%#Eval("Titel") %>' />
                    <br />
                    <br />
                    <asp:Label ID="lblInhoud" runat="server" Text='<%#Eval("Inhoud") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    <table>
        <tr>
            <td>
                Titel:
            </td>
            <td>
                <asp:TextBox ID="tbxTitel" runat="server" Width="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Bericht:
            </td>
            <td>
                <asp:TextBox ID="tbxBericht" runat="server" Height="100" Width="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnBericht" runat="server" Text="Plaats" OnClick="btnBericht_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
