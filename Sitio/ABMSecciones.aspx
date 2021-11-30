<%@ Page Title="" Language="C#" MasterPageFile="~/Escritorio_MP.master" AutoEventWireup="true" CodeFile="ABMSecciones.aspx.cs" Inherits="ABMSecciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Administrar secciones de noticias nacionales</title>
    <style type="text/css">
        .auto-style1 {
            width: 236px;
        }
        .boton {
            margin: 0 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Administrar Secciones de Noticias</h1>
        <p>Crea, modifica o elimina secciones del sistema con este formulario</p>
    </div>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1" style="text-align: right"><p>Código de la sección:</p></td>
            <td>
                <asp:TextBox ID="txtCodigoSeccion" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="boton" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="text-align: right"><p>Nombre de la sección: </p></td>
            <td>
                <asp:TextBox ID="txtNombreSeccion" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="text-align: right">
            </td>
            <td>
                <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="boton" OnClick="btnCrear_Click" Enabled="False" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="boton" OnClick="btnModificar_Click" Enabled="False" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="boton" OnClick="btnEliminar_Click" Enabled="False" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </td>
        </tr>
    </table>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

