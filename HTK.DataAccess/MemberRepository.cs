using HTK.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTK.DataAccess
{
    public class MemberRepository : RepositoryBase<Members>
    {

        public async Task<IEnumerable<Members>> GetActiveMembers()
        {

            return await htkContext.Members.Where(m => m.IsActive).ToListAsync();

        }

        public async Task<IEnumerable<Members>> GetRanks()
        {
            return await htkContext.Members.Include("Rank").Where(m => m.IsActive).ToListAsync();
        }

    }
}
