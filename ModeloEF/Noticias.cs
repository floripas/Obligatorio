//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModeloEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Noticias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Noticias()
        {
            this.Periodistas = new HashSet<Periodistas>();
        }
    
        public string Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string CodigoSeccion { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public int Importancia { get; set; }
        public System.DateTime FechaPublicacion { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Secciones Secciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual HashSet<Periodistas> Periodistas { get; set; }
    }
}
