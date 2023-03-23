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
        public class RequestStatus
        {
            public int CodeStatus { get; set; }
            public string MessageStatus { get; set; }
        }
        public RequestStatus Delete(VW_tbDepartamentos id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbDepartamentos> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbDepartamentos>(ScriptsDataBase.UDP_Listar_Departamentos, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbDepartamentos item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
