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

    private void DesactivoBotones()
    {
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
    }

    private void LimpioControles()
    {
        txtCedula.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";
        LblError.Text = "";

        txtCedula.Enabled = false;
        txtCedula.ReadOnly = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Periodistas _unPeriodista = new ServicioEF().BuscarPeriodista(txtCedula.Text);

            if (_unPeriodista == null)
            {
                txtNombre.Text = "";
                txtEmail.Text = "";

                btnAlta.Enabled = true;
                btnBaja.Enabled = true;
                btnModificar.Enabled = false;
            }
            else
            {
                txtNombre.Text = _unPeriodista.Nombre;
                txtCedula.Text = _unPeriodista.Cedula;
                txtEmail.Text = _unPeriodista.Email;

                btnAlta.Enabled = false;
                btnBaja.Enabled = true;
                btnModificar.Enabled = true;
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

            LblError.Text = "Baja con Exito";

            txtNombre.Text = "";
            txtCedula.Text = "";
            txtEmail.Text = "";

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

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Periodistas _unP = (Periodistas)Session["Periodista"];
            _unP.Cedula = txtCedula.Text.Trim();
            _unP.Nombre = txtNombre.Text.Trim();
            _unP.Email = txtEmail.Text.Trim();

            new ServicioEF().ModificarPeriodista(_unP);

            LblError.Text = "Modificación con Exito";

            txtNombre.Text = "";
            txtCedula.Text = "";
            txtEmail.Text = "";

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

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Periodista"] = null;
            DesactivoBotones();
            LimpioControles();
            txtCedula.Enabled = true;
            txtCedula.ReadOnly = false;
        }
        catch(Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}