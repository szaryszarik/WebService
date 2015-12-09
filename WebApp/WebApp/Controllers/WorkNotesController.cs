using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class WorkNotesController : ApiController
    {
        private WebAppContext db = new WebAppContext();
        private Repository<WorkNotesDto, WorkNote> WorkRep;

        public WorkNotesController()
        {
            WorkRep = new Repository<WorkNotesDto, WorkNote>();
        }
        
        // GET api/WorkNotes
        public IList<WorkNotesDto> getWorkNotes()
        {
            return WorkRep.get();
        }

        // GET api/WorkNotes/5
        [ResponseType(typeof(WorkNotesDto))]
        public IHttpActionResult getWorkNote(int id)
        {
            WorkNotesDto worknote = WorkRep.get(id);
            if (worknote == null)
            {
                return NotFound();
            }

            return Ok(worknote);
        }

        // PUT api/WorkNotes/5
        public IHttpActionResult putWorkNote(int id, WorkNote worknote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worknote.WorkNoteId)
            {
                return BadRequest();
            }
            try
            {
                db.Entry(worknote).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/WorkNotes
        [ResponseType(typeof(WorkNote))]
        public IHttpActionResult postWorkNote(WorkNote worknote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkRep.add(worknote);

            return CreatedAtRoute("DefaultApi", new { id = worknote.WorkNoteId }, worknote);
        }

        // DELETE api/WorkNotes/5
        [ResponseType(typeof(WorkNote))]
        public IHttpActionResult deleteWorkNote(int id)
        {
            WorkRep.remove(id);
            return Ok();
        }
    }
}