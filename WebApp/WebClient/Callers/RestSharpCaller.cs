using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Callers
{
    class RestSharpCaller : ICaller
    {
        private RestClient client;
        public RestSharpCaller(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public List<Employee> GetEmployees()
        {
            var request = new RestRequest("Employees", Method.GET);
            var response = client.Execute<List<Employee>>(request);
            return response.Data;
        }

        public void Create(Employee employee)
        {
            var request = new RestRequest("Employees", Method.POST);
            request.AddJsonBody(employee);
            client.Execute(request);
        }

        public void Delete(int id)
        {
            var request = new RestRequest("Employees/" + id, Method.DELETE);
            client.Execute(request);
        }
    }
}
