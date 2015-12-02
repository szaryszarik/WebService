using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class WorkNoteRepository : IWorkNotesRepository
    {
        private WebAppContext db = new WebAppContext();

        public WorkNote Get(int id)
        {
            return db.WorkNotes.Find(id);
        }

        public void Add(WorkNote workNote)
        {
            db.WorkNotes.Add(workNote);
            db.SaveChanges();
        }

        public WorkNote Remove(int workNoteId)
        {
            WorkNote worknote = db.WorkNotes.Find(workNoteId);
            if (worknote != null)
            {
                db.WorkNotes.Remove(worknote);
                db.SaveChanges();
                return worknote;
            }
            return null;
        }

        public void Update(int workNoteId, WorkNote workNote)
        {
            db.Entry(workNote).State = EntityState.Modified;
            var note = db.WorkNotes.Single(w => w.WorkNoteId == workNoteId);
            db.SaveChanges();
        }

        public bool WorkNoteExists(int id)
        {
            return db.WorkNotes.Any(e => e.WorkNoteId == id);
        }
    }
}