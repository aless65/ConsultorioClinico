using Consultorio.DataAccess.Repository;
using ConsultorioClinico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.BussinesLogic.Services
{
    public class GralService
    {
        private readonly DepartamentosRepository _departamentosRepository;
        private readonly EstadosCivilesRepository _estadosCivilesRepository;

        public GralService(DepartamentosRepository departamentosRepository, EstadosCivilesRepository estadosCivilesRepository) 
        {
            _departamentosRepository = departamentosRepository;
            _estadosCivilesRepository = estadosCivilesRepository;
        }

        #region Departamentos
        public ServiceResult ListaDepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarDepartamentos(VW_tbDepartamentos item)
        {
            var result = new ServiceResult();

            var insertar = _departamentosRepository.Insert(item);
            return result.Ok(insertar);
        }

        public ServiceResult ListarMunicipios(string id)
        {
            var result = new ServiceResult();
            var listar = _departamentosRepository.ListMunicipios(id);
            return result.Ok(listar);
        }
        #endregion

        #region Estados Civiles
        public ServiceResult ListarEstadosCiviles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadosCivilesRepository.List();
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
