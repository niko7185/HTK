using HTK.Entitties;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTK.DataAccess
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {

        protected HTKContext htkContext;

        public RepositoryBase()
        {
            htkContext = new HTKContext();
        }

        public void Add(T t)
        {
            htkContext.Set<T>().Add(t);

            htkContext.SaveChanges();
        }

        public void Delete(T t)
        {
            htkContext.Set<T>().Remove(t);

            htkContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await htkContext.Set<T>().ToListAsync();
        }

        public void Update()
        {
            htkContext.SaveChanges();
        }
    }
}
