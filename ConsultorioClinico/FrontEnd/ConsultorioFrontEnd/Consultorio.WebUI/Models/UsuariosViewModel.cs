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
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string user_NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string user_Contrasena { get; set; }
        [Display(Name = "EsAdmin")]
        public bool? user_EsAdmin { get; set; }
        [Display(Name = "Rol Id")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int? role_Id { get; set; }
        [Display(Name = "Empleado Id")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int? empe_Id { get; set; }
        [Display(Name = "Usuario Creación")]
        public int? user_UsuCreacion { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime user_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificación")]
        public int? user_UsuModificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? user_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? user_Estado { get; set; }
    }
}
