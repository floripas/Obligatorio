using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RefServicio;

public partial class UserControl_MostrarNoticia : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Noticias noticia = (Noticias)Session["noticiaSeleccionada"];

            lblCodigo.Text = noticia.Codigo;
            lblCuerpo.Text = noticia.Cuerpo;
            lblEmpleado.Text = noticia.Empleados.NombreUsuario;
            lblFecha.Text = noticia.FechaPublicacion.ToShortDateString();
            lblImportancia.Text = noticia.Importancia.ToString();
            lblTitulo.Text = noticia.Titulo;

            lblSeccion.Text = noticia.Secciones.Nombre;

            foreach (Periodistas p in noticia.Periodistas)
            {
                lblPeriodista.Text += p.Nombre + "<br />" + p.Cedula + "<br />" + p.Email + "<br />";
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}