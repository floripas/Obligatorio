<%@ Page Title="" Language="C#" MasterPageFile="~/Escritorio_MP.master" AutoEventWireup="true" CodeFile="AltaModificacionNoticias.aspx.cs" Inherits="AltaModificacionNacionales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Alta y modificación de noticias nacionales</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Alta y modificación de Noticias</h1>
        <p>Busca una noticia por su código. </p>
        <p>Si no existe ninguna noticia con ese código, podrás crear una noticia. </p>
        <p>Si el código ya se usó, el formulario te mostrará los datos de la noticia correspondiente.</p>
    </div>
    <table style="width: 100%;">
        <tr>
            <td>
                <label>Código de la noticia: </label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>Título: </label>
            </td>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>Sección: </label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSecciones" runat="server" Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label>Fecha de publicación: </label>
            </td>
            <td>
                <asp:Calendar ID="cldFechaPublicacion" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Enabled="True" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" SelectedDate="1970-01-01" Width="350px" Visible="True">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <label>Importancia de la noticia:</label>
            </td>
            <td>
                <asp:DropDownList ID="ddlImportancia" runat="server" Enabled="False">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label>Cuerpo de la noticia:</label>
            </td>
            <td>
                
                <asp:TextBox ID="txtCuerpo" runat="server" TextMode="MultiLine" Height="58px" Width="382px" Enabled="False"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                <label>Autores de la noticia:</label>
            </td>
            <td>
                
                <asp:CheckBoxList ID="chkPeriodistas" runat="server">
                </asp:CheckBoxList>
                
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar noticia" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnCrear" runat="server" Text="Crear noticia" Visible="False" OnClick="btnCrear_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar noticia"  Visible="False" OnClick="btnModificar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </td>
        </tr>
    </table>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

