using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using RefServicio;

public partial class ConsultaNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Noticias noticia = (Noticias)Session["noticiaSeleccionada"];

            TxtCodigo.Text = noticia.Codigo;
            TxtTitulo.Text = noticia.Titulo;
            TxtCuerpo.Text = noticia.Cuerpo;
            TxtFecha.Text = noticia.FechaPublicacion.ToShortDateString();
            TxtImportancia.Text = noticia.Importancia.ToString();
            TxtSeccion.Text = noticia.Secciones.Nombre;

            foreach (Periodistas periodista in noticia.Periodistas)
            {
                LstPeriodistas.Items.Add(periodista.Nombre);
            }

        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}