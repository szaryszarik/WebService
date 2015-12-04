using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    interface IWorkNotesRepository
    {
        WorkNotesDto Get(int id);
        List<WorkNotesDto> Get();
        void Add(WorkNote workNote);
        WorkNote Remove(int workNoteId);
        void Update(int workNoteId, WorkNote workNote);
    }
}
