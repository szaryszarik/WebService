﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeRepository : IDisposable, IEmployeeRepository
    {
        private WebAppContext db = new WebAppContext();
        public List<EmployersDetailsDto> GetEmployees()
        {
            return db.Employees.Select(p => new EmployersDetailsDto
            {
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

        public void PutEmployee(int employeId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}