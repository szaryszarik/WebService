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
        private EmployeeRepository eRep = new EmployeeRepository();
        private WebAppContext db = new WebAppContext();

        // GET api/Employers
        public IList<EmployersDetailsDto> GetEmployees()
        {
            return eRep.Get();
        }

        // GET api/Employers/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = eRep.Get(id);
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
                eRep.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eRep.EmployeeExists(id))
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

            eRep.Add(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE api/Employers/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = eRep.Remove(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}