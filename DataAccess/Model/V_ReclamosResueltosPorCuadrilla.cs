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
    
    public partial class V_ReclamosResueltosPorCuadrilla
    {
        public int idCuadrilla { get; set; }
        public string nombre { get; set; }
        public string encargado { get; set; }
        public Nullable<int> idZona { get; set; }
        public int cantidadDePeones { get; set; }
        public string situacion { get; set; }
        public Nullable<int> resueltos { get; set; }
        public Nullable<int> totalMin { get; set; }
    }
}
