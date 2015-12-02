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
            emps = Get();
        }

        public List<EmployersDetailsDto> Get()
        {
            return db.Employees.Select(p => new EmployersDetailsDto
            {
                EmployersDetailsDtoId = p.EmployeeId,
                Name = p.Name,
                LastName = p.LastName,
                WorkNotes = p.WorkNotes.ToList()
            }).ToList();
        }

        public Employee Get(int employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);
            return employee;
        }

        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public Employee Remove(int employeeId)
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

        public void Update(int id, Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            var emp = db.Employees.Single(e => e.EmployeeId == id);
            db.SaveChanges();
        }

        public bool EmployeeExists(int id)
        {
            return db.Employees.Any(e => e.EmployeeId == id);
        }
    }
}