<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de noticias de los últimos 5 días</title>
    <style>
        .form {
            margin: 0 auto;
            display: flex;
            justify-content: center;
            flex-direction: column;
            align-items: center;
        }

        .form p:first-of-type{
            text-align: right;
        }

        #grdNoticias {
            margin: 1em 0;
        }

        .filtros {
            display: flex;
            flex-direction: column;
            margin: 1em 0;
        }

        .instrucciones-filtro {
            display: inline-block;
        }

        .filtros select {
            margin: 0 2em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form">
        <div class="filtros">
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Logueo.aspx">Loguéate</asp:HyperLink>
            </p>
            <div>
                <p class="instrucciones-filtro">Filtra las noticias por secciones usando este menú desplegable: </p>
            <asp:DropDownList ID="ddlFiltroSeccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltroSeccion_SelectedIndexChanged">
                <asp:ListItem Selected="True">Sin filtro</asp:ListItem>
            </asp:DropDownList>
                 <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar filtros" />
            </div>
            <div>
                <p class="instrucciones-filtro">
                Filtra las noticias por fecha usando este menú desplegable: 
            </p>
            <asp:DropDownList ID="ddlFiltroFecha" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True">Sin filtro</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <asp:GridView ID="grdNoticias" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdNoticias_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Titulo" DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField AccessibleHeaderText="Fecha de publicación" DataField="FechaPublicacion" HeaderText="Fecha de publicación" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
