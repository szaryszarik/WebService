using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    class EmployersDetailsDto : INotifyPropertyChanged
    {
        public int EmployersDetailsDtoId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<WorkNote> WorkNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
