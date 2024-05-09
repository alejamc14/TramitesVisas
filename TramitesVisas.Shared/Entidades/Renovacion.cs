using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Renovacion
    {
        public int Id { get; set; } 

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaRenovacion { get; set; }

        [Display(Name = "Costo de Renovacion ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad requerida debe ser mayor que 0")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double Costo { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Descripcion { get; set; }


        //relaciones: 
        public Solicitud Solicitudes { get; set; }
        public int IdSolicitud { get; set; }



    }
}
