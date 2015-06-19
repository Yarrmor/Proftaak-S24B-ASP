<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MediaPagina.aspx.cs" Inherits="Proftaak_S24B_ASP.MediaPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListView ID="lvwMedia" runat="server" OnSelectedIndexChanged="lvwMedia_SelectedIndexChanged">
        <LayoutTemplate>
            <table>
                <tr runat="server">
                    <th>ID</th>
                    <th>Naam</th>
                    <th>Uploader</th>
                    <th>Datum</th>
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
                    <asp:Label ID="lblMediaID" runat="server" Text='<%#Eval("ID") %>' />
                </td>
                <td>
                    <asp:Label ID="lblMediaNaam" runat="server" Text='<%#Eval("Naam") %>' />
                </td>
                <td>
                    <asp:Label ID="lblMediaUploader" runat="server" Text='<%#Eval("Account") %>' />
                </td>
                <td>
                    <asp:Label ID="lblMediaDatum" runat="server" Text='<%#Eval("Datum") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
