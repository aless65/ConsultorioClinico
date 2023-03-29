using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class FacturasYDetallesViewModel
    {
        [Display(Name = "Factura")]
        public int fact_Id { get; set; }

        [Display(Name = "Fecha y Hora")]
        public DateTime fact_Fecha { get; set; }

        [Display(Name = "Paciente")]
        public int paci_Id { get; set; }

        [Display(Name = "Empleado")]
        public int empe_Id { get; set; }

        [Display(Name = "Método de Pago")]
        public int meto_Id { get; set; }

        [Display(Name = "Usuario Creación")]
        public int fact_UsuCreacion { get; set; }
        public DateTime fact_FechaCreacion { get; set; }
        public int? fact_UsuModificacion { get; set; }
        public DateTime? fact_FechaModificacion { get; set; }
        public bool fact_Estado { get; set; }

        [Display(Name = "ID")]
        public int? factdeta_Id { get; set; }

        [Display(Name = "Consulta")]
        public int? cons_Id { get; set; }

        [Display(Name = "Consulta")]
        public int? cons_Nombre { get; set; }

        [Display(Name = "Costo")]
        public decimal cons_Costo { get; set; }
        public int? factdeta_UsuCreacion { get; set; }
        public DateTime? factdeta_FechaCreacion { get; set; }
    }
}
