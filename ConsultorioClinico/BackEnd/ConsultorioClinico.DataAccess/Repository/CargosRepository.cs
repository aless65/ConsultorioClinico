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
    public class CargosRepository : IRepository<VW_tbCargos>
    {
        public RequestStatus Delete(VW_tbCargos id, int Mod)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@carg_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Eliminar_Cargos, parametros, commandType: CommandType.StoredProcedure);
        }

        public VW_tbCargos find(int? id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@carg_Id", id, DbType.Int32, ParameterDirection.Input);
 
            return db.QueryFirst<VW_tbCargos>(ScriptsDataBase.UDP_Encontrar_Cargos, parametros, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Insert(VW_tbCargos item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@carg_Nombre", item.carg_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@carg_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Insertar_Cargos, parametros, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<VW_tbCargos> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbCargos>(ScriptsDataBase.UDP_Listar_Cargos, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbCargos item, int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@carg_Id", item.carg_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@carg_Nombre", item.carg_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@carg_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Editar_Cargos, parametros, commandType: CommandType.StoredProcedure);
        }

        
        
    }
}
