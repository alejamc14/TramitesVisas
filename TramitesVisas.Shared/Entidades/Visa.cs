using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Visa
    {
        public int Id { get; set; }


        [Display(Name = "Tipo")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Tipo { get; set;}


        [Display(Name = "Costo de la Visa ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad requerida debe ser mayor que 0")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double Costo { get; set; }


        [Display(Name = "Requisitos")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Requisitos { get; set; }

        public ICollection<Solicitud> Solicitudes { get; set; }





    }
}
