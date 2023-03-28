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
    public class PacientesRepository : IRepository<VW_tbPacientes>
    {
        public RequestStatus Delete(VW_tbPacientes id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbPacientes find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbPacientes item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbPacientes> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            return db.Query<VW_tbPacientes>(ScriptsDataBase.UDP_Listar_Pacientes, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbPacientes item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
