using CommonSolution.ENUMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoReclamo
    {
        public int id { get; set; }
        public EnumEstado estado { get; set; }
        public Nullable<System.DateTime> fechaYhora { get; set; }
        public string observaciones { get; set; }
        public string idCiudadano { get; set; }
        public string nombreTipoReclamo { get; set; }
        public Nullable<decimal> LatitudReclamo { get; set; }
        public Nullable<decimal> LongitudReclamo { get; set; }
        public Nullable<int> idCuadrilla { get; set; }
    }
}
