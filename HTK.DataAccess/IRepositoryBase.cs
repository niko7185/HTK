using System;
using System.Collections.Generic;
using System.Text;

namespace HTK.DataAccess
{
    public interface IRepositoryBase<T>
    {

        public IEnumerable<T> GetAll();

        public void Update();

        public void Add(T t);

        public void Delete(T t);

    }
}
