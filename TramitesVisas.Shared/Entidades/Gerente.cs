using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Gerente
    {
        public int Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {5} es obligatorio")]
        [EmailAddress(ErrorMessage = "Digite un email valido")]
        public string Email { get; set; }

        

       
    }
}
