using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
   public class DtoUsuario
    {
        [DisplayName("Nombre de usuario")]
        public string nombreDeUsuario { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        public string apellido { get; set; }

        [DisplayName("Contraseña")]
        public string contrasenia { get; set; }

        [DisplayName("Telefono")]
        public string telefono { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Email")]
        public string situacion { get; set; }

        public DtoTipoUsuario tipoDeUsuario { get; set; }
    }
}
