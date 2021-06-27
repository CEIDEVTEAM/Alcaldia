using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
   public class DtoCuadrilla
    {
        [DisplayName("Nro")]
        public int id { get; set; }

        [StringLength(30, ErrorMessage = "El Nombre no puede superar los 30 caracteres")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [StringLength(50, ErrorMessage = "El Encargado no puede superar los 50 caracteres")]
        [Required(ErrorMessage = "El Encargado es requerido")]
        [DisplayName("Encargado")]
        public string encargado { get; set; }

        [DisplayName("Nro de Zona")]
        public Nullable<int> idZona { get; set; }


        [Required(ErrorMessage = "La Cant. de Peones es requerida")]
        [DisplayName("Cant. de Peones")]
        public int cantidadDePeones { get; set; }
    }
}
