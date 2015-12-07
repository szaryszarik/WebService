using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    interface IRepository<T, T2>
    {
        List<T> Get();
        T Get(int Id);
        void Add(T2 src);
        T2 Remove(int Id);
        void Update(int Id, T2 src);
    }
}
