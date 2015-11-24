using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    class WorkNoteRepository : IWorkNotesRepository
    {
        public async Task<List<WorkNote>> GetWorkNotes()
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                HttpResponseMessage response = await client.GetAsync("api/WorkNotes");
                if (response.IsSuccessStatusCode)
                {
                    List<WorkNote> notes = await response.Content.ReadAsAsync<List<WorkNote>>();
                    return notes;
                }
                return null;
            }
        }
        public async Task<WorkNote> GetWorkNote(int id)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/WorkNotes/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    WorkNote workNote = await response.Content.ReadAsAsync<WorkNote>();
                    return workNote;
                }
                else
                    return null;
            }
        }

        public Task PostWorkNote(WorkNote workNote)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorkNote(int workNoteId)
        {
            throw new NotImplementedException();
        }

        static void ConfigClient(HttpClient c)
        {
            c.BaseAddress = new Uri("http://localhost:64656/");
            c.DefaultRequestHeaders.Accept.Clear();
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
