using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Models
{
    public class PantallaPorRolViewModel
    {
        public int pantrole_Id { get; set; }
        public int role_Id { get; set; }
        [NotMapped]
        public string role_Nombre { get; set; }
        public int pant_Id { get; set; }
        public int pantrole_UsuCreacion { get; set; }
        public DateTime pantrole_FechaCreacion { get; set; }
        public int? pantrole_UsuModificacion { get; set; }
        public DateTime? pantrole_FechaModificacion { get; set; }
        public bool? pantrole_Estado { get; set; }
    }
}
