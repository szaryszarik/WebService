﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    interface IWorkNotesRepository
    {
        Task GetWorkNote(int id);
        Task PostWorkNote(WorkNote workNote);
        Task DeleteWorkNote(int workNoteId);
    }
}