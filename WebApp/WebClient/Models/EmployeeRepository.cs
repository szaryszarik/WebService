﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    class EmployeeRepository : IEmployeeRepository
    {
        public async Task GetEmployers()
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                HttpResponseMessage response = await client.GetAsync("api/employers");
                if (response.IsSuccessStatusCode)
                {
                    EmployersDetailsDto[] emps = await response.Content.ReadAsAsync<EmployersDetailsDto[]>();
                    foreach (EmployersDetailsDto emp in emps)
                    {
                        Console.WriteLine("Name: {0}\tLastName: {1}\tWorkNotes: {2}", emp.Name, emp.LastName, emp.WorkNotes);
                    }
                }
            }
        }

        public async Task GetEmployers(int id)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/employers/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    Employee employee = await response.Content.ReadAsAsync<Employee>();
                    Console.WriteLine("{0}\tName:{1}\tLastName:{2}", employee.EmployeeId, employee.Name, employee.LastName);
                }
            }
        }

        public async Task PostEmployee(string name, string lastName)
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:64656/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

        public async Task DeleteEmployee(int id)
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
                    Console.WriteLine("Tthe deleted record is");
                    Console.Write(d.Result.ToString());
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
