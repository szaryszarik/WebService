using System.Collections.Generic;

namespace WebApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        //Navigation Property
        public ICollection<WorkNote> WorkNotes { get; set; }
    }
}