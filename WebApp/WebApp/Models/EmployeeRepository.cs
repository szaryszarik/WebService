using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private WebAppContext db = new WebAppContext();
        private List<EmployersDetailsDto> emps;
        public EmployeeRepository()
        {
            emps = GetEmployees();
        }

        public List<EmployersDetailsDto> GetEmployees()
        {
            return db.Employees.Select(p => new EmployersDetailsDto
            {
                EmployersDetailsDtoId = p.EmployeeId,
                Name = p.Name,
                LastName = p.LastName,
                WorkNotes = p.WorkNotes.ToList()
            }).ToList();
        }

        public Employee GetEmployee(int employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);
            return employee;
        }

        public void PostEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public Employee DeleteEmployee(int employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                return employee;
            }
            return null;

        }

        public void PutEmployee(int id, Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            var emp = db.Employees.Single(e => e.EmployeeId == id);
            db.SaveChanges();
        }
    }
}