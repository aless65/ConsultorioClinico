using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess.Repository
{
    public interface IRepository<T>
    {
            public IEnumerable<T> List();
            public RequestStatus Insert(T item);
            public RequestStatus Update(T item, int id);
            public T find(int? id);
            public RequestStatus Delete(T id, int Mod);

    }
}
