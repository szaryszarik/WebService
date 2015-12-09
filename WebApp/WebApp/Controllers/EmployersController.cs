using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
            EmpRepo = new Repository<EmployersDetailsDto, Employee>();
        }

        // GET api/Employers
        public IList<EmployersDetailsDto> getEmployees()
        {
            return EmpRepo.get();
        }

        // GET api/Employers/5
        [ResponseType(typeof(EmployersDetailsDto))]
        public IHttpActionResult getEmployee(int id)
        {
            EmployersDetailsDto employee = EmpRepo.get(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT api/Employers/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult putEmployee(int id, Employee employee)
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
                var temp = db.Employees.Find(id);
                temp.LastName = employee.LastName;
                temp.Name = employee.Name;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Employers
        [ResponseType(typeof(Employee))]
        public IHttpActionResult postEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            EmpRepo.add(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE api/Employers/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult deleteEmployee(int id)
        {
            EmpRepo.remove(id);
            return Ok();
        }
    }
}