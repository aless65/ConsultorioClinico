using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class ConsultasReportesViewModel
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public string Paciente { get; set; }
        public string Médico { get; set; }
        public decimal? Costo { get; set; }
    }
}
