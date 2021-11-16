<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
