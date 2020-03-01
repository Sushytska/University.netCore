using System;
using System.Collections.Generic;
using Entities.DataContext;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly UniversityContext db;
 
        public GroupRepository(UniversityContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Group> GetAll()
        {
            return db.Groups;
        }
 
        public Group Get(int id)
        {
            return db.Groups.Find(id);
        }
 
        public void Create(Group group)
        {
            db.Groups.Add(group);
        }
 
        public void Update(Group group)
        {
            db.Entry(group).State = EntityState.Modified;
        }
 
        public void Delete(int id)
        {
            Group group = db.Groups.Find(id);
            if (group != null)
                db.Groups.Remove(group);
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