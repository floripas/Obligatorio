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
            if (txtContraseña.Text.Trim() != txtConfirmarContraseña.Text.Trim())
            {
                throw new Exception("Las contraseñas no coinciden.");
            }

            E = new Empleados()
            {
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                Contraseña = txtContraseña.Text.Trim()
            };

            new ServicioEF().AltaEmpleado(E);

            lblError.Text = "Alta con Exito";

            txtConfirmarContraseña.Text = "";
            txtContraseña.Text = "";
            txtNombreUsuario.Text = "";

            btnCrear.Enabled = false;
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            //Sino doy mensaje de error
            lblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        //Empleados E = null;

        //try
        //{
        //    E = new Empleados()
        //    {
        //        NombreUsuario = txtNombreUsuario.Text,
        //        Contraseña = txtContraseña.Text,
        //        Noticias = null
        //    };
        //    if (txtContraseña.Text != txtConfirmarContraseña.Text)
        //    {
        //        throw new Exception("Las contraseñas no coinciden");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblError.Text = ex.Message;
        //    return;
        //}

        //try
        //{
        //    new ServicioEF().AltaEmpleado(E);

        //    lblError.Text = "Alta con Exito";

        //    txtNombreUsuario.Text = "";
        //    txtContraseña.Text = "";
        //    txtConfirmarContraseña.Text = "";

        //    btnCrear.Enabled = false;
        //}
        //catch (System.Web.Services.Protocols.SoapException ex)
        //{
        //    lblError.Text = ex.Detail.InnerText;
        //}
        //catch (Exception ex)
        //{
        //    lblError.Text = ex.Message;
        //}
    }
}