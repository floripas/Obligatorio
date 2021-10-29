using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using ModeloEF;

public class LogicaModeloEF
{
    private static ObligatorioEntities _OEcontext = null;

    public static ObligatorioEntities OEcontext
    {
        get
        {
            if (_OEcontext == null)
            {
                _OEcontext = new ObligatorioEntities();
                _OEcontext.Configuration.ProxyCreationEnabled = false;
            }
            return _OEcontext;
        }
    }

    //Operaciones USUARIOs
    public static Empleados Logueo(string usu, string pass)
    {
        Empleados emp = OEcontext.Empleados.Where(e => e.NombreUsuario == usu.Trim() && e.Contraseña == pass.Trim()).FirstOrDefault();

        if (emp != null)
        {
            return emp;
        }
        else
        {
            throw new Exception("Usuario / Contraseña incorrectos");
        }
    }
}