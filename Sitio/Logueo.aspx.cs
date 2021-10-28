using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RefServicio;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLoguear_Click(object sender, EventArgs e)
    {
        try
        {
            //Obtengo datos y consulto si existe
            Empleados emp = new ServicioEF().Logueo(txtNombreUsuario.Text, txtContraseña.Text);

            //Si encontre paso al sistema
            if (emp != null)
            {
                Session["Empleado"] = emp;
                Response.Redirect("~/Escritorio.aspx");
            }
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            //Sino doy mensaje de error
            lblMensaje.Text = ex.Detail.InnerText;
            txtContraseña.Text = "";
            txtNombreUsuario.Text = "";
        }
        catch (Exception ex)
        {
            //Sino doy mensaje de error
            lblMensaje.Text = ex.Message;
            txtContraseña.Text = "";
            txtNombreUsuario.Text = "";
        }
    }
}