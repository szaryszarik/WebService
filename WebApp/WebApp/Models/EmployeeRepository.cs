using AutoMapper;
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
            var employers = db.Employees.ToList();
            return Mapper.Map<List<EmployersDetailsDto>>(employers);
        }

        public EmployersDetailsDto Get(int employeeId)
        {
            var employers = db.Employees.Find(employeeId);
            return Mapper.Map<EmployersDetailsDto>(employers);
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
            var emp = db.Employees.Find( id );
			if ( emp == null )
			{
				return;
			}

			emp.LastName = employee.LastName;
			emp.Name = employee.Name;

			db.SaveChanges();
        }

        public bool EmployeeExists(int id)
        {
            return db.Employees.Any(e => e.EmployeeId == id);
        }
    }
}