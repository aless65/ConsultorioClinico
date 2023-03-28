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
    public class EmpleadosRepository : IRepository<VW_tbEmpleados>
    {
        public RequestStatus Delete(VW_tbEmpleados id, int Mod)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Eliminar_Empleados, parametros, commandType: CommandType.StoredProcedure);
        }

        public VW_tbEmpleados find(int? id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbEmpleados>(ScriptsDataBase.UDP_Encontrar_Empleados, parametros, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Insert(VW_tbEmpleados item)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Apellido", item.empe_Apellido, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_FechaNacimiento", item.empe_FechaNacimiento, DbType.Date, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Direccion", item.empe_Direccion, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Correo", item.empe_Correo, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_FechaInicio", item.empe_FechaInicio, DbType.Date, ParameterDirection.Input);
            parametros.Add("@empe_FechaFinal", item.empe_FechaFinal, DbType.Date, ParameterDirection.Input);
            parametros.Add("@carg_Id", item.carg_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@clin_Id", item.clin_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Insertar_Empleados, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbEmpleados> List()
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            return db.Query<VW_tbEmpleados>(ScriptsDataBase.UDP_Listar_Empleados, null, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(VW_tbEmpleados item, int id)
        {
            using var db = new SqlConnection(ConsultorioContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Apellido", item.empe_Apellido, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_FechaNacimiento", item.empe_FechaNacimiento, DbType.Date, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Direccion", item.empe_Direccion, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Correo", item.empe_Correo, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_FechaInicio", item.empe_FechaInicio, DbType.Date, ParameterDirection.Input);
            parametros.Add("@empe_FechaFinal", item.empe_FechaFinal, DbType.Date, ParameterDirection.Input);
            parametros.Add("@carg_Id", item.carg_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@clin_Id", item.clin_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_Editar_Empleados, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
