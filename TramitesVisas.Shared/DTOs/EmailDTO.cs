using System.ComponentModel.DataAnnotations;

namespace TramitesVisas.Shared.DTOs
{
    public class EmailDto
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un Email valido.")]
        public string Email { get; set; } = null!;
    }
}
