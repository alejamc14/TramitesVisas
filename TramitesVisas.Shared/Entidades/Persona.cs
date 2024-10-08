﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TramitesVisas.Shared.Entidades
{
    public class Persona
    {
        public int Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "No se perimten mas de 20 digitos")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 caracteres")]
       // [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 caracteres")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellido { get; set; }


        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
       // [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Nacionalidad")]
        [MaxLength(40, ErrorMessage = "No se perimten mas de 40 caracteres")]
       // [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nacionalidad { get; set; }

        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "No se perimten mas de 50 caracteres")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "Digite un email valido")]
        public string Email { get; set; }


        [Display(Name = "Telefono")]
        //[Required(ErrorMessage = "El campo {6} es obligatorio")]
        public int Telefono { get; set; }

        public string NombreCompleto => $"{Nombre}{Apellido}";



    }
}
