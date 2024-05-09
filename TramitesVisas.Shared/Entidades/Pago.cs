using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Pago
    {
        public int Id { get; set; }

        [Display(Name = "Costo de la Visa ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad requerida debe ser mayor que 0")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double Valor { get; set; }


        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string MetodoPago { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaPago { get; set; }

        public Solicitud Solicitudes { get; set; }
        public int IdSolicitud { get; set; }

    }
}
