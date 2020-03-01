using System;
using System.Collections.Generic;
using Entities.DataContext;
using Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FacultyRepository : IRepository<Faculty>
    {
        private readonly UniversityContext db;
 
        public FacultyRepository(UniversityContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Faculty> GetAll()
        {
            return db.Faculties;
        }
 
        public Faculty Get(int id)
        {
            return db.Faculties.Find(id);
        }
 
        public void Create(Faculty faculty)
        {
            db.Faculties.Add(faculty);
        }
 
        // public void Update(Faculty faculty)
        // {
        //     db.Entry(faculty).State = EntityState.Modified;
        // }
        public void Update(Faculty faculty)
        {
            db.Faculties.Update(faculty);
        }
 
        public void Delete(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty != null)
                db.Faculties.Remove(faculty);
        }
        
        
       
    }
}