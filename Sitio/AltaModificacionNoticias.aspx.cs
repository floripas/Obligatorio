using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using RefServicio;

public partial class AltaModificacionNacionales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Session["Periodistas"] = null;
                Session["Secciones"] = null;

                CargarChkPeriodistas();
                CargarDDLSecciones();
                InhabilitarCalendario();
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                lblMensaje.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }

    private void CargarDDLSecciones()
    {
        List<Secciones> secciones = new ServicioEF().ListarSecciones().ToList();

        Session["Secciones"] = secciones;

        ddlSecciones.DataSource = secciones;
        ddlSecciones.DataValueField = "CodigoSeccion";
        ddlSecciones.DataTextField = "Nombre";
        ddlSecciones.DataBind();

        // se selecciona el elemento vacío 
        ddlSecciones.SelectedIndex = 0;
    }
    private void CargarChkPeriodistas()
    {
        chkPeriodistas.DataSource = new ServicioEF().ListarPeriodistas().ToList();
        chkPeriodistas.DataValueField = "Cedula";
        chkPeriodistas.DataTextField = "Nombre";
        chkPeriodistas.DataBind();
    }
    private void DesactivoBotones()
    {
        btnCrear.Enabled = false;
        btnModificar.Enabled = false;
        txtTitulo.Enabled = false;
        txtCuerpo.Enabled = false;
        ddlSecciones.Enabled = false;
        cldFechaPublicacion.Enabled = false;
        ddlImportancia.Enabled = false;
    }

    private void LimpiarCalendario()
    {
        cldFechaPublicacion.VisibleDate = DateTime.Today;
        cldFechaPublicacion.SelectedDate = new DateTime(1970, 1, 1);
    }
    private void LimpioControles()
    {
        txtCodigo.Text = "";
        txtCuerpo.Text = "";
        txtTitulo.Text = "";
        lblMensaje.Text = "";
        InhabilitarCalendario();

        txtCodigo.Enabled = false;
        txtCodigo.ReadOnly = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCodigo.Text.Length == 0)
                throw new Exception("La casilla con el codigo de la noticia no puede estar vacía.");

            Noticias _unaNoticia = new ServicioEF().BuscarNoticia(txtCodigo.Text.Trim());

            if (_unaNoticia == null)
            {
                txtCodigo.Enabled = false;
                txtCuerpo.Text = "";
                txtTitulo.Text = "";
                LimpiarCalendario();

                HabilitarCalendario();
                txtTitulo.Enabled = true;
                txtCuerpo.Enabled = true;
                ddlSecciones.Enabled = true;
                ddlImportancia.Enabled = true;
                btnBuscar.Enabled = false;

                lblMensaje.Text = "No hay ninguna una noticia con ese codigo. Puede ingresarla.";

                btnCrear.Enabled = true;
                btnCrear.Visible = true;
                btnModificar.Enabled = false;
            }
            else
            {
                txtCodigo.Text = _unaNoticia.Codigo;
                txtTitulo.Text = _unaNoticia.Titulo;
                txtCuerpo.Text = _unaNoticia.Cuerpo;

                /**
                 * si no se elimina la selección previa de los menús 
                 * desplegables, se producirá la excepción:
                 * System.Web.HttpException: No puede haber varios elementos 
                 * seleccionados en DropDownList
                 * 
                 * @see https://stackoverflow.com/a/8853523/6951887
                 */
                ddlSecciones.ClearSelection();
                ddlImportancia.ClearSelection();

                // cargar datos en menú desplegable de secciones
                SeleccionarElementosEnListControl(_unaNoticia, ddlSecciones, (noticia, item) => noticia.Secciones.CodigoSeccion == item.Value);

                // cargar datos en menú desplegable de importancia
                SeleccionarElementosEnListControl(_unaNoticia, ddlImportancia, (noticia, item) => noticia.Importancia.ToString() == item.Value);

                // cargar datos en checkboxes
                SeleccionarElementosEnListControl(_unaNoticia, chkPeriodistas, (noticia, item) => noticia.Periodistas.Where(periodista => periodista.Cedula == item.Value).Any());

                // cargar datos en el calendario
                cldFechaPublicacion.SelectedDate = _unaNoticia.FechaPublicacion;
                cldFechaPublicacion.VisibleDate = _unaNoticia.FechaPublicacion;

                txtTitulo.Enabled = true;
                txtCuerpo.Enabled = true;
                ddlSecciones.Enabled = true;
                ddlImportancia.Enabled = true;
                HabilitarCalendario();

                btnCrear.Enabled = false;
                btnModificar.Enabled = true;
                btnModificar.Visible = true;
                Session["Noticia"] = _unaNoticia;
            }
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblMensaje.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    /// <summary>
    /// Carga datos en un ListControl, un control web que contiene 
    /// una lista de ListItems.
    /// 
    /// El predicado es una expresión lambda que consume una noticia y un ListItem, y los compara. 
    /// 
    /// El resultado de esa comparación debe producir un booleano: si es true, el ListItem será seleccionado
    /// </summary>
    /// <param name="unaNoticia">La noticia que se usará para seleccionar datos en el control </param>
    /// <param name="control">El control con una lista de objetos ListItem</param>
    /// <param name="predicado">Es una expresión lambda que consume una noticia y un ListItem, y debe producir un booleano</param>
    private void SeleccionarElementosEnListControl(Noticias unaNoticia, ListControl control, Func<Noticias, ListItem, bool> predicado)
    {
        foreach (ListItem item in control.Items)
        {
            if (predicado(unaNoticia, item))
            {
                item.Selected = true;
            }
        }
    }

    private void HabilitarCalendario()
    {
        cldFechaPublicacion.Enabled = true;
        cldFechaPublicacion.Visible = true;
    }

    /// <summary>
    /// Inhabilita y limpia el calendario del formulario
    /// </summary>
    private void InhabilitarCalendario()
    {
        cldFechaPublicacion.Enabled = false;
        cldFechaPublicacion.Visible = false;
        LimpiarCalendario();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Periodista"] = null;
            DesactivoBotones();
            LimpioControles();
            btnBuscar.Enabled = true;
            txtCodigo.Enabled = true;
            txtCodigo.ReadOnly = false;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        ServicioEF servicio = new ServicioEF();
        try
        {
            Noticias _unaN = (Noticias)Session["Noticia"];

            _unaN.Codigo = txtCodigo.Text.Trim();
            _unaN.Secciones.Nombre = ddlSecciones.Text.Trim();
            _unaN.Titulo = txtTitulo.Text.Trim();
            _unaN.Cuerpo = txtCuerpo.Text.Trim();
            _unaN.Importancia = Convert.ToInt32(ddlImportancia.SelectedItem.Value);
            _unaN.FechaPublicacion = cldFechaPublicacion.SelectedDate;
            _unaN.Periodistas = ObtenerPeriodistasSeleccionados(servicio);
            

            servicio.ModificarNoticia(_unaN);

            lblMensaje.Text = "Modificación con Exito";

            txtCodigo.Text = "";
            txtCuerpo.Text = "";
            txtTitulo.Text = "";
            InhabilitarCalendario();

            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblMensaje.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    private Periodistas[] ObtenerPeriodistasSeleccionados(ServicioEF servicio)
    {
        // si no se eligió ningún periodista, lanza una excepción
        if (chkPeriodistas.SelectedIndex < 0)
        {
            throw new Exception("Tienes que marcar al menos un periodista como autor de la noticia");
        }

        List<Periodistas> resultado= new List<Periodistas>();

        Periodistas periodistaSeleccionado;

        foreach (ListItem item in chkPeriodistas.Items)
        {
            if (item.Selected)
            {
                periodistaSeleccionado = servicio.BuscarPeriodista(item.Value);
                resultado.Add(periodistaSeleccionado);
            }
        }        

        return resultado.ToArray<Periodistas>();
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {

        Noticias N = null;
        ServicioEF servicio = new ServicioEF();

        try
        {
            // ObtenerPeriodistasSeleccionados tiene que estar dentro
            // del bloque try porque puede lanzar una excepción
            List<Periodistas> lista = ObtenerPeriodistasSeleccionados(servicio);

            N = new Noticias()
            {
                Codigo = txtCodigo.Text.Trim(),
                Cuerpo = txtCuerpo.Text.Trim(),
                Titulo = txtTitulo.Text.Trim(),
                FechaPublicacion = cldFechaPublicacion.SelectedDate,
                Importancia = Convert.ToInt32(ddlImportancia.SelectedItem.Value),
                Empleados = (Empleados)Session["usuarioLogueado"],
                Secciones = servicio.BuscarSeccion(ddlSecciones.SelectedItem.Value),
                Periodistas = ObtenerPeriodistasSeleccionados(servicio)
            };
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            return;
        }

        try
        {
            servicio.AltaNoticia(N);

            lblMensaje.Text = "Alta con Exito";

            txtCodigo.Text = "";
            txtCuerpo.Text = "";
            txtTitulo.Text = "";
            InhabilitarCalendario();

            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblMensaje.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}
