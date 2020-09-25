using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HTK.Entitties;
using HTK.Services;
using System.Threading.Tasks;
using Xunit;

namespace HTK.Tests
{
    public class ApiTests
    {

        [Fact]
        public async Task ConnectionTestAsync()
        {

            RankService rankService = new RankService();

            List<Members> members = await rankService.GetMembersAsync();

            Assert.True(members.Count > 0);

        }
    }
}
