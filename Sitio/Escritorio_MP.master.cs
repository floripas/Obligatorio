using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RefServicio;

public partial class Obligatorio : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                return;
            }

            Empleados quizasUsuarioLogueado = (Empleados)Session["usuarioLogueado"];

            if (quizasUsuarioLogueado == null)
            {
                Response.Redirect("Logueo.aspx");
                return;
            }

            lblNombreUsuario.Text = quizasUsuarioLogueado.NombreUsuario;
        }
        catch
        {
            DesloguearUsuario();
        }
    }

    protected void btnDeslogueo_Click(object sender, EventArgs e)
    {
        DesloguearUsuario();
    }

    private void DesloguearUsuario()
    {
        Session["usuarioLogueado"] = null;
        Response.Redirect("Logueo.aspx");
    }
}
