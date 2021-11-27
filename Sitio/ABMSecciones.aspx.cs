using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RefServicio;

public partial class ABMSecciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Secciones _unaSeccion = new ServicioEF().BuscarSeccion(txtCodigoSeccion.Text.Trim());

            if (txtCodigoSeccion.Text.Trim() == "")
            {
                lblMensaje.Text = "El codigo no puede ser vacio.";
                return;
            }

            if (_unaSeccion == null)
            {
                txtNombreSeccion.Text = "";

                txtNombreSeccion.Enabled = true;
                txtCodigoSeccion.Enabled = false;
                btnCrear.Enabled = true;
                btnModificar.Enabled = false;
            }
            else
            {
                txtNombreSeccion.Text = _unaSeccion.Nombre;
                txtCodigoSeccion.Text = _unaSeccion.CodigoSeccion;

                txtCodigoSeccion.Enabled = false;
                btnCrear.Enabled = false;
                btnEliminar.Enabled = true;
                btnEliminar.Visible = true;
                btnModificar.Enabled = true;
                btnModificar.Visible = true;
                txtNombreSeccion.Enabled = true;
                Session["Seccion"] = _unaSeccion;
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
        txtCodigoSeccion.Text = "";
        txtNombreSeccion.Text = "";

        PonerFormularioEnEstadoInicial();
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        Secciones S = null;

        try
        {
            S = new Secciones()
            {
                CodigoSeccion = txtCodigoSeccion.Text.Trim(),
                Nombre = txtNombreSeccion.Text.Trim(),
            };
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioEF().AltaSeccion(S);

            lblMensaje.Text = "Alta con Exito";

            txtCodigoSeccion.Text = "";
            txtNombreSeccion.Text = "";
            txtCodigoSeccion.Enabled = true;
            txtNombreSeccion.Enabled = false;

            btnCrear.Enabled = false;
            btnEliminar.Enabled = false;
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

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Secciones _unaS = (Secciones)Session["Seccion"];

            new ServicioEF().EliminarSeccion(_unaS);

            PonerFormularioEnEstadoInicial();

            txtCodigoSeccion.Text = "";
            txtNombreSeccion.Text = "";

            PonerFormularioEnEstadoInicial();

            lblMensaje.Text = "Baja con Exito";
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

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Secciones _unaS = (Secciones)Session["Seccion"];
            _unaS.CodigoSeccion = txtCodigoSeccion.Text.Trim();
            _unaS.Nombre = txtNombreSeccion.Text.Trim();

            new ServicioEF().ModificarSeccion(_unaS);

            PonerFormularioEnEstadoInicial();

            lblMensaje.Text = "Modificación con Exito";
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
    /// Devuelve el formulario a su estado inicial, en el que 
    /// el usuario puede hacer una búsqueda de sección.
    /// 
    /// Debe invocarse **ANTES** de mostrar un mensaje de éxito,
    /// pues la operación vacía el contenido de la label
    /// de mensajes
    /// </summary>
    private void PonerFormularioEnEstadoInicial()
    {
        lblMensaje.ForeColor = System.Drawing.Color.Black;
        lblMensaje.Text = "";

        txtCodigoSeccion.Text = "";
        txtNombreSeccion.Text = "";

        txtNombreSeccion.Enabled = false;
        txtCodigoSeccion.Enabled = true;

        btnBuscar.Visible = true;
        btnCrear.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
    }
}