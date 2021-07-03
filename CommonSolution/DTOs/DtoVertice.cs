using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoVertice
    {
        public string latitud { get; set; }
        public string longitud { get; set; }
        public Nullable<int> idZona { get; set; }
        public int orden { get; set; }
    }
}
