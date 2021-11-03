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
    }

    #region Operaciones Empleados

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

    [WebMethod]
    public void AltaEmpleado(Empleados E)
    {
        try
        {
            LogicaModeloEF.AltaEmpleado(E);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    #endregion

    #region Operaciones Periodistas
    [WebMethod]
    public Periodistas BuscarPeriodista(string ced)
    {
        ModeloEF.Periodistas _periodista= null;
        try
        {
            _periodista = LogicaModeloEF.BuscarPeriodista(ced);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }

        return _periodista;
    }

    [WebMethod]
    public void AltaPeriodista(Periodistas P)
    {
        try
        {
            LogicaModeloEF.AltaPeriodista(P);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void ModificarPeriodista(Periodistas unP)
    {
        try
        {
            LogicaModeloEF.ModificarPeriodista(unP);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    #endregion
}
