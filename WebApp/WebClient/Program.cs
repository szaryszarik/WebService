using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net.Http;
using WebClient.Models;

namespace WebClient
{
    static class Program
    {
        static EmployeeRepository eRep = new EmployeeRepository();
        static WorkNoteRepository wRep = new WorkNoteRepository();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //PutEmployee(32, "Mesajah", null).Wait();
        }

        static async Task GetWorkNote(int id)
        {
            await wRep.GetWorkNote(id);
        }

        static async Task PostWorkNote(WorkNote workNote)
        {
            await wRep.PostWorkNote(workNote);
        }

        static async Task DeleteWorkNote(int workNoteId)
        {
            await wRep.DeleteWorkNote(workNoteId);
        }

        static async Task PutEmployee(int id, string name, string lastname)
        {
            await eRep.PutEmployee(id, name, lastname);
        }
    }
}
