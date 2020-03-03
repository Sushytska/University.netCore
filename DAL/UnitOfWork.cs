using System;
using Entities.DataContext;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        //private static DbContextOptions<UniversityContext> options;
        private UniversityContext db = new UniversityContext(UniversityContext.ops.dbOptions);
        private DepartmentRepository departmentRepository;
        private FacultyRepository facultyRepository;
        private GroupRepository groupRepository;
        private SpecialityRepository specialityRepository;
        private StudentRepository studentRepository;
        //private UniversityContext db;
         // public UnitOfWork(DbContextOptions<UniversityContext> options)
         // {
         //     db = new UniversityContext(options);
         // }
        public UnitOfWork(){ }
        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(db);
                return departmentRepository;
            }
        }
    
        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRepository == null)
                    facultyRepository = new FacultyRepository(db);
                return facultyRepository;
            }
        }
        
        
        public IRepository<Group> Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(db);
                return groupRepository;
            }
        }
        
        public IRepository<Speciality> Specialities
        {
            get
            {
                if (specialityRepository == null)
                    specialityRepository = new SpecialityRepository(db);
                return specialityRepository;
            }
        }
        
        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);
                return studentRepository;
            }
        }
    
        public int Save()
        {
            return db.SaveChanges();
        }
    
        private bool disposed = false;
    
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}



//      private readonly UniversityContext _dbContext;
    //
    //     private IRepository<Department> _departmentRepository;
    //     private IRepository<Faculty> _facultyRepository;
    //     private IRepository<Group> _groupRepository;
    //     private IRepository<Speciality> _specialityrepository;
    //     private IRepository<Student> _studentRepository;
    //
    //     public UnitOfWork()
    //     {
    //         _dbContext = new UniversityContext(UniversityContext.ops.dbOptions);
    //         _departmentRepository = new DepartmentRepository(_dbContext);
    //         _facultyRepository = new FacultyRepository(_dbContext);
    //         _groupRepository = new GroupRepository(_dbContext);
    //         _specialityrepository = new SpecialityRepository(_dbContext);
    //         _studentRepository = new StudentRepository(_dbContext);
    //     }
    //
    //     public IRepository<Department> DepartmentRepository
    //     {
    //         get
    //         {
    //             if (_departmentRepository != null) _departmentRepository = new DepartmentRepository(_dbContext);
    //             return _departmentRepository;
    //         }
    //     }
    //
    //     public IRepository<Faculty> FacultyRepository
    //     {
    //         get
    //         {
    //             if (_facultyRepository != null) _facultyRepository = new FacultyRepository(_dbContext);
    //             return _facultyRepository;
    //         }
    //     }
    //
    //     public IRepository<Group> GroupRepository
    //     {
    //         get
    //         {
    //             if (_groupRepository != null) _groupRepository = new GroupRepository(_dbContext);
    //             return _groupRepository;
    //         }
    //     }
    //
    //     public IRepository<Speciality> SpecialityRepository
    //     {
    //         get
    //         {
    //             if (_specialityrepository != null) _specialityrepository = new SpecialityRepository(_dbContext);
    //             return _specialityrepository;
    //         }
    //     }
    //     public IRepository<Student> StudentRepository
    //     {
    //         get
    //         {
    //             if (_studentRepository!= null) _studentRepository = new StudentRepository(_dbContext);
    //             return _studentRepository;
    //         }
    //     }
    //
    //     private bool _disposed;
    //
    //     public virtual void Dispose(bool disposing)
    //     {
    //         if (!_disposed)
    //         {
    //             if (disposing)
    //             {
    //                 _dbContext.Dispose();
    //             }
    //             _disposed = true;
    //         }
    //     }
    //
    //     public void Dispose()
    //     {
    //         Dispose(true);
    //         GC.SuppressFinalize(this);
    //     }
    //
    //     public void Save()
    //     { 
    //         _dbContext.SaveChanges();
    //     }
    // }