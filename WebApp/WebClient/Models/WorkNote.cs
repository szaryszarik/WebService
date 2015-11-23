using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    class WorkNote
    {
        public int WorkNoteId { get; set; }
        public int EmployeeId { get; set; }

        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }

        //Navigation Propoerty
        public Employee Employee { get; set; }
    }
}
