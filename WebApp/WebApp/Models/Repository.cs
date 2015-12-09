using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApp.Models
{
    public class Repository<T, T2> : IRepository<T, T2>
        where T2 : class
        where T : class
    {
        DbSet<T2> dSet;
        WebAppContext db;

        public Repository()
        {
            db = new WebAppContext();
            dSet = db.Set<T2>();
        }

        public void add(T2 src)
        {
            dSet.Add(src);
            db.SaveChanges();
        }

        public List<T> get()
        {
            var src = dSet.ToList();
            return Mapper.Map<List<T>>(src);
        }

        public T get(int Id)
        {
            var src = dSet.Find(Id);
            return Mapper.Map<T>(src);
        }

        public void remove(int Id)
        {
            T2 temp = dSet.Find(Id);
            if(temp != null)
            {
                dSet.Remove(temp);
                db.SaveChanges();
            }
        }
    }
}