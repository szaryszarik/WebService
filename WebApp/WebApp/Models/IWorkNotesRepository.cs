using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    interface IWorkNotesRepository
    {
        WorkNote GetWorkNote(int id);
        void PostWorkNote(WorkNote workNote);
        WorkNote DeleteWorkNote(int workNoteId);
        void PutWorkNote(int workNoteId, WorkNote workNote);
    }
}
