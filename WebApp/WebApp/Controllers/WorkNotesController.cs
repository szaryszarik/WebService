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
    public class WorkNotesController : ApiController
    {
        private WorkNoteRepository wRep = new WorkNoteRepository();
        private WebAppContext db = new WebAppContext();
        private Repository<WorkNotesDto, WorkNote> WorkRep;

        public WorkNotesController()
        {
            WorkRep = new Repository<WorkNotesDto, WorkNote>(db.WorkNotes, db);
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
        public IHttpActionResult PutWorkNote(int id, WorkNote worknote)
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
                WorkRep.Update(id, worknote);
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!WorkRep.WorkNoteExists(id))
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

        // POST api/WorkNotes
        [ResponseType(typeof(WorkNote))]
        public IHttpActionResult PostWorkNote(WorkNote worknote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkRep.Add(worknote);

            return CreatedAtRoute("DefaultApi", new { id = worknote.WorkNoteId }, worknote);
        }

        // DELETE api/WorkNotes/5
        [ResponseType(typeof(WorkNote))]
        public IHttpActionResult DeleteWorkNote(int id)
        {
            WorkNote worknote = WorkRep.Remove(id);
            if (worknote == null)
            {
                return NotFound();
            }
            return Ok(worknote);
        }
    }
}