using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Historial
    {
        public int Id { get; set; }

        [Display(Name = "Tipo solicitud")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoSolicitud { get; set; }

        [Display(Name = "Tipo solicitud")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Estado { get; set; }


        [JsonIgnore]
        //public Visa Visas { get; set; }
        //public int VisaId { get; set; }

        public Renovacion Renovaciones { get; set; }
        public int RenovacionId { get; set; }

    }
}
