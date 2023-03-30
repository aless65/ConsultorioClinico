using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class UsuariosViewModel
    {
        public int user_Id { get; set; }
        public string user_NombreUsuario { get; set; }
        public string user_Contrasena { get; set; }
        public bool? user_EsAdmin { get; set; }
        public int? role_Id { get; set; }
        public string role_Nombre { get; set; }
        public int? empe_Id { get; set; }
        public string empe_NombreCompleto { get; set; }
        public int? user_UsuCreacion { get; set; }
        public string user_UsuCreacion_Nombre { get; set; }
        public DateTime user_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public string user_UsuModificacion_Nombre { get; set; }
        public DateTime? user_FechaModificacion { get; set; }
        public bool user_Estado { get; set; }
    }
}
