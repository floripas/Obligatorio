<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaNoticia.aspx.cs" Inherits="ConsultaNoticia" %>

<%@ Register src="MostrarNoticia.ascx" tagname="MostrarNoticia" tagprefix="uc1" %>

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
            <uc1:MostrarNoticia ID="MostrarNoticia1" runat="server" />
        </div>
    </form>
</body>
</html>
