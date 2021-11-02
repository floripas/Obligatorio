using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RefServicio;

public partial class AltaEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        Empleados E = null;

        try
        {
            E = new Empleados()
            {
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContraseña.Text,
            };
            if (txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                throw new Exception("Las contraseñas no coinciden");
            }
            new Validaciones().Validar(E); //No logro ver la clase validaciones.
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioEF().AltaEmpleado(E);

            lblError.Text = "Alta con Exito";

            txtNombreUsuario.Text = "";
            txtContraseña.Text = "";
            txtConfirmarContraseña.Text = "";

            btnCrear.Enabled = false;
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}