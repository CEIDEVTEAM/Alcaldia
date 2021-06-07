using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
   public class DtoUsuario
    {
        public string nombreDeUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contrasenia { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DtoTipoUsuario tipoDeUsuario { get; set; }
    }
}
