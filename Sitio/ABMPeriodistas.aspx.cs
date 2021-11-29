using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RefServicio;

public partial class ABMPeriodistas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void PonerFormularioEnEstadoInicial()
    {
        LblError.ForeColor = System.Drawing.Color.Black;
        LblError.Text = "";

        txtCedula.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";

        txtEmail.Enabled = false;
        txtNombre.Enabled = false;
        txtCedula.Enabled = true;

        btnBuscar.Visible = true;
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;
        btnActivar.Enabled = false;
        btnActivar.Visible = false;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Periodistas _unPeriodista = new ServicioEF().BuscarPeriodista(txtCedula.Text.Trim());

            if (txtCedula.Text.Trim() == "")
            {
                LblError.Text = "La cedula ingresada no puede ser vacia.";
                return;
            }

            if (_unPeriodista == null)
            {
                txtNombre.Text = "";
                txtEmail.Text = "";

                txtNombre.Enabled = true;
                txtEmail.Enabled = true;
                txtCedula.Enabled = false;
                btnAlta.Enabled = true;
                btnModificar.Enabled = false;
            }
            else if (_unPeriodista.Activo == false)
            {
                LblError.Text = "Existe el periodista pero se encuentra inactivo.";
                txtCedula.Text = _unPeriodista.Cedula;
                txtNombre.Text = _unPeriodista.Nombre;
                txtEmail.Text = _unPeriodista.Email;

                txtCedula.Enabled = false;
                txtNombre.Enabled = false;
                txtEmail.Enabled = false;
                btnActivar.Enabled = true;
                btnActivar.Visible = true;
                Session["Periodista"] = _unPeriodista;
            }
            else
            {
                txtNombre.Text = _unPeriodista.Nombre;
                txtEmail.Text = _unPeriodista.Email;
                txtCedula.Text = _unPeriodista.Cedula;

                txtCedula.Enabled = false;
                btnAlta.Enabled = false;
                btnBaja.Enabled = true;
                btnBaja.Visible = true;
                btnModificar.Enabled = true;
                btnModificar.Visible = true;
                txtNombre.Enabled = true;
                txtEmail.Enabled = true;
                Session["Periodista"] = _unPeriodista;
            }
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            LblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        Periodistas P = null;

        try
        {
            P = new Periodistas()
            {
                Nombre = txtNombre.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioEF().AltaPeriodista(P);

            LblError.Text = "Alta con Exito";

            txtNombre.Text = "";
            txtCedula.Text = "";
            txtEmail.Text = "";

            txtCedula.Enabled = true;
            txtNombre.Enabled = false;
            txtEmail.Enabled = false;

            btnAlta.Enabled = false;
            btnBaja.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            LblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Periodistas _unPer = (Periodistas)Session["Periodista"];

            new ServicioEF().EliminarPeriodista(_unPer);

            PonerFormularioEnEstadoInicial();

            txtCedula.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";

            PonerFormularioEnEstadoInicial();

            LblError.Text = "Baja con Exito";
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            LblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Periodistas _unP = (Periodistas)Session["Periodista"];
            _unP.Cedula = txtCedula.Text.Trim();
            _unP.Nombre = txtNombre.Text.Trim();
            _unP.Email = txtEmail.Text.Trim();

            new ServicioEF().ModificarPeriodista(_unP);

            PonerFormularioEnEstadoInicial();

            LblError.Text = "Modificación con Exito";
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            LblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtCedula.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";

        PonerFormularioEnEstadoInicial();
    }

    protected void btnActivar_Click(object sender, EventArgs e)
    {
        try
        {
            Periodistas _unP = (Periodistas)Session["Periodista"];
            _unP.Cedula = txtCedula.Text.Trim();
            _unP.Nombre = txtNombre.Text.Trim();
            _unP.Email = txtEmail.Text.Trim();
            _unP.Activo = true;

            new ServicioEF().ActivarPeriodista(_unP);

            PonerFormularioEnEstadoInicial();

            LblError.Text = "Activación con Exito";
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            LblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}