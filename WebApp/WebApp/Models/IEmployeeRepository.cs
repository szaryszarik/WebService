using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    interface IEmployeeRepository : IDisposable
    {
        List<EmployersDetailsDto> GetEmployees();
        Employee GetEmployee(int employeeId);
        void PostEmployee(Employee employee);
        Employee DeleteEmployee(int employeeId);
        void PutEmployee(int employeId);
    }
}
