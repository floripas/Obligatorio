using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefServicio;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ServicioEFSoapClient servicio = new ServicioEFSoapClient();

            List<Noticias> noticias = servicio.MostrarNoticiasUltimosCincoDias().ToList<Noticias>();

            Session["noticias"] = noticias;

            grdNoticias.DataSource = noticias;
            grdNoticias.DataBind();
        }
    }

    protected void grdNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}