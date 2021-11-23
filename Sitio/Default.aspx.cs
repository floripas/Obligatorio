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

                CargarDdlFiltroSeccion(servicio);

                CargarNoticiasEnGrilla(servicio);

                CargarFechasEnFiltro();
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

    private void CargarFechasEnFiltro()
    {
        ListItem item;
        DateTime fecha;

        for (int i = 0; i < 5; i++)
        {
            fecha = DateTime.Today.AddDays(-i); 
            item = new ListItem(fecha.ToShortDateString(), fecha.ToShortDateString());
            ddlFiltroFecha.Items.Add(item);
        }
    }

    private void CargarDdlFiltroSeccion(ServicioEF servicio)
    {
        List<Secciones> secciones = servicio.ListarSecciones().ToList<Secciones>();

        Session["secciones"] = secciones;

        ListItem item;

        foreach (Secciones seccion in secciones)
        {
            item = new ListItem(seccion.Nombre, seccion.CodigoSeccion);
            ddlFiltroSeccion.Items.Add(item);
        }
    }

    private void CargarNoticiasEnGrilla(ServicioEF servicio)
    {
        List<Noticias> noticias = servicio.MostrarNoticiasUltimosCincoDias().ToList<Noticias>();

        Session["noticias"] = noticias;

        grdNoticias.DataSource = noticias;
        grdNoticias.DataBind();
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

    protected void ddlFiltroSeccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Noticias> noticias = (List<Noticias>)Session["noticias"];

            string codigoSeccionSeleccionada = ddlFiltroSeccion.SelectedValue;

            if (codigoSeccionSeleccionada.ToLower() == "sin filtro")
            {
                LimpiarFiltros();
            }
            else
            {
                List<Noticias> noticiasFiltradas = noticias
                .Where(noticia => noticia.Secciones.CodigoSeccion == codigoSeccionSeleccionada)
                .ToList<Noticias>();

                grdNoticias.DataSource = noticiasFiltradas;

                lblMensaje.Text = noticiasFiltradas.Count > 0
                    ? "" 
                    : "Ninguna noticia reciente se publicó en la sección " + ddlFiltroSeccion.SelectedItem.Text;
            }
            
            grdNoticias.DataBind();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    protected void ddlFiltroFecha_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFiltros();
    }

    private void LimpiarFiltros()
    {
        List<Noticias> noticias = (List<Noticias>)Session["noticias"];

        lblMensaje.Text = "";
        
        grdNoticias.DataSource = noticias;
        grdNoticias.DataBind();
    }
}