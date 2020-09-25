using HTK.Entitties;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTK.Services
{
    public class RankService
    {

        public async Task<List<Members>> GetMembersAsync()
        {

            HttpWebRequest httpWebRequest = WebRequest.CreateHttp("https://localhost:44301/ranks");

            httpWebRequest.Method = WebRequestMethods.Http.Get;

            httpWebRequest.Accept = "application/json";


            string result;

            using(HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            {

                using StreamReader sr = new StreamReader(response.GetResponseStream());

                result = await sr.ReadToEndAsync();
            };

            return JsonConvert.DeserializeObject<List<Members>>(result);

        }

    }
}
