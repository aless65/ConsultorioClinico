using Consultorio.DataAccess.Repository;
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
            //try
            //{
            var list = _cargosRepository.List();
            return result.Ok(list);
            //}
            //catch (Exception ex)
            //{
            //    return result.Error(ex.Message);
            //}
        }
        #endregion
    }
}
