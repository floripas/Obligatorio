using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        ddlSecciones.DataSource = new ServicioEFSoapClient().ListarSecciones().ToList();
        ddlSecciones.DataTextField = "Nombre";
        ddlSecciones.DataBind();
    }
    private void CargarChkPeriodistas()
    {
        chkPeriodistas.DataSource = new ServicioEFSoapClient().ListarPeriodistas().ToList();
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
        txtFecha.Enabled = false;
        ddlImportancia.Enabled = false;
        lstPeriodistas.Enabled = false;
    }
    private void LimpioControles()
    {
        txtCodigo.Text = "";
        txtCuerpo.Text = "";
        txtFecha.Text = "";
        txtTitulo.Text = "";
        lblMensaje.Text = "";

        txtCodigo.Enabled = false;
        txtCodigo.ReadOnly = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCodigo.Text.Length == 0)
                throw new Exception("El codigo de la noticia no puede ser vacio.");

            Noticias _unaNoticia = new ServicioEFSoapClient().BuscarNoticia(txtCodigo.Text.Trim());

            if (_unaNoticia == null)
            {
                txtCodigo.Enabled = false;
                txtCuerpo.Text = "";
                txtFecha.Text = "";
                txtTitulo.Text = "";

                txtTitulo.Enabled = true;
                txtCuerpo.Enabled = true;
                txtFecha.Enabled = true;
                ddlSecciones.Enabled = true;
                ddlImportancia.Enabled = true;
                lstPeriodistas.Enabled = true;
                btnBuscar.Enabled= false;

                lblMensaje.Text = "No hay ninguna una noticia con ese codigo. Puede ingresarla.";

                btnCrear.Enabled = true;
                btnModificar.Enabled = false;
            }
            else
            {
                txtCodigo.Text = _unaNoticia.Codigo;
                txtTitulo.Text = _unaNoticia.Titulo;
                txtCuerpo.Text = _unaNoticia.Cuerpo;
                txtFecha.Text = _unaNoticia.FechaPublicacion.ToString();

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
        try
        {
            Noticias _unaN = (Noticias)Session["Noticia"];

            _unaN.Codigo = txtCodigo.Text.Trim();
            _unaN.Secciones.Nombre = ddlSecciones.Text.Trim();
            _unaN.Titulo = txtTitulo.Text.Trim();
            _unaN.Cuerpo = txtCuerpo.Text.Trim();
            _unaN.Importancia = Convert.ToInt32(ddlImportancia.SelectedItem.Value);
            _unaN.FechaPublicacion = Convert.ToDateTime(txtFecha);
            

            new ServicioEFSoapClient().ModificarNoticia(_unaN);

            lblMensaje.Text = "Modificación con Exito";

            txtCodigo.Text = "";
            txtCuerpo.Text = "";
            txtFecha.Text = "";
            txtTitulo.Text = "";

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

    protected void btnCrear_Click(object sender, EventArgs e)
    {

        Noticias N = null;
        List<Periodistas> lista = new List<Periodistas>();
        foreach(ListItem item in chkPeriodistas.Items)
        {
            if(item.Selected)
            {
                lista.Add(new ServicioEFSoapClient().BuscarPeriodista(chkPeriodistas.SelectedItem.Value.ToString()));
            }
        }

        try
        {
            N = new Noticias()
            {
                Codigo = txtCodigo.Text.Trim(),
                Cuerpo = txtCuerpo.Text.Trim(),
                Titulo = txtTitulo.Text.Trim(),
                FechaPublicacion = Convert.ToDateTime(txtFecha.Text.Trim()),
                Importancia = Convert.ToInt32(ddlImportancia.SelectedItem.Value),
                Empleados = (Empleados)Session["usuarioLogueado"],
                Secciones = new ServicioEFSoapClient().BuscarSeccion(ddlSecciones.SelectedItem.Value),
                Periodistas = lista.ToArray<Periodistas>()
            };
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioEFSoapClient().AltaNoticia(N);

            lblMensaje.Text = "Alta con Exito";

            txtCodigo.Text = "";
            txtCuerpo.Text = "";
            txtTitulo.Text = "";
            txtFecha.Text = "";

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
