using CommonSolution.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoReclamo
    {
        [DisplayName("Nro")]
        public int id { get; set; }

        [DisplayName("Estado")]
        public EnumEstado estado { get; set; }

        [DisplayName("Fecha")]
        public Nullable<System.DateTime> fechaYhora { get; set; }

        [StringLength(140, ErrorMessage = "La descripción no puede superar los 140 caracteres")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [DisplayName("Descripción")]
        public string observaciones { get; set; }

        [DisplayName("Usuario Ciudadano")]
        public string idCiudadano { get; set; }

        [Required(ErrorMessage = "El tipo de reclamo es requerido")]
        [DisplayName("Tipo")]
        public string nombreTipoReclamo { get; set; }
        public string LatitudReclamo { get; set; }
        public string LongitudReclamo { get; set; }

        [DisplayName("Nro Cuadrilla")]
        public Nullable<int> idCuadrilla { get; set; }

        [DisplayName("Nro Zona")]
        public int idZona { get; set; }

        [DisplayName("Retraso")]
        public string tiempoDeRetraso { get; set; }
        public string color { get; set; }
    }
}
