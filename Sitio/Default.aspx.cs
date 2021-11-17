using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using RefServicio;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ServicioEF servicio = new ServicioEF();

                List<Noticias> noticias = servicio.MostrarNoticiasUltimosCincoDias().ToList<Noticias>();

                Session["noticias"] = noticias;

                grdNoticias.DataSource = noticias;
                grdNoticias.DataBind();
            }
        }
        catch (SoapException ex)
        {
            lblMensaje.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    protected void grdNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Noticias> noticias = (List<Noticias>)Session["noticias"];

            Noticias noticiaSeleccionada = noticias[grdNoticias.SelectedIndex];

            Session["noticiaSeleccionada"] = noticiaSeleccionada;
            Response.Redirect("~/ConsultaNoticia.aspx");
        }
        catch (SoapException ex)
        {
            lblMensaje.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}