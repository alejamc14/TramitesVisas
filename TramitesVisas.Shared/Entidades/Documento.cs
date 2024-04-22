using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Documento
    {
        public int Id { get; set; }


        [Display(Name = "Tipo")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Tipo { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaSubida { get; set; }

        [Display(Name = "Tipo")]
        [MaxLength(100, ErrorMessage = "No se perimten mas de 100 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string URL { get; set; }
    }
}
