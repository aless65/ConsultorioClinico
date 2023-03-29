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
    public class MedicamentosRepository : IRepository<VW_tbMedicamentos>
    {
        public RequestStatus Delete(VW_tbMedicamentos id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbMedicamentos find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbMedicamentos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbMedicamentos> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            return db.Query<VW_tbMedicamentos>(ScriptsDataBase.UDP_Listar_Medicamentos, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbMedicamentos item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
