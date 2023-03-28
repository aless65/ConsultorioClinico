using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class FacturaViewModel
    {
        [Display(Name = "ID")]
        public int fact_Id { get; set; }

        [Display(Name = "Fecha y hora")]
        public DateTime fact_Fecha { get; set; }

        [Display(Name = "Paciente")]
        public int paci_Id { get; set; }

        [Display(Name = "Paciente")]
        public string paci_NombreCompleto { get; set; }

        [Display(Name = "Empleado")]
        public int empe_Id { get; set; }

        [Display(Name = "Empleado")]
        public string empe_NombreCompleto { get; set; }

        [Display(Name = "Método de Pago")]
        public int meto_Id { get; set; }

        [Display(Name = "Método de Pago")]
        public string meto_Nombre { get; set; }

        [Display(Name = "Usuario Creación")]
        public int fact_UsuCreacion { get; set; }

        [Display(Name = "Usuario Creación")]
        public string fact_UsuCreacionNombre { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime fact_FechaCreacion { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string fact_UsuModificacionNombre { get; set; }

        [Display(Name = "Usuario Modificación")]
        public int? fact_UsuModificacion { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? fact_FechaModificacion { get; set; }
        public bool fact_Estado { get; set; }
    }
}
