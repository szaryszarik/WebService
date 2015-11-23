using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    class EmployersDetailsDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<WorkNote> WorkNotes { get; set; }
    }
}
