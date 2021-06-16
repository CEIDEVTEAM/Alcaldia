using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
   public class DtoUbicacion
    {
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
        public Nullable<int> idZona { get; set; }
    }
}
