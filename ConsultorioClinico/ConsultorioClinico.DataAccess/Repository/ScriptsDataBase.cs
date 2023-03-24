﻿using System;
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
        #endregion
        #region Cargos
        public static string UDP_Listar_Cargos = "cons.UDP_tbCargos_List";
        public static string UDP_Insertar_Cargos = "cons.UDP_tbCargos_Insert";
        #endregion
    }
}
