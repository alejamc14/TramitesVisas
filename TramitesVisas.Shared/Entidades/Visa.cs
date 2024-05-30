using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
   public class Visa
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaSolicitud { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(100, ErrorMessage = "No se perimten mas de 100 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Comentario { get; set; }


        //  recibe el FK de persona
        [JsonIgnore]
        public Persona Personas { get; set; }
        public int PersonaId { get; set; }


        [JsonIgnore]
        public TipoVisa TipoVisas { get; set; }
        public int TipoVisaId { get; set; }
    }
}
