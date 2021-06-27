using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoLogin
    {
        [Required(ErrorMessage = "El Usuario es requerido")]
        [DisplayName("Usuario")]
        public string user { get; set; }

        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string pass { get; set; }

        public string tipoDeUsuario;
    }
}
