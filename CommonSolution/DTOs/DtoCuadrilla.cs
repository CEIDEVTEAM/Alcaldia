using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
   public class DtoCuadrilla
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string encargado { get; set; }
        public Nullable<int> idZona { get; set; }
        public int cantidadDePeones { get; set; }
    }
}
