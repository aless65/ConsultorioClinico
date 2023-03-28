using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class CargoViewModel 
    {
        [Display(Name = "ID")]
        public int carg_Id { get; set; }

        [Display(Name = "Nombre")]
        public string carg_Nombre { get; set; }
        public int carg_UsuCreacion { get; set; }

        [Display(Name = "Usuario creación")]
        public string carg_UsuCreacionNombre { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime carg_FechaCreacion { get; set; }
        public int? carg_UsuModificacion { get; set; }

        [Display(Name = "Usuario modificación")]
        public string carg_UsuModificacionNombre { get; set; }

        [Display(Name = "Fecha modificación")]
        public DateTime? carg_FechaModificacion { get; set; }
        public bool carg_Estado { get; set; }

        //public virtual tbUsuarios carg_UsuCreacionNavigation { get; set; }
        //public virtual tbUsuarios carg_UsuModificacionNavigation { get; set; }
        //public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
    }
}
