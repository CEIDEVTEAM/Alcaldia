//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reclamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reclamo()
        {
            this.LogReclamo = new HashSet<LogReclamo>();
        }
    
        public int id { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fechaYhora { get; set; }
        public string observaciones { get; set; }
        public string idCiudadano { get; set; }
        public string nombreTipoReclamo { get; set; }
        public Nullable<int> idCuadrilla { get; set; }
        public string LatitudReclamo { get; set; }
        public string LongitudReclamo { get; set; }
    
        public virtual Cuadrilla Cuadrilla { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogReclamo> LogReclamo { get; set; }
        public virtual Tipo_De_Reclamo Tipo_De_Reclamo { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
