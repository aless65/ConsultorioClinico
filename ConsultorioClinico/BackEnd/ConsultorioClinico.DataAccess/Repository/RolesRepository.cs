using ConsultorioClinico.Entities.Entities;
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
    public class RolesRepository : IRepository<VW_tbRoles>
    {
        public RequestStatus Delete(VW_tbRoles id, int Mod)
        {
            throw new NotImplementedException();
        }
        public RequestStatus DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", id, DbType.Int32, ParameterDirection.Input);

            var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Eliminar_Roles, parametros, commandType: CommandType.StoredProcedure);

            result.MessageStatus = answer;

            return result;
        }

        public VW_tbRoles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbRoles item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            var parametros = new DynamicParameters();
            parametros.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@role_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Insertar_Roles, parametros, commandType: CommandType.StoredProcedure);

            result.MessageStatus = answer;

            return result;
        }

        public IEnumerable<VW_tbRoles> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            return db.Query<VW_tbRoles>(ScriptsDataBase.UDP_Listar_Roles, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbRoles item, int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@role_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Editar_Roles, parametros, commandType: CommandType.StoredProcedure);

            result.MessageStatus = answer;

            return result;
        }
    }
}
