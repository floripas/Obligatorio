using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Xml;
using System.Web.Services.Protocols;
using ModeloEF;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class ServicioEF : System.Web.Services.WebService
{
    private void GeneroSoapException(Exception ex)
    {
        XmlDocument _undoc = new System.Xml.XmlDocument();
        XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
        XmlNode _NodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
        _NodoDetalle.InnerText = ex.Message;
        _NodoError.AppendChild(_NodoDetalle);
        SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);
        throw _MiEx;
        //asds
    }

    [WebMethod]
    public Empleados Logueo(string usu, string pass)
    {
        Empleados emp = null;
        try
        {
            emp = LogicaModeloEF.Logueo(usu, pass);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }

        return emp;
    }
}
