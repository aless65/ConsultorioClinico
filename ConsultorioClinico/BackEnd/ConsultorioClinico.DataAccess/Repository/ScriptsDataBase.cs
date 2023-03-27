using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess.Repository
{
    public class ScriptsDataBase
    {
        #region Departamentos
        public static string UDP_Listar_Departamentos = "gral.UDP_tbDepartamentos_Listado";
        public static string UDP_Insertar_Departamentos = "gral.UDP_tbDepartamentos_Insert";
        public static string UDP_Listar_Municipios = "gral.UDP_tbMunicipios_ListadoDepa";
        #endregion
        #region Cargos
        public static string UDP_Listar_Cargos = "cons.UDP_tbCargos_List";
        public static string UDP_Insertar_Cargos = "cons.UDP_tbCargos_Insert";
        public static string UDP_Editar_Cargos = "cons.UDP_tbCargos_Update";
        public static string UDP_Eliminar_Cargos = "cons.UDP_tbCargos_Delete";
        public static string UDP_Encontrar_Cargos = "cons.UDP_tbCargos_Find";
        #endregion
        #region Empleados
        public static string UDP_Listar_Empleados = "cons.UDP_tbEmpleados_List";
        public static string UDP_Insertar_Empleados = "cons.UDP_tbEmpleados_Insert";
        public static string UDP_Editar_Empleados = "cons.UDP_tbEmpleados_Update";
        public static string UDP_Eliminar_Empleados = "cons.UDP_tbEmpleados_Delete";
        public static string UDP_Encontrar_Empleados = "cons.UDP_tbEmpleados_Find";
        #endregion
        #region Estados Civiles
        public static string UDP_Listar_EstadosCiviles = "gral.UDP_tbEstadosCiviles_List";
        #endregion
        #region
        public static string UDP_Listar_Clinicas = "cons.UDP_tbClinicas_List";
        #endregion
    }
}
