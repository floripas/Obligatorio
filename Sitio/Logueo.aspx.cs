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
            Empleados emp = new ServicioEF().Logueo(txtNombreUsuario.Text, txtContraseña.Text);

            if (emp != null)
            {
                Session["Empleado"] = emp;
                Response.Redirect("~/Escritorio.aspx");
            }
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblMensaje.Text = ex.Detail.InnerText;
            txtContraseña.Text = "";
            txtNombreUsuario.Text = "";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            txtContraseña.Text = "";
            txtNombreUsuario.Text = "";
        }
    }
}