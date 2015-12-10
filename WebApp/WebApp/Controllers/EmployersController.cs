using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            EmpRepo = new Repository<EmployersDetailsDto, Employee>();
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
        [ResponseType(typeof(EmployersDetailsDto))]
        public IHttpActionResult PutEmployee(int id, EmployersDetailsDto employee)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployersDetailsDtoId)
            {
                return BadRequest();
            }
            try
            {
                EmpRepo.Edit(id, employee);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new HttpRequestException(e.ToString());
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Employers
        public IHttpActionResult PostEmployee(EmployersDetailsDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            EmpRepo.Add(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployersDetailsDtoId }, employee);
        }

        // DELETE api/Employers/5
        [ResponseType(typeof(EmployersDetailsDto))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            EmpRepo.Remove(id);
            return Ok();
        }
    }
}