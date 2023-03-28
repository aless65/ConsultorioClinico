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
    public class ClinicasRepository : IRepository<tbClinicas>
    {
        public RequestStatus Delete(tbClinicas id, int Mod)
        {
            throw new NotImplementedException();
        }

        public tbClinicas find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbClinicas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbClinicas> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<tbClinicas>(ScriptsDataBase.UDP_Listar_Clinicas, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbClinicas item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
