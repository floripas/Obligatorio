using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RefServicio;

public partial class Escritorio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSaludoUsuario.Text = ((Empleados)Session["usuarioLogueado"]).NombreUsuario;
    }
}