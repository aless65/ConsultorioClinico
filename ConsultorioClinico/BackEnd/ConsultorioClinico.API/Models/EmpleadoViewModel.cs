using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Models
{
    public class EmpleadoViewModel
    {
        public int empe_Id { get; set; }
        public string empe_Nombres { get; set; }
        public string empe_Apellido { get; set; }
        public string empe_Identidad { get; set; }
        public string empe_Sexo { get; set; }
        public int estacivi_Id { get; set; }
        public DateTime empe_FechaNacimiento { get; set; }
        public string muni_Id { get; set; }
        public string empe_Direccion { get; set; }
        public string empe_Telefono { get; set; }
        public string empe_Correo { get; set; }
        public DateTime empe_FechaInicio { get; set; }
        public DateTime? empe_FechaFinal { get; set; }
        public int carg_Id { get; set; }
        public int clin_Id { get; set; }
        public int empe_UsuCreacion { get; set; }
        public DateTime empe_FechaCreacion { get; set; }
        public int? empe_UsuModificacion { get; set; }
        public DateTime? empe_FechaModificacion { get; set; }
        public bool? empe_Estado { get; set; }
    }
}
