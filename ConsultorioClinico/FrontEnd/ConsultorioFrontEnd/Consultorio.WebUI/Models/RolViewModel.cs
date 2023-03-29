﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class RolViewModel
    {
        public int role_Id { get; set; }

        [Display(Name = "Nombre")]
        public string role_Nombre { get; set; }
        public int role_UsuCreacion { get; set; }
        public string role_UsuCreacionNombre { get; set; }
        public DateTime role_FechaCreacion { get; set; }
        public int? role_UsuModificacion { get; set; }
        public string role_UsuModificacionNombre { get; set; }
        public DateTime? role_FechaModificacion { get; set; }
    }
}
