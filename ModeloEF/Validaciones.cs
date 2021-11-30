using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

using ModeloEF;

public class Validaciones
{
    public void Validar(Empleados E)
    {
        if (E.NombreUsuario.Trim().Length != 10)
        {
            throw new Exception("El nombre de usuario debe tener exactamente 10 caracteres de extensión.");
        }
        if (E.Contraseña.Trim().Length != 7)
        {
            throw new Exception("La contraseña del empleado debe tener 7 caracteres de extensión.");
        }
        if (!Regex.IsMatch(E.Contraseña.Trim(), @"^[a-z]{4}[0-9]{3}|[0-9]{3}[a-z]{4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
        {
            throw new Exception("La contraseña del empleado debe tener 7 caracteres(4 letras y 3 numeros) sin espacios.");
        }
    }

    public void Validar(Noticias N)
    {
        if (!Regex.IsMatch(N.Codigo.Trim(), @"^[a-z0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
        {
            throw new Exception("El código de la noticia debe contener letras y dígitos.");
        }
        if (N.Titulo.Trim().Length > 50)
        {
            throw new Exception("El título es muy largo; no debe exceder los 50 caracteres con espacios.");
        }
        if (N.Importancia <= 0 || N.Importancia > 5)
        {
            throw new Exception("La escala de la noticia solo puede ser un número entre el 1 y el 5 inclusive.");
        }
        if (DateTime.Compare(N.FechaPublicacion, DateTime.Today) > 0)
        {
            throw new Exception("No se puede agregar noticias con fechas futuras.");
        }
        if (N.Codigo.Trim().Length > 20)
        {
            throw new Exception("El codigo ingresado debe ser menor a 20 caracteres.");
        }
    }

    public void Validar(Secciones S)
    {
        if (S.CodigoSeccion.Trim().Length != 5)
        {
            throw new Exception("El código de la sección debe tener 5 caracteres de extensión.");
        }
        if (S.Nombre.Trim().Length > 20)
        {
            throw new Exception("El nombre ingresado debe ser menor a 20 caracteres.");
        }
    }

    public void Validar(Periodistas P)
    {
        if (!Regex.IsMatch(P.Email.Trim(), @"^[a-z0-9]+@[a-z0-9-]+\.[a-z0-9]{3}$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
        {
            throw new Exception("La dirección de correo no tiene un formato válido.");
        }
        if (P.Cedula.Trim().Length != 8)
        {
            throw new Exception("La cédula ingresada no tiene un formato válido.");
        }
        if (P.Nombre.Trim().Length > 20)
        {
            throw new Exception("El nombre ingresado debe ser menor a 20 caracteres.");
        }
        if (P.Email.Trim().Length > 20)
        {
            throw new Exception("El email ingresado debe ser menor a 20 caracteres.");
        }
        try
        {
            Convert.ToInt32(P.Cedula.Trim());
        }
        catch
        {
            throw new Exception("La cédula ingresada no tiene un formato válido. Solo debe contener dígitos.");
        }
    }
}