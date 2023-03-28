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
    public class MetodosRepository : IRepository<VW_tbMetodosPago>
    {
        public RequestStatus Delete(VW_tbMetodosPago id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbMetodosPago find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbMetodosPago item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbMetodosPago> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            return db.Query<VW_tbMetodosPago>(ScriptsDataBase.UDP_Listar_Metodos, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbMetodosPago item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
