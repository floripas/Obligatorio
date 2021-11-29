<%@ Page Title="" Language="C#" MasterPageFile="~/Escritorio_MP.master" AutoEventWireup="true" CodeFile="ABMPeriodistas.aspx.cs" Inherits="ABMPeriodistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 76px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" style="width: 74%;">
        <tr>
            <td class="style8" colspan="1">Cédula:</td>
            <td colspan="3">
                <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
                &nbsp;<br />
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="1">Nombre:</td>
            <td colspan="3">
                <asp:TextBox ID="txtNombre" runat="server" Width="186px"></asp:TextBox>
            </td>
            <td class="style9" colspan="1"></td>
        </tr>
        <tr>
            <td class="style8" colspan="1">Email:</td>
            <td colspan="3">
                <asp:TextBox ID="txtEmail" runat="server" Width="186px"></asp:TextBox>
            </td>
            <td class="style9" colspan="1"></td>
        </tr>
        <tr>
            <td class="style3" colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td class="style3" colspan="5">
                <asp:Label ID="LblError" runat="server" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">&nbsp;</td>
            <td class="style1">
                <asp:Button ID="btnAlta" runat="server" Enabled="False" onclick="btnAlta_Click" Text="Alta" />
                <asp:Button ID="btnActivar" runat="server" Enabled="False" Text="Activar" Visible="False" OnClick="btnActivar_Click" />
            </td>
            <td class="style1">
                <asp:Button ID="btnBaja" runat="server" Enabled="False" onclick="btnBaja_Click" Text="Baja" />
            </td>
            <td class="auto-style1">
                <asp:Button ID="btnModificar" runat="server" Enabled="False" onclick="btnModificar_Click" Text="Modificar" />
            </td>
            <td class="style9">
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnRefresh_Click" Text="Limpiar" />
            </td>
        </tr>
    </table>
</asp:Content>

