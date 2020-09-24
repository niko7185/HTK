using HTK.Entitties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTK.DataAccess
{
    public class MemberRepository : RepositoryBase<Members>
    {

        public List<Members> GetActiveMembers()
        {

            return htkContext.Members.Where(m => m.IsActive).ToList();

        }

    }
}
