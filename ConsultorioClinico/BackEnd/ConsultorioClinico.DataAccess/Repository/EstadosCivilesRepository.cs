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
    public class EstadosCivilesRepository : IRepository<tbEstadosCiviles>
    {
        public RequestStatus Delete(tbEstadosCiviles id, int Mod)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<tbEstadosCiviles>(ScriptsDataBase.UDP_Listar_EstadosCiviles, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbEstadosCiviles item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
