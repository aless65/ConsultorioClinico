using Consultorio.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.BussinesLogic.Services
{
    public class AcceService
    {
        private readonly RolesRepository _rolesRepository;

        public AcceService(RolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #region Roles
        public ServiceResult ListaRoles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolesRepository.List();
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
