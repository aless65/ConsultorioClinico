using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Models
{
    public class DepartamentoViewModel
    {
        [Display(Name = "ID")]
        public string depa_Id { get; set; }
        [Display(Name = "Nombre")]
        public string depa_Nombre { get; set; }
        [Display(Name = "Usuario Creación")]
        public int depa_UsuCreacion { get; set; }
        [Display(Name = "Fecha Crecación")]
        public DateTime depa_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificación")]
        public int? depa_UsuModificacion { get; set; }
        [Display(Name = "Fecha Modificación")]
        public DateTime? depa_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? depa_Estado { get; set; }
    }
}
