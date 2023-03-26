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

        public ConsService(CargosRepository cargosRepository)
        {
            _cargosRepository = cargosRepository;

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
    }
}
