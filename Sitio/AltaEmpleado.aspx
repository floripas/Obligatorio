<%@ Page Title="" Language="C#" MasterPageFile="~/Escritorio_MP.master" AutoEventWireup="true" CodeFile="AltaEmpleado.aspx.cs" Inherits="AltaEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Alta de empleados en el sistema</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Alta de empleados</h1>
        <p>Registra nuevos empleados en el sistema con este formulario</p>
    </div>
    <table>
        <tr>
            <td>
                <p>Nombre de usuario: </p>
            </td>
            <td>
                <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p>Contraseña: </p>
            </td>
            <td>
                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p>Confirma la contraseña: </p>
            </td>
            <td>
                <asp:TextBox ID="txtConfirmarContraseña" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCrear" runat="server" Text="Registrar empleado" OnClick="btnCrear_Click" />
            </td>
        </tr>
    </table>
    <div>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
</asp:Content>

