using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVC.Helper
{
    public class PersonAPI
    {
        private string _apiBaseURI = "http://localhost:62722";
        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseURI);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
