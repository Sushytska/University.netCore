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
    public class FacultyManagerTests
    {
        [Fact]
        public void GetAllReturnsAViewResultWithAListOfFaculties()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Faculty, FacultyDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Faculties.GetAll()).Returns(GetAllTestFacultyDTO);
            var manager = new FacultyManager(mock.Object, new AttributeValidator(), new Mapper(config));
            
            // Act
            var result = manager.GetAll();
            
            // Assert
            var viewResult = Assert.IsType<List<FacultyDTO>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FacultyDTO>>(viewResult);
            Assert.Equal(GetAllTestFacultyDTO().Count, model.Count());
        }
        private List<Faculty> GetAllTestFacultyDTO()
        {
            var faculties = new List<Faculty>
            {
                new Faculty{ Id = 1, NameOfFaculty = "faculty"},
                new Faculty{ Id = 2, NameOfFaculty = "faculty"},
                new Faculty{ Id = 3, NameOfFaculty = "faculty"}
            };
            return faculties;
        }
        [Fact]
        public void GetByIdFaculty()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Faculty, FacultyDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Faculties.Get(1)).Returns(GetByIdTestFacultyDTO());
            var manager = new FacultyManager(mock.Object, new AttributeValidator(), new Mapper(config));
        
            // Act
            var result = manager.GetById(1);
        
            // Arrange
            var viewResult = Assert.IsType<FacultyDTO>(result);
            var model = Assert.IsAssignableFrom<FacultyDTO>(viewResult);
            Assert.Equal(GetByIdTestFacultyDTO().Id, model.Id);
        }
        private Faculty GetByIdTestFacultyDTO()
        {
            var faculty = new Faculty {Id = 1, NameOfFaculty = "faculty"};
            return faculty;
        }
        
       

       
    }
}