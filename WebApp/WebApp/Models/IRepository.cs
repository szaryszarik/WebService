using System.Collections.Generic;

namespace WebApp.Models
{
    interface IRepository<T, T2>
    {
        List<T> get();
        T get(int Id);
        void add(T2 src);
        void remove(int Id);
    }
}
