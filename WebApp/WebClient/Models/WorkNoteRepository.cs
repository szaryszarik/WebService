using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public async Task PostWorkNote(WorkNote workNote)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                HttpResponseMessage response = await client.GetAsync("api/WorkNotes");
                response = await client.PostAsJsonAsync("api/WorkNotes", workNote);
                if (response.IsSuccessStatusCode)
                {
                    Uri WorkNoteUrl = response.Headers.Location;
                }
            }
        }

        public async Task DeleteWorkNote(int workNoteId)
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/WorkNotes/" + workNoteId;
                var response = client.DeleteAsync(query).Result;
                var data = response.Content;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> d = data.ReadAsStringAsync();
                    Console.WriteLine("The deleted record is");
                    Console.Write(d.Result.ToString());
                }
            }
        }

        public async Task PutWorkNote(int id, WorkNote workNote)
        {
            using(var client = new HttpClient())
            {
                ConfigClient(client);
                string query = "api/WorkNotes/" + id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    WorkNote temp = await response.Content.ReadAsAsync<WorkNote>();
                    temp.Date = workNote.Date;
                    temp.EmployeeId = workNote.EmployeeId;
                    temp.StartTime = workNote.StartTime;
                    temp.EndTime = workNote.EndTime;
                    temp.Note = workNote.Note;
                    temp.WorkNoteId = workNote.WorkNoteId;

                    Console.WriteLine("OK: {0}", temp.WorkNoteId);
                    response = await client.PutAsJsonAsync(query, temp);
                }
            }
        }

        static void ConfigClient(HttpClient c)
        {
            c.BaseAddress = new Uri("http://localhost:64656/");
            c.DefaultRequestHeaders.Accept.Clear();
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
