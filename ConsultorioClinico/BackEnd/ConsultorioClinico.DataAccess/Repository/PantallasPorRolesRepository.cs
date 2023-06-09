﻿using ConsultorioClinico.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess.Repository
{
    public class PantallasPorRolesRepository : IRepository<tbPantallasPorRoles>
    {
        public RequestStatus Delete(tbPantallasPorRoles id, int Mod)
        {
            throw new NotImplementedException();
        }

        public tbPantallasPorRoles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(tbPantallasPorRoles item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            if (item.role_Id == 0)
            {
                var parametros = new DynamicParameters();
                parametros.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
                parametros.Add("@pant_Id", item.pant_Id, DbType.Int32, ParameterDirection.Input);

                var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Eliminar_PantallasRoles, parametros, commandType: CommandType.StoredProcedure);

                result.MessageStatus = answer;

                return result;
            }
            else
            {
                var parametros = new DynamicParameters();
                parametros.Add("@role_Id", item.role_Id, DbType.String, ParameterDirection.Input);
                parametros.Add("@pant_Id", item.pant_Id, DbType.Int32, ParameterDirection.Input);

                var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Eliminar_PantallasRolesEditar, parametros, commandType: CommandType.StoredProcedure);

                result.MessageStatus = answer;

                return result;
            }
        }

        public RequestStatus Insert(tbPantallasPorRoles item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            if (item.role_Id == 0)
            {
                var parametros = new DynamicParameters();
                parametros.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
                parametros.Add("@pant_Id", item.pant_Id, DbType.Int32, ParameterDirection.Input);
                parametros.Add("@pantrole_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

                var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Insertar_PantallasRoles, parametros, commandType: CommandType.StoredProcedure);

                result.MessageStatus = answer;

                return result;
            }
            else
            {
                var parametros = new DynamicParameters();
                parametros.Add("@role_Id", item.role_Id, DbType.String, ParameterDirection.Input);
                parametros.Add("@pant_Id", item.pant_Id, DbType.Int32, ParameterDirection.Input);
                parametros.Add("@pantrole_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

                var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Insertar_PantallasRolesEditar, parametros, commandType: CommandType.StoredProcedure);

                result.MessageStatus = answer;

                return result;
            }
        }

        public IEnumerable<tbPantallasPorRoles> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbPantallasPorRoles item, int id)
        {
            throw new NotImplementedException();
        }

        public int Permisos(int role_Id, int pant_Id, bool esAdmin)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", role_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@pant_Id", pant_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_esAdmin", esAdmin, DbType.Boolean, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Permisos, parametros, commandType: CommandType.StoredProcedure);
        }

    }
}
