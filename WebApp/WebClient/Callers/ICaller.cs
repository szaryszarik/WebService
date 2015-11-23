using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Callers
{
    interface ICaller
    {
        List<Employee> GetEmployees();
        void Create(Employee employee);
        //Employee Delete(int employeeId);
        void Delete(int id);
    }
}
