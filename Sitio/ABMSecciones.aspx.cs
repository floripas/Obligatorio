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
            Secciones _unaSeccion = new ServicioEFSoapClient().BuscarSeccion(txtCodigoSeccion.Text.Trim());

            if (_unaSeccion == null)
            {
                txtCodigoSeccion.Text = "";
                txtNombreSeccion.Text = "";

                btnCrear.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = false;
            }
            else
            {
                txtNombreSeccion.Text = _unaSeccion.Nombre;
                txtCodigoSeccion.Text = _unaSeccion.CodigoSeccion;

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
            new ServicioEFSoapClient().AltaSeccion(S);

            lblMensaje.Text = "Alta con Exito";

            txtCodigoSeccion.Text = "";
            txtNombreSeccion.Text = "";

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

            new ServicioEFSoapClient().EliminarSeccion(_unaS);

            lblMensaje.Text = "Baja con Exito";

            txtCodigoSeccion.Text = "";
            txtNombreSeccion.Text = "";

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

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Secciones _unaS = (Secciones)Session["Seccion"];
            _unaS.CodigoSeccion = txtCodigoSeccion.Text.Trim();
            _unaS.Nombre = txtNombreSeccion.Text.Trim();

            new ServicioEFSoapClient().ModificarSeccion(_unaS);

            lblMensaje.Text = "Modificación con Exito";

            txtNombreSeccion.Text = "";
            txtCodigoSeccion.Text = "";

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

    private void PonerFormularioEnEstadoInicial()
    {
        lblMensaje.ForeColor = System.Drawing.Color.Black;
        lblMensaje.Text = "";

        txtCodigoSeccion.Text = "";
        txtNombreSeccion.Text = "";

        txtNombreSeccion.Enabled = false;

        btnBuscar.Visible = true;
        btnCrear.Visible = false;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
    }
}