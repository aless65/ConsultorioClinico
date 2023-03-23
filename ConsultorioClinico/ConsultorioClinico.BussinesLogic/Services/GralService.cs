using Consultorio.DataAccess.Repository;
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

        public GralService(DepartamentosRepository departamentosRepository) 
        {
            _departamentosRepository = departamentosRepository;

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
        #endregion
    }
}
