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
   public class DtoTipoDeReclamo
    {

        [Remote("ValidateNombre", "TipoDeReclamo", ErrorMessage = "El Nombre ingresado ya existe")]
        [StringLength(50, ErrorMessage = "El Nombre no puede superar los 50 caracteres")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [StringLength(140, ErrorMessage = "La Descripción no puede superar los 140 caracteres")]
        [Required(ErrorMessage = "La Descripción es requerida")]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
    }
}
