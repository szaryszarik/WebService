using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    interface IEmployeeRepository
    {
        List<EmployersDetailsDto> Get();
        Employee Get(int employeeId);
        void Add(Employee employee);
        Employee Remove(int employeeId);
        void Update(int id, Employee employee);
    }
}
