﻿using System;
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
            OEcontext.Entry(unE).State = System.Data.Entity.EntityState.Detached;

            throw ex;
        }
    }
    #endregion

    #region Operaciones Periodistas
    public static Periodistas BuscarPeriodista(string ced)
    {
        return (OEcontext.Periodistas.Where(p => p.Cedula == ced).FirstOrDefault());
    }

    public static void AltaPeriodista(Periodistas unP)
    {
        Periodistas P = null;
        try
        {
            P = OEcontext.Periodistas.Where(e => e.Cedula == unP.Cedula).FirstOrDefault();

            if (P != null)
            {
                throw new Exception("Ya existe un periodista con esa cedula.");
            }

            P = new Periodistas()
            {
                Nombre = unP.Nombre,
                Email = unP.Email,
                Cedula = unP.Cedula
            };

            new Validaciones().Validar(P);

            OEcontext.Periodistas.Add(P);
            OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            OEcontext.Entry(unP).State = System.Data.Entity.EntityState.Detached;

            throw ex;
        }
    }

    public static void ModificarPeriodista(Periodistas unP)
    {
        try
        {
            Periodistas P = OEcontext.Periodistas.Where(p => p.Cedula == unP.Cedula).FirstOrDefault();

            P.Email = unP.Email;
            P.Nombre = unP.Nombre;

            OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            OEcontext.Entry(unP).State = System.Data.Entity.EntityState.Detached;

            throw ex;
        }
    }

    public static void EliminarPeriodista(Periodistas unP)
    {
        try
        {
            SqlParameter _cedula = new SqlParameter("@Cedula", unP.Cedula);
            SqlParameter _retorno = new SqlParameter("@ret", System.Data.SqlDbType.Int);

            _retorno.Direction = System.Data.ParameterDirection.Output;

            OEcontext.Database.ExecuteSqlCommand("exec EliminarPeriodista @Cedula, @ret output", _cedula, _retorno);

            if ((int)_retorno.Value == -1)
                throw new Exception("No existe un periodista con la cedula ingresada");
            if ((int)_retorno.Value == -2)
                throw new Exception("Hubo un error y no se pudo eliminar el periodista de la base de datos");
            else
                OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Operaciones Secciones
    public static Secciones BuscarSeccion(string cod)
    {
        return (OEcontext.Secciones.Where(s => s.CodigoSeccion == cod).FirstOrDefault());
    }

    public static void AltaSeccion(Secciones unaS)
    {
        Secciones S = null;
        try
        {
            S = OEcontext.Secciones.Where(s => s.CodigoSeccion == unaS.CodigoSeccion).FirstOrDefault();

            if (S != null)
            {
                throw new Exception("Ya existe una seccion con ese codigo.");
            }

            S = new Secciones()
            {
                Nombre = unaS.Nombre,
                CodigoSeccion = unaS.CodigoSeccion
            };

            new Validaciones().Validar(S);

            OEcontext.Secciones.Add(S);
            OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            OEcontext.Entry(unaS).State = System.Data.Entity.EntityState.Detached;

            throw ex;
        }
    }

    public static void ModificarSeccion(Secciones unaS)
    {
        try
        {
            Secciones S = OEcontext.Secciones.Where(s => s.CodigoSeccion == unaS.CodigoSeccion).FirstOrDefault();

            S.CodigoSeccion = unaS.CodigoSeccion;
            S.Nombre = unaS.Nombre;

            OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            OEcontext.Entry(unaS).State = System.Data.Entity.EntityState.Detached;

            throw ex;
        }
    }

    public static void EliminarSeccion(Secciones unaS)
    {
        try
        {
            SqlParameter _codigo = new SqlParameter("@CodigoSeccion", unaS.CodigoSeccion);
            SqlParameter _retorno = new SqlParameter("@ret", System.Data.SqlDbType.Int);

            _retorno.Direction = System.Data.ParameterDirection.Output;

            OEcontext.Database.ExecuteSqlCommand("exec EliminarPeriodista @Cedula, @ret output", _codigo, _retorno);

            if ((int)_retorno.Value == -1)
                throw new Exception("La sección ingresada no existe");
            if ((int)_retorno.Value == -2)
                throw new Exception("Hubo un error y no se pudo eliminar la seccion de la base de datos");
            else
                OEcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}