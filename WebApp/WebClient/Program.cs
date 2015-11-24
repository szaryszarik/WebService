﻿using RestSharp;
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
            //id=8
            //PostEmployee("NAME", "LASTNAME").Wait();
            //WorkNote ww = new WorkNote() { EmployeeId = 1, Note = "another test" };
            //PostWorkNote(ww).Wait();
            //DeleteWorkNote(7).Wait();
        }

        static async Task GetEmployers()
        {
            await eRep.GetEmployers();
        }

        static async Task GetEmployers(int id)
        {
            await eRep.GetEmployers(id);
        }

        static async Task PostEmployee(string name, string lastName)
        {
            await eRep.PostEmployee(name, lastName);
        }

        static async Task DeleteEmployee(int id)
        {
            await eRep.DeleteEmployee(id);
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
    }
}
