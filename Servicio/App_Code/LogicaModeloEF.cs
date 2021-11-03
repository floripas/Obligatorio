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

    #region OperacionesEmpleados
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

    public static void AltaEmpleado(Empleados unE)
    {
        Empleados E = null;
        try
        {
            E = OEcontext.Empleados.Where(e => e.NombreUsuario == unE.NombreUsuario).FirstOrDefault();

            if (E != null)
            {
                throw new Exception("Ya existe un empleado con ese nombre de usuario.");
            }

            E = new Empleados()
            {
                NombreUsuario = unE.NombreUsuario,
                Contraseña = unE.Contraseña
            };

            new Validaciones().Validar(E);

            OEcontext.Empleados.Add(E);
            OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}