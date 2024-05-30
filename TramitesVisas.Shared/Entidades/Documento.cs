using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Documento
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Documento")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoDocumento{ get; set; }

        [Display(Name = "Fecha de Subida")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd }", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaSubida { get; set; }

        [Display(Name = "URL")]
        [MaxLength(100, ErrorMessage = "No se perimten mas de 100 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string URL { get; set; }

        // esta relacion recibe la foranea
        [JsonIgnore]
        public Solicitud Solicitudes { get; set; }
        public int SolicitudId { get; set; }


    }

}
