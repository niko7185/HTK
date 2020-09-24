using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xunit;

namespace HTK.Tests
{
    public class ApiTests
    {

        [Fact]
        public async System.Threading.Tasks.Task ConnectionTestAsync()
        {

            HttpWebRequest httpWebRequest = WebRequest.CreateHttp("https://localhost:44301/weatherforecast");

            httpWebRequest.Method = WebRequestMethods.Http.Get;

            httpWebRequest.Accept = "application/json";


            string result;

            using(HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            {

                using StreamReader sr = new StreamReader(response.GetResponseStream());

                result = await sr.ReadToEndAsync();
            };

            Assert.True(httpWebRequest.HaveResponse);
        }
    }
}
