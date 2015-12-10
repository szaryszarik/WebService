using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WebClient.Models
{
    class EmployeeRepository : IEmployeeRepository
    {
        public async Task<BindingList<EmployersDetailsDto>> get()
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                HttpResponseMessage response = await client.GetAsync("api/employers");
                if (response.IsSuccessStatusCode)
                {
                    BindingList<EmployersDetailsDto> emps = await response.Content.ReadAsAsync<BindingList<EmployersDetailsDto>>();
                    return emps;
                }
                return null;
            }
        }

        public async Task get(int id)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/employers/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    Employee employee = await response.Content.ReadAsAsync<Employee>();
                }
            }
        }

        public async Task add(string name, string lastName)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                HttpResponseMessage response = await client.GetAsync("api/employers");
                var newEmp = new Employee() { Name = name, LastName = lastName };
                response = await client.PostAsJsonAsync("api/employers", newEmp);
                if (response.IsSuccessStatusCode)
                {
                    Uri empUrl = response.Headers.Location;
                }
            }
        }

        public async Task remove(int id)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/employers/" + id;
                var response = client.DeleteAsync(query).Result;
                var data = response.Content;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> d = data.ReadAsStringAsync();
                }
            }
        }

        public async Task edit(int id, string name, string lastname)
        {
            using(var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/employers/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    EmployersDetailsDto temp = await response.Content.ReadAsAsync<EmployersDetailsDto>();
                    temp.Name = name;
                    temp.LastName = lastname;
					temp.EmployersDetailsDtoId = id;
                    response = await client.PutAsJsonAsync(query, temp);
                }
            }
        }

        static void ConfigClient(HttpClient c)
        {
            c.BaseAddress = new Uri("http://localhost:64656/");
            c.DefaultRequestHeaders.Accept.Clear();
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
