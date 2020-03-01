using System;
using System.Collections.Generic;
using Entities.DataContext;
using Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly UniversityContext db;
 
        public StudentRepository(UniversityContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Student> GetAll()
        {
            return db.Students;
        }
 
        public Student Get(int id)
        {
            return db.Students.Find(id);
        }
 
        public void Create(Student student)
        {
            db.Students.Add(student);
        }
 
        public void Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
        }
 
        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
                db.Students.Remove(student);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        
        private bool disposed = false;
 
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}