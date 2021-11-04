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

    [WebMethod]
    public void EliminarPeriodista(Periodistas unP)
    {
        try
        {
            LogicaModeloEF.EliminarPeriodista(unP);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    #endregion

    #region Operaciones Secciones
    [WebMethod]
    public Secciones BuscarSeccion(string cod)
    {
        ModeloEF.Secciones _seccion = null;
        try
        {
            _seccion = LogicaModeloEF.BuscarSeccion(cod);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }

        return _seccion;
    }

    [WebMethod]
    public void AltaSeccion(Secciones unaS)
    {
        try
        {
            LogicaModeloEF.AltaSeccion(unaS);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void ModificarSeccion(Secciones unaS)
    {
        try
        {
            LogicaModeloEF.ModificarSeccion(unaS);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void EliminarSeccion(Secciones unaS)
    {
        try
        {
            LogicaModeloEF.EliminarSeccion(unaS);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public List<Secciones> ListarSecciones()
    {
        List<Secciones> _lista = null;
        try
        {
            _lista = LogicaModeloEF.ListarSecciones();
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return _lista;
    }
    #endregion

    #region Operaciones Noticias
    [WebMethod]
    public Noticias BuscarNoticia(string cod)
    {
        ModeloEF.Noticias _noticia = null;
        try
        {
            _noticia = LogicaModeloEF.BuscarNoticia(cod);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }

        return _noticia;
    }

    [WebMethod]
    public void ModificarNoticia(Noticias unaN)
    {
        try
        {
            LogicaModeloEF.ModificarNoticia(unaN);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void AltaNoticia(Noticias unaN)
    {
        try
        {
            LogicaModeloEF.AltaNoticia(unaN);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }
    #endregion
}
