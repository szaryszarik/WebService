﻿using System.Collections.Generic;

namespace WebApp.Models
{
    public class EmployersDetailsDto
    {
        public int EmployersDetailsDtoId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<WorkNote> WorkNotes { get; set; }
    }
}