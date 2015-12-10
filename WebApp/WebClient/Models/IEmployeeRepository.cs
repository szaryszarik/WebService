using System.ComponentModel;
using System.Threading.Tasks;

namespace WebClient.Models
{
    interface IEmployeeRepository
    {
        Task<BindingList<EmployersDetailsDto>> get();
        Task get(int id);
        Task add(string name, string lastName);
        Task remove(int id);
        Task edit(int id, string name, string lastName);
    }
}
