using System.Collections.Generic;
using System.ComponentModel;

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
