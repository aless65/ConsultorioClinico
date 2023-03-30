using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsultorioClinico.Entities.Entities;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Consultorio.DataAccess.Repository
{
    public class UsuarioRepository : IRepository<VW_tbUsuarios_View>
    {
        public RequestStatus Delete(VW_tbUsuarios_View id, int Mod)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            RequestStatus result = new RequestStatus();
            var parametros = new DynamicParameters();
            parametros.Add("@user_Id", id, DbType.Int32, ParameterDirection.Input);
            var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Eliminar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
            result.MessageStatus = answer;
            return result;
        }

        public VW_tbUsuarios_View find(int? id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@user_Id", id, DbType.Int32, ParameterDirection.Input);
            return db.QueryFirst<VW_tbUsuarios_View>(ScriptsDataBase.UDP_Encontrar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Insert(VW_tbUsuarios_View item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            RequestStatus result = new RequestStatus();
            var parametros = new DynamicParameters();
            parametros.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_EsAdmin", item.user_EsAdmin, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);
            var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Insertar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
            result.MessageStatus = answer;
            return result;
        }

        public IEnumerable<VW_tbUsuarios_View> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbUsuarios_View>(ScriptsDataBase.UDP_Listar_Usuarios, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbUsuarios_View item, int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            RequestStatus result = new RequestStatus();
            var parametros = new DynamicParameters();
            parametros.Add("@user_Id", item.user_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_EsAdmin", item.user_EsAdmin, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);
            var answer = db.QueryFirst<string>(ScriptsDataBase.UDP_Editar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
            result.MessageStatus = answer;
            return result;
        }

        public IEnumerable<VW_tbUsuarios_View> Login(string user, string contrasena)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usua_Usuario", user, DbType.String, ParameterDirection.Input);
            parametros.Add("@usua_Clave", contrasena, DbType.String, ParameterDirection.Input);
            return db.Query<VW_tbUsuarios_View>(ScriptsDataBase.UDP_Login, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
