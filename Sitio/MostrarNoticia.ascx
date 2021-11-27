<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MostrarNoticia.ascx.cs" Inherits="UserControl_MostrarNoticia" %>
<style type="text/css">
    .auto-style1 {
        width: 179px;
        height: 19px;
    }
    .auto-style4 {
        width: 179px;
        height: 21px;
    }
    .auto-style5 {
        width: 522px;
        height: 21px;
    }
    .auto-style9 {
        width: 100%;
        height: 230px;
    }
    .auto-style15 {
        height: 21px;
    }
    .auto-style19 {
        height: 19px;
    }
    .auto-style21 {
        width: 522px;
        height: 19px;
        text-align: center;
    }
    .auto-style22 {
        width: 179px;
        height: 19px;
        text-align: right;
    }
    .auto-style23 {
        width: 179px;
        height: 21px;
        text-align: right;
    }
    .auto-style24 {
        height: 21px;
        text-align: left;
    }
    .auto-style27 {
        text-align: left;
        height: 8px;
    }
    .auto-style28 {
        width: 179px;
        text-align: right;
        height: 8px;
    }
    .auto-style29 {
        width: 522px;
        height: 8px;
    }
    .auto-style32 {
        height: 8px;
    }
    .auto-style33 {
        width: 522px;
        height: 19px;
        text-align: left;
    }
</style>
<table style="border-style: inset;" class="auto-style9">
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td class="auto-style21"><asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="16pt" Font-Underline="True"></asp:Label>
        </td>
        <td class="auto-style19" style="border-style: none;">Fecha:
            <asp:Label ID="lblFecha" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style22">Codigo:
            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
        </td>
        <td class="auto-style33" style="border-style: inset; border-width: thin">
            <asp:Label ID="lblCuerpo" runat="server" ForeColor="Blue"></asp:Label>
        </td>
        <td class="auto-style19" style="border-style: none;">
            <asp:Label ID="lblPais" runat="server"></asp:Label>
            <asp:Label ID="lblSeccion" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style28">Importancia: <asp:Label ID="lblImportancia" runat="server"></asp:Label>
        </td>
        <td class="auto-style29"></td>
        <td class="auto-style32" style="border-style: none;"></td>
    </tr>
    <tr>
        <td class="auto-style28">
        </td>
        <td class="auto-style29"></td>
        <td class="auto-style27">Redactado por:</td>
    </tr>
    <tr>
        <td class="auto-style23">Empleado: <asp:Label ID="lblEmpleado" runat="server"></asp:Label>
        </td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style24">
            <asp:Label ID="lblPeriodista" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style5">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td class="auto-style15">
            <asp:HyperLink ID="Volver" runat="server" NavigateUrl="~/Default.aspx">Volver.</asp:HyperLink>
        </td>
    </tr>
    </table>


