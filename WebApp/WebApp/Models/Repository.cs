using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Models
{
    // T2 == Employee, T == EmployersDetailsDto
    // T2 == WorkNote, T == WorkNotesDto
    public class Repository<T, T2> : IRepository<T, T2>
        where T2 : class
    {
        DbSet<T2> dSet;
        WebAppContext db;

        public Repository(DbSet<T2> dSet, WebAppContext db)
        {
            this.dSet = dSet;
            this.db = db;
        }

        public void Add(T2 src)
        {
            dSet.Add(src);
            db.SaveChanges();
        }

        public List<T> Get()
        {
            var src = dSet.ToList();
            return Mapper.Map<List<T>>(src);
        }

        public T Get(int Id)
        {
            var src = dSet.Find(Id);
            return Mapper.Map<T>(src);
        }

        public T2 Remove(int Id)
        {
            T2 temp = dSet.Find(Id);
            if(temp != null)
            {
                dSet.Remove(temp);
                db.SaveChanges();
                return temp;
            }
            return null;
        }

        public void Update(int Id, T2 src)
        {
            //db.Entry(employee).State = EntityState.Modified;
            //var emp = db.Employees.Single(e => e.EmployeeId == id);
            //db.SaveChanges();
            db.Entry(src).State = EntityState.Modified;
            var temp = dSet.Find(Id);
            db.SaveChanges();
        }
    }
}