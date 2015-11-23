using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Callers;
using System.Net.Http.Headers;
using System.Net.Http;
using WebClient.Models;

namespace WebClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Name:Name221	LastName:LName31
            GetEmployers(20).Wait();
            //PostEmployee().Wait();
            //DeleteEmployee(20).Wait();
        }

        static async Task GetEmployers()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64656/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

        static async Task GetEmployers(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64656/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string query = "api/employers/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    Employee employee = await response.Content.ReadAsAsync<Employee>();
                    Console.WriteLine("{0}\tName:{1}\tLastName:{2}", employee.EmployeeId, employee.Name, employee.LastName);
                }
            }
        }

        static async Task PostEmployee(string name, string lastName)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64656/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/employers");
                var newEmp = new Employee() { Name = name, LastName = lastName };
                response = await client.PostAsJsonAsync("api/employers", newEmp);
                if (response.IsSuccessStatusCode)
                {
                    Uri empUrl = response.Headers.Location;
                }
            }
        }

        static async Task DeleteEmployee(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64656/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
    }
}
