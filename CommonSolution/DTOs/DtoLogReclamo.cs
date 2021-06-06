using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
  public  class DtoLogReclamo
    {
        public int idLog { get; set; }
        public string estadoLog { get; set; }
        public System.DateTime fechaYhoraLog { get; set; }
        public string observacionesCuadrilla { get; set; }
        public string comentarioLog { get; set; }
        public Nullable<int> idReclamo { get; set; }
        public string nombreDeUsuario { get; set; }
    }
}
