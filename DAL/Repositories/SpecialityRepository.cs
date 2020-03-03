using System;
using System.Collections.Generic;
using Entities.DataContext;
using Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SpecialityRepository : IRepository<Speciality>
    {
        private readonly UniversityContext db;
 
        public SpecialityRepository(UniversityContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Speciality> GetAll()
        {
            return db.Specialities;
        }
 
        public Speciality Get(int id)
        {
            return db.Specialities.Find(id);
        }
 
        public void Create(Speciality speciality)
        {
            db.Specialities.Add(speciality);
        }
 
        public void Update(Speciality speciality)
        {
            db.Entry(speciality).State = EntityState.Modified;
        }
 
        public void Delete(int id)
        {
            Speciality speciality = db.Specialities.Find(id);
            if (speciality != null)
                db.Specialities.Remove(speciality);
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