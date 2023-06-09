﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ConsultorioClinico.Entities.Entities
{
    public partial class VW_tbEmpleados
    {
        [Display(Name = "ID")]
        public int empe_Id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Apellido { get; set; }
        public string empe_NombreCompleto { get; set; }

        [Display(Name = "Identidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Identidad { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Sexo { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int estacivi_Id { get; set; }

        [Display(Name = "Estado Civil")]
        public string estacivi_Nombre { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime empe_FechaNacimiento { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string muni_Id { get; set; }
        public string muni_Nombre { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string depa_Id { get; set; }

        [Display(Name = "Dirección exacta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string empe_Correo { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime empe_FechaInicio { get; set; }

        [Display(Name = "Fecha Final")]
        public DateTime? empe_FechaFinal { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int carg_Id { get; set; }

        [Display(Name = "Cargo")]
        public string carg_Nombre { get; set; }

        [Display(Name = "Clínica")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int clin_Id { get; set; }
        public string clin_Nombre { get; set; }
        public int empe_UsuCreacion { get; set; }
        public string empe_UsuCreacionNombre { get; set; }
        public int? empe_UsuModificacion { get; set; }
        public string empe_usuModificacionNombre { get; set; }
        public bool empe_Estado { get; set; }
        public DateTime empe_FechaCreacion { get; set; }
        public DateTime? empe_FechaModificacion { get; set; }
    }
}