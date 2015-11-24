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
        public async Task GetWorkNote(int id)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/WorkNotes/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    WorkNote workNote = await response.Content.ReadAsAsync<WorkNote>();
                    Console.WriteLine("WorkNote ID: {0}\tNote: {1}", workNote.WorkNoteId, workNote.Note);
                }
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
