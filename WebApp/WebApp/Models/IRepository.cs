using System.Collections.Generic;

namespace WebApp.Models
{
    interface IRepository<T, T2>
    {
        List<T> Get();
        T Get(int Id);
        void Add(T src);
        void Remove(int Id);
        void Edit(int id, T obj);
    }
}
