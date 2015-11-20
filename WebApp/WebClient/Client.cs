using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    class Client
    {
        private RestClient client = new RestClient("http://localhost:64656/");
        RestRequest request = new RestRequest("Employers", Method.GET);
        IRestRequest<List<Employee>> response = client.Execute<List<Employee>>(request);
    }
}
