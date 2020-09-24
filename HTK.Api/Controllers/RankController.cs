using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HTK.DataAccess;
using HTK.Entitties;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HTK.Api.Controllers
{
    [Route("ranks")]
    [ApiController]
    public class RankController: ControllerBase
    {
        // GET: api/<RankController>
        [HttpGet]
        public async Task<IEnumerable<Members>> Get()
        {
            MemberRepository memberRep = new MemberRepository();
            return await memberRep.GetRanks();
        }

        // GET api/<RankController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RankController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RankController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RankController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
