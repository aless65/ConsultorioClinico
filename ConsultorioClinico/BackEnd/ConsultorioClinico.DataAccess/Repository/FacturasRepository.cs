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
    public class FacturasRepository : IRepository<VW_tbFacturas_tbFacturasDetalles>
    {
        public RequestStatus Delete(VW_tbFacturas_tbFacturasDetalles id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbFacturas_tbFacturasDetalles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(VW_tbFacturas_tbFacturasDetalles item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            var parametros = new DynamicParameters();
            parametros.Add("@paci_Id", item.paci_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@meto_Id", item.meto_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@fact_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            var answer = db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Facturas, parametros, commandType: CommandType.StoredProcedure);

            result.CodeStatus = answer;

            return result;
        }

        public RequestStatus InsertDetalles(VW_tbFacturas_tbFacturasDetalles item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            RequestStatus result = new RequestStatus();

            var parametros = new DynamicParameters();
            parametros.Add("@fact_Id", item.fact_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cons_Id", item.cons_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@factdeta_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Insertar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbFacturas> Listado()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            return db.Query<VW_tbFacturas>(ScriptsDataBase.UDP_Listar_Facturas, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbFacturas_tbFacturasDetalles> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(VW_tbFacturas_tbFacturasDetalles item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
