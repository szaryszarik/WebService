using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebClient.Models
{
    interface IWorkNotesRepository
    {
        Task<List<WorkNote>> get();
        Task<WorkNote> get(int id);
        Task add(WorkNote workNote);
        Task remove(int workNoteId);
        Task edit(int id, WorkNote workNote);
    }
}
