using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Managers;
using DAL.Interfaces;
using Entities.DTOModels;
using Entities.Models;
using Moq;
//using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;
using NUnit.Framework.Constraints;


namespace BLL.Tests
{
    public class DepartmentManagerTests
    {
        [Fact]
        public void GetAllReturnsAViewResultWithAListOfDepartments()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Departments.GetAll()).Returns(GetAllTestDepartmentDTO());
            var manager = new DepartmentManager(mock.Object, new AttributeValidator(), new Mapper(config));
            DepartmentDTO departmentDto = new DepartmentDTO();
            
            // Act
            var result = manager.GetAll();
            
            // Assert
            var viewResult = Assert.IsType<List<DepartmentDTO>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<DepartmentDTO>>(viewResult);
            Assert.Equal(GetAllTestDepartmentDTO().Count, model.Count());
        }
        private List<Department> GetAllTestDepartmentDTO()
        {
            var departments = new List<Department>
            {
                new Department{ Id = 1, NameOfDepartment = "department", FacultyId = 1},
                new Department{ Id = 2, NameOfDepartment = "department", FacultyId = 2},
                new Department{ Id = 3, NameOfDepartment = "department", FacultyId = 3}
            };
            return departments;
        }
        // [Fact]
        // public void GetByIdDepartment()
        // {
        //     // Arrange
        //     var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>());
        //     var mock = new Mock<IUnitOfWork>();
        //     mock.Setup(unitOfWork => unitOfWork.Departments.Get(1)).Returns(GetByIdTestDepartmentDTO()[0]);
        //     var manager = new DepartmentManager(mock.Object, new AttributeValidator(), new Mapper(config));
        //
        //     // Act
        //     var result = manager.GetById(1);
        //
        //     // Arrange
        //     var viewResult = Assert.IsType<List<DepartmentDTO>>(result);
        //     var model = Assert.IsAssignableFrom<List<DepartmentDTO>>(viewResult);
        //     Assert.Equal(GetByIdTestDepartmentDTO()[0].Id, model[0].Id);
        // }
        // private List<Department> GetByIdTestDepartmentDTO()
        // {
        //     var departments = new List<Department>
        //     {
        //         new Department {Id = 1, NameOfDepartment = "department", FacultyId = 1},
        //         new Department {Id = 2, NameOfDepartment = "department", FacultyId = 1}
        //     };
        //     return departments;
        // }
        [Fact]
         public void GetByIdDepartment()
         {
             // Arrange
             var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>());
             var mock = new Mock<IUnitOfWork>();
             mock.Setup(unitOfWork => unitOfWork.Departments.Get(1)).Returns(GetByIdTestDepartmentDTO());
             var manager = new DepartmentManager(mock.Object, new AttributeValidator(), new Mapper(config));
        
             // Act
             var result = manager.GetById(1);
        
             // Arrange
             var viewResult = Assert.IsType<DepartmentDTO>(result);
             var model = Assert.IsAssignableFrom<DepartmentDTO>(viewResult);
             Assert.Equal(GetByIdTestDepartmentDTO().Id, model.Id);
         }
         private Department GetByIdTestDepartmentDTO()
         {
             var departments = new Department {Id = 1, NameOfDepartment = "department", FacultyId = 1};
             return departments;
         }
       
        [Fact]
        public void GetByIdDepartmentNotFound()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Departments.Get(3)).Returns(null as Department);
            var manager = new DepartmentManager(mock.Object, new AttributeValidator(), new Mapper(config));
        
            // Act
            var result = manager.GetById(3);
        
            // Arrange
            Assert.Null(result);
        }
       
    }
}