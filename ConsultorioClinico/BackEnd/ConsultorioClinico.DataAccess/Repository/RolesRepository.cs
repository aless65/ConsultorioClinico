using ConsultorioClinico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess.Repository
{
    public class RolesRepository : IRepository<tbRoles>
    {
        public RequestStatus Delete(tbRoles id, int Mod)
        {
            throw new NotImplementedException();
        }

        public tbRoles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbRoles> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbRoles item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
