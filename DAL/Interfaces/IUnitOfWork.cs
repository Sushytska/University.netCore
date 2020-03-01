using System;
using Entities.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Department> Departments { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Group> Groups { get; }
        IRepository<Speciality> Specialities { get; }
        IRepository<Student> Students { get; }
        void Dispose();
        int Save();
    }
}