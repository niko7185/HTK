using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HTK.DataAccess
{
    public interface IRepositoryBase<T>
    {

        public Task<IEnumerable<T>> GetAll();

        public void Update();

        public void Add(T t);

        public void Delete(T t);

    }
}
