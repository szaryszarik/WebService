using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployersController : ApiController
    {
        private WebAppContext db = new WebAppContext();
        private Repository<EmployersDetailsDto, Employee> EmpRepo;

        public EmployersController()
        {
            EmpRepo = new Repository<EmployersDetailsDto, Employee>(db.Employees, db);
        }

        // GET api/Employers
        public IList<EmployersDetailsDto> GetEmployees()
        {
            return EmpRepo.Get();
        }

        // GET api/Employers/5
        [ResponseType(typeof(EmployersDetailsDto))]
        public IHttpActionResult GetEmployee(int id)
        {
            EmployersDetailsDto employee = EmpRepo.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT api/Employers/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            try
            {
                EmpRepo.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!EmpRepo.EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Employers
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            EmpRepo.Add(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE api/Employers/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = EmpRepo.Remove(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}