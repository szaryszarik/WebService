using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    interface IWorkNotesRepository
    {
        WorkNote Get(int id);
        void Add(WorkNote workNote);
        WorkNote Remove(int workNoteId);
        void Update(int workNoteId, WorkNote workNote);
    }
}
