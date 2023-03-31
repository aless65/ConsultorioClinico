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
    public class ConsultasRepository : IRepository<VW_tbConsultas>
    {
        public RequestStatus Delete(VW_tbConsultas id, int Mod)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cons_Id", id, DbType.Int32, ParameterDirection.Input);
            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Eliminar_Consultas, parametros, commandType: CommandType.StoredProcedure);
        }

        public VW_tbConsultas find(int? id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cons_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbConsultas>(ScriptsDataBase.UDP_Encontrar_Consultas, parametros, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Insert(VW_tbConsultas item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cons_Inicio", item.cons_Inicio, DbType.DateTime, ParameterDirection.Input);
            parametros.Add("@cons_Final", item.cons_Final, DbType.DateTime, ParameterDirection.Input);
            parametros.Add("@paci_Id", item.paci_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@consltro_Id", item.consltro_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cons_Costo", item.cons_Costo, DbType.Double, ParameterDirection.Input);
            parametros.Add("@cons_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);
            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Insertar_Consultas, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbConsultas> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbConsultas>(ScriptsDataBase.UDP_Listar_Consultas, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbConsultas_Reporte> ListReportes()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbConsultas_Reporte>(ScriptsDataBase.UDP_Consultas_Reporte, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbConsultas item, int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cons_Inicio", item.cons_Inicio, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cons_Final", item.cons_Final, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@paci_Id", item.paci_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@consltro_Id", item.cons_Inicio, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cons_Costo", item.cons_Costo, DbType.Double, ParameterDirection.Input);
            parametros.Add("@cons_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Editar_Consultas, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbConsultas> ListDdl()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);
            return db.Query<VW_tbConsultas>(ScriptsDataBase.UDP_Consultas_DDL, null, commandType: CommandType.StoredProcedure);
        }

        public decimal CostoConsulta(int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cons_Id", id, DbType.Int32, ParameterDirection.Input);
            return db.QueryFirst<decimal>(ScriptsDataBase.UDP_Consultas_Costo, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
