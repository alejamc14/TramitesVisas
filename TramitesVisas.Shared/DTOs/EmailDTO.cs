﻿using System.ComponentModel.DataAnnotations;

namespace TramitesVisas.Shared.DTOs
{
    public class EmailDto
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [EmailAddress(ErrorMessage = "You must enter a valid email.")]
        public string Email { get; set; } = null!;
    }
}
