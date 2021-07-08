using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommonSolution.DTOs
{
    public class DtoChangePass
    {
        [DisplayName("Nombre de usuario")]
        public string user { get; set; }

        [Remote("ValidateCredentials", "Login", AdditionalFields = "user", ErrorMessage = "Contraseña incorrecta")]
        [Required(ErrorMessage = "Debe Ingresar la contraseña actual")]
        [DisplayName("Contraseña actual")]
        [DataType(DataType.Password)]
        public string pass {get; set;}

        [Required(ErrorMessage = "Debe Ingresar la nueva contraseña")]
        [DisplayName("Nueva contraseña")]
        [DataType(DataType.Password)]
        public string newPass { get; set; }

        [Remote("ValidateNewPassword", "UsuarioCommon", AdditionalFields = "newPass", ErrorMessage = "Las contraseñas no coinciden")]
        [Required(ErrorMessage = "Repita la nueva contraseña")]
        [DisplayName("Repita nueva contraseña")]
        [DataType(DataType.Password)]
        public string repNewPass { get; set; }

    }
}
