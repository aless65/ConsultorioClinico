using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Models
{
    public class UsuariosViewModel
    {
        [Display(Name = "Id")]
        public int user_Id { get; set; }
        [Display(Name = "Nombre")]
        public string user_NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        public string user_Contrasena { get; set; }
        [Display(Name = "EsAdmin")]
        public bool? user_EsAdmin { get; set; }
        [Display(Name = "Id Rol")]
        public int role_Id { get; set; }
        [Display(Name = "Rol")]
        public string role_Nombre { get; set; }
        [Display(Name = "Id empleado")]
        public int empe_Id { get; set; }
        [Display(Name = "Empleado")]
        public string empe_NombreCompleto { get; set; }
        [Display(Name = "Usuario Creación")]
        public int? user_UsuCreacion { get; set; }
        [Display(Name = "Nombre Usuario")]
        public string user_UsuCreacion_Nombre { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime user_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificación")]
        public int? user_UsuModificacion { get; set; }
        [Display(Name = "Usuario")]
        public string user_UsuModificacion_Nombre { get; set; }
        [Display(Name = "Fecha Modificación")]
        public DateTime? user_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool user_Estado { get; set; }
    }
}
