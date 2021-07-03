using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
   public class DtoZona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public List<DtoVertice> colVertices { get; set; }

    }
}
