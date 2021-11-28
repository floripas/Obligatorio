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
                Session["secciones"] = null;
                Session["noticias"] = null;
                Session["noticiaSeleccionada"] = null;
                Session["noticiasFiltradas"] = null;

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
        Session["noticiasFiltradas"] = noticias;

        grdNoticias.DataSource = noticias;
        grdNoticias.DataBind();
    }

    protected void grdNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // si hay noticias filtradas, se carga noticias con ellas;
            // de lo contrario, se carga con las noticias sin filtrar
            List<Noticias> noticias = (List<Noticias>)Session["noticiasFiltradas"] != null && ((List<Noticias>)Session["noticiasFiltradas"]).Count > 0 
                ? (List<Noticias>)Session["noticiasFiltradas"] 
                : (List<Noticias>)Session["noticias"];

            Noticias noticiaSeleccionada = noticias[grdNoticias.SelectedIndex];

            Session["noticiaSeleccionada"] = noticiaSeleccionada;
            Response.Redirect("~/ConsultaNoticia.aspx");

            return;
        }
        /**
         * Response.Redirect lanza una excepción ThreadAbortException
         * para detener la ejecución del hilo actual y proceder
         * a realizar la redirección
         *
         * @see https://stackoverflow.com/a/12957854/6951887
         * 
         * Este catch sirve para capturar e ignorar esta excepción
         * 
         * Rafael 28/11/2021
         */
        catch (System.Threading.ThreadAbortException ex) { }
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

            FiltrarNoticias(noticias, ddlFiltroFecha.SelectedValue, ddlFiltroSeccion.SelectedValue);
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    private void FiltrarNoticiasPorSeccionYFecha(List<Noticias> noticias, string codigoSeccion, string fecha)
    {
        List<Noticias> noticiasFiltradas = noticias
            .Where(noticia => noticia.Secciones.CodigoSeccion == codigoSeccion)
            .Where(noticia => noticia.FechaPublicacion.ToShortDateString() == fecha)
            .ToList<Noticias>();

        grdNoticias.DataSource = noticiasFiltradas;
        grdNoticias.DataBind();

        Session["noticiasFiltradas"] = noticiasFiltradas;

        lblMensaje.Text = noticiasFiltradas.Count > 0
            ? ""
            : "Ninguna noticia reciente se publicó en la sección " + codigoSeccion + " el día " + fecha;
    }

    private void FiltrarNoticiasPorFecha(List<Noticias> noticias, string fecha)
    {
        List<Noticias> noticiasFiltradas = noticias
            .Where(noticia => noticia.FechaPublicacion.ToShortDateString() == fecha)
            .ToList<Noticias>();

        grdNoticias.DataSource = noticiasFiltradas;
        grdNoticias.DataBind();

        Session["noticiasFiltradas"] = noticiasFiltradas;

        lblMensaje.Text = noticiasFiltradas.Count > 0
                    ? ""
                    : "Ninguna noticia reciente se publicó en la fecha " + fecha;
    }

    private void FiltrarNoticiasPorSeccion(List<Noticias> noticias, string codigoSeccion)
    {
        List<Noticias> noticiasFiltradas = noticias
            .Where(noticia => noticia.Secciones.CodigoSeccion == codigoSeccion)
            .ToList<Noticias>();

        grdNoticias.DataSource = noticiasFiltradas;
        grdNoticias.DataBind();

        Session["noticiasFiltradas"] = noticiasFiltradas;

        lblMensaje.Text = noticiasFiltradas.Count > 0
            ? ""
            : "Ninguna noticia reciente se publicó en la sección " + codigoSeccion;
    }

    protected void ddlFiltroFecha_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Noticias> noticias = (List<Noticias>)Session["noticias"];

            FiltrarNoticias(noticias, ddlFiltroFecha.SelectedValue, ddlFiltroSeccion.SelectedValue);
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    /// <summary>
    /// Filtra la lista de noticias usando la fecha 
    /// y el código de sección recibidos
    /// </summary>
    /// <param name="noticias">Listado de noticias a filtrar</param>
    /// <param name="fechaSeleccionada">Un string que representa una fecha</param>
    /// <param name="codigoSeccion">El código de la sección</param>
    private void FiltrarNoticias(List<Noticias> noticias, string fechaSeleccionada, string codigoSeccion)
    {
        if (codigoSeccion.ToLower() == "sin filtro" && fechaSeleccionada.ToLower() == "sin filtro")
        {
            LimpiarFiltros();
        }
        else if (codigoSeccion.ToLower() != "sin filtro" && fechaSeleccionada.ToLower() == "sin filtro")
        {
            FiltrarNoticiasPorSeccion(noticias, codigoSeccion);
        }
        else if (codigoSeccion.ToLower() == "sin filtro" && fechaSeleccionada.ToLower() != "sin filtro")
        {
            FiltrarNoticiasPorFecha(noticias, fechaSeleccionada);
        }
        else
        {
            FiltrarNoticiasPorSeccionYFecha(noticias, codigoSeccion, fechaSeleccionada);
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFiltros();
    }

    private void LimpiarFiltros()
    {
        List<Noticias> noticias = (List<Noticias>)Session["noticias"];
        Session["noticiasFiltradas"] = noticias;

        ddlFiltroFecha.SelectedIndex = 0;
        ddlFiltroSeccion.SelectedIndex = 0;

        lblMensaje.Text = "";

        grdNoticias.DataSource = noticias;
        grdNoticias.DataBind();
    }
}