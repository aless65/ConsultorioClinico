using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class ConsultaViewModel
    {
        [Display(Name = "Id")]
        public int cons_Id { get; set; }
        [Display(Name = "Inicio Consulta")]
        public DateTime cons_Inicio { get; set; }
        [Display(Name = "Fin Consulta")]
        public DateTime cons_Final { get; set; }
        [Display(Name = "Id Paciente")]
        public int paci_Id { get; set; }
        [Display(Name = "Id Consultorio")]
        public int consltro_Id { get; set; }
        [Display(Name = "Costo Consulta")]
        public decimal? cons_Costo { get; set; }
        [Display(Name = "Usuario Creación")]
        public int cons_UsuCreacion { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime cons_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificación")]
        public int? cons_UsuModificacion { get; set; }
        [Display(Name = "Fecha Modificación")]
        public DateTime? cons_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? cons_Estado { get; set; }
    }
}
