using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Models
{
    public class UsuarioViewModel
    {
        //[Display(Name = "Id")]
        //public int user_Id { get; set; }
        //[Display(Name = "Usuario")]
        //public string user_NombreUsuario { get; set; }
        //[Display(Name = "Contraseña")]
        //public string user_Contrasena { get; set; }
        //[Display(Name = "EsAdmin")]
        //public bool? user_EsAdmin { get; set; }
        //[Display(Name = "Rol Id")]
        //public int? role_Id { get; set; }
        //[Display(Name = "Empleado Id")]
        //public int? empe_Id { get; set; }
        //[Display(Name = "Usuario Creación")]
        //public int? user_UsuCreacion { get; set; }
        //[Display(Name = "Fecha Creación")]
        //public DateTime user_FechaCreacion { get; set; }
        //[Display(Name = "Usuario Modificación")]
        //public int? user_UsuModificacion { get; set; }
        //[Display(Name = "Fecha Modificacion")]
        //public DateTime? user_FechaModificacion { get; set; }
        //[Display(Name = "Estado")]
        //public bool? user_Estado { get; set; }

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
