using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.Shared.DTOs
{
    public class UserDTO: User 
    {


        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Nacionalidad")]
        [MaxLength(40, ErrorMessage = "No se perimten mas de 40 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nacionalidad { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo {6} es obligatorio")]
        public int Telefono { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Password and confirmation are not the same")]
        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string PasswordConfirm { get; set; } = null!;

    }
}
