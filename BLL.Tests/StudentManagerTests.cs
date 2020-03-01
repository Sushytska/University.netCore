using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Managers;
using DAL.Interfaces;
using Entities.DTOModels;
using Entities.Models;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace BLL.Tests
{
    public class StudentManagerTests
    {
        [Fact]
        public void GetAllReturnsAViewResultWithAListOfStudents()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Students.GetAll()).Returns(GetAllTestStudentDTO());
            var manager = new StudentManager(mock.Object, new AttributeValidator(), new Mapper(config));
            
            // Act
            var result = manager.GetAll();
            
            // Assert
            var viewResult = Assert.IsType<List<StudentDTO>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StudentDTO>>(viewResult);
            Assert.Equal(GetAllTestStudentDTO().Count, model.Count());
        }
        private List<Student> GetAllTestStudentDTO()
        {
            var students = new List<Student>
            {
                new Student{ Id = 1, FirstName = "firstname", LastName ="lastname", Address = "address", Phone = "phone", GroupId = 1, DateOfBirth = new DateTime(12/12/1998)},
                new Student{ Id = 2, FirstName = "firstname", LastName ="lastname", Address = "address", Phone = "phone", GroupId = 2, DateOfBirth = new DateTime(12/12/1998)},
                new Student{ Id = 3, FirstName = "firstname", LastName ="lastname", Address = "address", Phone = "phone", GroupId = 3, DateOfBirth = new DateTime(12/12/1998)}
            };
            return students;
        }
        [Fact]
        public void GetByIdSpeciality()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Students.Get(1)).Returns(GetByIdTestStudentDTO());
            var manager = new StudentManager(mock.Object, new AttributeValidator(), new Mapper(config));
        
            // Act
            var result = manager.GetById(1);
        
            // Arrange
            var viewResult = Assert.IsType<StudentDTO>(result);
            var model = Assert.IsAssignableFrom<StudentDTO>(viewResult);
            Assert.Equal(GetByIdTestStudentDTO().Id, model.Id);
        }
        private Student GetByIdTestStudentDTO()
        {
            var student = new Student { Id = 3, FirstName = "firstname", LastName ="lastname", Address = "address", Phone = "phone", GroupId = 3, DateOfBirth = new DateTime(12/12/1998)};
            return student;
        }
        
       

       
    }
}