using System.Collections.Generic;
using Entities.DataContext;
using Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private UniversityContext db;

        public DepartmentRepository(UniversityContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }
 
        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }
 
        public void Create(Department department)
        {
            db.Departments.Add(department);
        }
 
        public void Update(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
        }
 
        public void Delete(int id)
        {
            Department department = db.Departments.Find(id);
            if (department != null)
                db.Departments.Remove(department);
        }
       
        
        
    }

}