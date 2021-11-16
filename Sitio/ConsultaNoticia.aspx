<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaNoticia.aspx.cs" Inherits="ConsultaNoticia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consulta de noticia</title>
</head>
    <style>
        div {
            margin: 0 0 2em 2em;
        }
        .label-container {
            text-align: right;
        }
    </style>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="label-container"><label>Código: </label></td>
                <td>
                    <asp:TextBox ID="TxtCodigo" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="label-container">
                    <label>Sección:</label>
                </td>
                <td><asp:TextBox ID="TxtSeccion" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-container">
                    <label>Título: </label>
                </td>
                <td><asp:TextBox ID="TxtTitulo" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-container">
                    <label>Cuerpo: </label>
                </td>
                <td><asp:TextBox ID="TxtCuerpo" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-container">
                    <label>Importancia: </label>
                </td>
                <td><asp:TextBox ID="TxtImportancia" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-container">
                    <label>FechaPublicación: </label>
                </td>
                <td><asp:TextBox ID="TxtFecha" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-container">
                    <label>Periodistas: </label>
                </td>
                <td>
                    <asp:ListBox ID="LstPeriodistas" runat="server"></asp:ListBox></td>
            </tr>
        </table>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
