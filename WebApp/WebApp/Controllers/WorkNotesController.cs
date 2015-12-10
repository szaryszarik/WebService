using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
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
        public IList<WorkNotesDto> GetWorkNotes()
        {
            return WorkRep.Get();
        }

        // GET api/WorkNotes/5
        [ResponseType(typeof(WorkNotesDto))]
        public IHttpActionResult GetWorkNote(int id)
        {
            WorkNotesDto worknote = WorkRep.Get(id);
            if (worknote == null)
            {
                return NotFound();
            }

            return Ok(worknote);
        }

        // PUT api/WorkNotes/5
        public IHttpActionResult PutWorkNote(int id, WorkNotesDto worknote)
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
                WorkRep.Edit(id, worknote);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new HttpRequestException(e.ToString());
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/WorkNotes
        public IHttpActionResult PostWorkNote(WorkNotesDto worknote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkRep.Add(worknote);

            return CreatedAtRoute("DefaultApi", new { id = worknote.WorkNoteId }, worknote);
        }

        // DELETE api/WorkNotes/5
        public IHttpActionResult DeleteWorkNote(int id)
        {
            WorkRep.Remove(id);
            return Ok();
        }
    }
}