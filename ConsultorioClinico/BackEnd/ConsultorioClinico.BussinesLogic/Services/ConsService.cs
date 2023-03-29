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
        private readonly ConsultasRepository _consultasRepository;
        private readonly EmpleadosRepository _empleadosRepository;
        private readonly ClinicasRepository _clinicasRepository;
        private readonly FacturasRepository _facturasRepository;
        private readonly PacientesRepository _pacientesRepository;
        private readonly MetodosRepository _metodosRepository;

        public ConsService(CargosRepository cargosRepository, ConsultasRepository consultasRepository, EmpleadosRepository empleadosRepository, ClinicasRepository clinicasRepository,
                           FacturasRepository facturasRepository, PacientesRepository pacientesRepository, MetodosRepository metodosRepository)
        {
            _cargosRepository = cargosRepository;
            _consultasRepository = consultasRepository;
            _empleadosRepository = empleadosRepository;
            _clinicasRepository = clinicasRepository;
            _facturasRepository = facturasRepository;
            _pacientesRepository = pacientesRepository;
            _metodosRepository = metodosRepository;
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

                if (insert.MessageStatus == "El registro se ha insertado con éxito")
                    return result.Ok(insert);
                else if (insert.MessageStatus == "Ya existe un cargo con este nombre")
                    return result.Conflict(insert.MessageStatus);
                else
                    return result.SetMessage("Por favor llene todos los campos", ServiceResultType.Conflict);
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
                if (update.MessageStatus == "El registro ha sido editado con éxito")
                    return result.SetMessage(update.MessageStatus, ServiceResultType.Success);
                else if (update.MessageStatus == "El registro que intenta editar no existe")
                    return result.Conflict(update.MessageStatus);
                else if (update.MessageStatus == "Ya existe un cargo con este nombre")
                    return result.Conflict(update.MessageStatus);
                else
                    return result.SetMessage("Por favor llene todos los campos", ServiceResultType.Conflict);
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
                if (delete.MessageStatus == "El registro ha sido eliminado con éxito")
                    return result.SetMessage(delete.MessageStatus, ServiceResultType.Success);
                else if (delete.MessageStatus == "El registro que intenta eliminar no existe")
                    return result.Conflict(delete.MessageStatus);
                else
                    return result.SetMessage(delete.MessageStatus, ServiceResultType.Conflict);
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

        #region Consultas
        public ServiceResult ListaConsultas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _consultasRepository.List();
                return result.Ok(list);
            } 
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult InsertarConsultas(VW_tbConsultas item)
        {
            var result = new ServiceResult();

            //try
            //{
            var insert = _consultasRepository.Insert(item);
            return result.Ok(insert);
            //}
            //catch (Exception ex)
            //{
            //    return result.Error(ex);
            //}
        }
        public ServiceResult EliminarConsultas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _consultasRepository.DeleteConfirmed(id);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public VW_tbConsultas FindConsultas(int id)
        {
            var obtener = _consultasRepository.find(id);
            return obtener;
        }

        public ServiceResult EditarConsultas(VW_tbConsultas item, int id)
        {
            var result = new ServiceResult();
            try
            {
                var update = _consultasRepository.Update(item, id);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
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
        #region Facturas
        public ServiceResult ListaFacturas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _facturasRepository.Listado();
                return result.Ok(list);
            } catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        
        public ServiceResult InsertarFacturas(VW_tbFacturas_tbFacturasDetalles item)
        {
            var result = new ServiceResult();
            try { 
                var insert = _facturasRepository.Insert(item);
                return result.SetMessage(insert.CodeStatus.ToString(), ServiceResultType.Success);
            } catch(Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Pacientes
        public ServiceResult ListaPacientes()
        {
            var result = new ServiceResult();
            try
            {
                var listado = _pacientesRepository.List();
                return result.Ok(listado);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        #endregion

        #region Métodos
        public ServiceResult ListaMetodos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _metodosRepository.List();
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
