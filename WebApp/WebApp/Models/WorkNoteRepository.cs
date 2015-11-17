using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class WorkNoteRepository : IDisposable, IWorkNotesRepository
    {
        private WebAppContext db = new WebAppContext();

        public WorkNote GetWorkNote(int id)
        {
            WorkNote worknote = db.WorkNotes.Find(id);
            if (worknote != null)
                return worknote;
            else return null;
        }

        public void PostWorkNote(WorkNote workNote)
        {
            db.WorkNotes.Add(workNote);
            db.SaveChanges();
        }

        public WorkNote DeleteWorkNote(int workNoteId)
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

        public void PutWorkNote(int workNoteId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}