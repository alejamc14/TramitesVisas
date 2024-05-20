using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Solicitud
    {
        public int Id { get; set; }


        [Display(Name = "Tipo solicitud")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoSolicitud { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaAgenda { get; set; }


        //  recibe el FK de persona
        [JsonIgnore]
        public Persona Personas { get; set; }
        public int PersonaId { get; set; }
        [JsonIgnore]
        public TipoVisa TipoVisas { get; set; }
        public int TipoVisaId { get; set; }

        //Relaciones: una solicitud puede tener Muchas documentos , Historiales ..
        //Los ICollection mandan la foranea
        [JsonIgnore]
        public ICollection<Documento> Documentos { get; set; }
        [JsonIgnore]
        public ICollection<Renovacion> Renovaciones { get; set; }
        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; }
        [JsonIgnore]
        public ICollection<Pago> Pagos { get; set; }

      
    }
}
