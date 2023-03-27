using Consultorio.DataAccess.Repository;
using ConsultorioClinico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.BussinesLogic.Services
{
    public class ConsService
    {
        private readonly CargosRepository _cargosRepository;
        private readonly EmpleadosRepository _empleadosRepository;
        private readonly ClinicasRepository _clinicasRepository;

        public ConsService(CargosRepository cargosRepository, EmpleadosRepository empleadosRepository, ClinicasRepository clinicasRepository)
        {
            _cargosRepository = cargosRepository;
            _empleadosRepository = empleadosRepository;
            _clinicasRepository = clinicasRepository;
        }
        #region Cargos
        public ServiceResult ListaCargos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _cargosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarCargos(VW_tbCargos item)
        {
            var result = new ServiceResult();

            try
            {
                var insert = _cargosRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarCargos(VW_tbCargos item, int id)
        {
            var result = new ServiceResult();
            try
            {
                var update = _cargosRepository.Update(item, id);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCargos(int id)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _cargosRepository.DeleteConfirmed(id);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public VW_tbCargos Find(int id)
        {
            var obtener = _cargosRepository.find(id);
            return obtener;
        }
        #endregion

        #region Empleados
        public ServiceResult ListaEmpleados()
        {
            var result = new ServiceResult();
            try
            {
                var listado = _empleadosRepository.List();
                return result.Ok(listado);
            } 
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult InsertarEmpleados(VW_tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _empleadosRepository.Insert(item);
                return result.Ok(insert);
            } catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult EditarEmpleados(VW_tbEmpleados item, int id)
        {
            var result = new ServiceResult();
            try
            {
                var update = _empleadosRepository.Update(item, id);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }

        }

        public ServiceResult EliminarEmpleados(int id)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _empleadosRepository.DeleteConfirmed(id);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult FindEmpleado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var encontrar = _empleadosRepository.find(id);
                return result.Ok(encontrar);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        #endregion

        #region Clinicas
        public ServiceResult ListaClinicas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _clinicasRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
