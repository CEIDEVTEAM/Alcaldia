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
    public class DtoUsuario
    {

        [Remote("ValidateUserName", "UsuarioCommon", AdditionalFields = "task", ErrorMessage = "El nombre de usuario ya existe")]
        [StringLength(20, ErrorMessage = "El Nombre de usuario no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El Nombre de usuario es requerido")]
        [DisplayName("Nombre de usuario")]
        public string nombreDeUsuario { get; set; }

        [StringLength(30, ErrorMessage = "El Nombre no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [StringLength(30, ErrorMessage = "El Apellido no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        [DisplayName("Apellido")]
        public string apellido { get; set; }

        [StringLength(30, ErrorMessage = "La contraseña no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string contrasenia { get; set; }

        [Remote("ValidatePasswordNewUser", "UsuarioCommon", AdditionalFields = "contrasenia", ErrorMessage = "Las contraseñas no coinciden")]
        [Required(ErrorMessage = "Repita la contraseña")]
        [DataType(DataType.Password)]
        [DisplayName("Repita contraseña")]

        public string repContrasenia { get; set; }


        [StringLength(20, ErrorMessage = "La telefono no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "El telefono a es requerido")]
        [DisplayName("Telefono")]
        public string telefono { get; set; } 

        [StringLength(50, ErrorMessage = "El email no puede superar los 50 caracteres")]
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress]
        [DisplayName("Email")]
        public string email { get; set; }

        public string situacion { get; set; }
        public string task { get; set; }

        public DtoTipoUsuario tipoDeUsuario { get; set; }

        public DtoChangePass changePass { get; set; }
    }
}
