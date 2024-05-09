using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Solicitud
    {
        public int Id { get; set; }


        [Display(Name = "Estado Renovacion")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaAgenda { get; set; }

        public Persona Personas { get; set; }
        public int IdPersona { get; set; }

        public ICollection<Documento> Documentos { get; set; }

        public ICollection<Historial> historiales { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
