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
    public class DepartamentosRepository : IRepository<VW_tbDepartamentos>
    {
        public RequestStatus Delete(VW_tbDepartamentos id, int Mod) 
        {
            //using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            //var parametros = new DynamicParameters();
            //parametros.Add("@depa", item.depa_Id, DbType.String, ParameterDirection.Input);

            //return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Insertar_Departamentos, parametros, commandType: CommandType.StoredProcedure);
            throw new NotImplementedException();
        }

        public VW_tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbDepartamentos item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@depa_Id", item.depa_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_Nombre", item.depa_Nombre, DbType.String, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Insertar_Departamentos, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbDepartamentos> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbDepartamentos>(ScriptsDataBase.UDP_Listar_Departamentos, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbDepartamentos item, int id)
        {
            //using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            //var parametros = new DynamicParameters();
            //parametros.Add("@depa_Id", item.depa_Id, DbType.Int32, ParameterDirection.Input);
            //parametros.Add("@depa_Nombre", item.depa_Nombre, DbType.String, ParameterDirection.Input);
            //parametros.Add("@depa_UsuModificacion", item.depa_UsuModificacion, DbType.Int32, ParameterDirection.Input);
            //return db.QueryFirst<VW_tbDepartamentos>(ScriptsDataBase., null, commandType: CommandType.StoredProcedure);
            throw new NotImplementedException();
        }
    }
}
