<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Página de logueo</title>
    <style type="text/css">
        .auto-style1 {
            width: 450px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server" style="">
        <div>
            <h1>Página de logueo</h1>
        </div>
        <table>
            <tr>
                <td class="auto-style2">
                    
                </td>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Volver a Default</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Nombre de usuario: "></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style1">
                    <asp:Button ID="btnLoguear" runat="server" Text="Acceder" OnClick="btnLoguear_Click" />
                </td>
            </tr>
        </table>
        <div><asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>
