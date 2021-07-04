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
   public class DtoZona
    {
        public int id { get; set; }
        [StringLength(30, ErrorMessage = "El Nombre de la zona no puede superar los 30 caracteres")]
        [Required(ErrorMessage = "El Nombre de la Zona es requerido")]
        [DisplayName("Nombre")]
        [Remote("ValidateNombre", "Zona", ErrorMessage = "El Nombre de la zona ya existe")]
        public string nombre { get; set; }
        [DisplayName("Color")]
        public string color { get; set; }
        public List<DtoVertice> colVertices { get; set; }

    }
}
