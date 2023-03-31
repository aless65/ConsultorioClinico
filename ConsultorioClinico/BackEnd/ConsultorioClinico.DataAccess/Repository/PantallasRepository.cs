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
    public class PantallasRepository : IRepository<tbPantallas>
    {
        public RequestStatus Delete(tbPantallas id, int Mod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPantallas> findPant(int? id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", id, DbType.String, ParameterDirection.Input);

            return db.Query<tbPantallas>(ScriptsDataBase.UDP_Encontrar_Pantallas, parametros, commandType: CommandType.StoredProcedure);
        }

        public tbPantallas find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPantallas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPantallas> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<tbPantallas>(ScriptsDataBase.UDP_Listar_Pantallas, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbPantallas> PantallasMenu(int role_Id, bool esAdmin)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", role_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@esAdmin", esAdmin, DbType.Boolean, ParameterDirection.Input);

            return db.Query<tbPantallas>(ScriptsDataBase.UDP_PantallasMenu, parametros, commandType: CommandType.StoredProcedure);

        }

        public RequestStatus Update(tbPantallas item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
