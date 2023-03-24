using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Models
{
    public class CargoViewModel
    {
        [Display(Name = "Id")]
        public int carg_Id { get; set; }
        [Display(Name = "Nombre")]
        public string carg_Nombre { get; set; }
        [Display(Name = "Usuario Creación")]
        public int carg_UsuCreacion { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime carg_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificación")]
        public int? carg_UsuModificacion { get; set; }
        [Display(Name = "Fecha Modificación")]
        public DateTime? carg_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? carg_Estado { get; set; }
    }
}
