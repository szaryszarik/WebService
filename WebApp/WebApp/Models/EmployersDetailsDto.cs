using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployersDetailsDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<WorkNote> WorkNotes { get; set; }
    }
}