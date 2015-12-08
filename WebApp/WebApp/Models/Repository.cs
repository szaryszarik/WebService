using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Models
{
    public class Repository<T, T2> : IRepository<T, T2>
        where T2 : class
        where T : class
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
        
        public void Update(int Id, Employee employee)
        {
            var temp = db.Employees.Find(Id);
            if(temp == null) { return; }
            temp.LastName = employee.LastName;
            temp.Name = employee.Name;
            db.SaveChanges();
        }

        public bool EmployeeExists(int id)
        {
            return db.Employees.Any(e => e.EmployeeId == id);
        }

        public void Update(int Id, WorkNote workNote)
        {
            db.Entry(workNote).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool WorkNoteExists(int id)
        {
            return db.WorkNotes.Any(e => e.WorkNoteId == id);
        }
    }
}