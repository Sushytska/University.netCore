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
    public class SpecialityManagerTests
    {
        [Fact]
        public void GetAllReturnsAViewResultWithAListOfSpecialities()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Speciality, SpecialityDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Specialities.GetAll()).Returns(GetAllTestSpecialityDTO());
            var manager = new SpecialityManager(mock.Object, new AttributeValidator(), new Mapper(config));
            
            // Act
            var result = manager.GetAll();
            
            // Assert
            var viewResult = Assert.IsType<List<SpecialityDTO>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<SpecialityDTO>>(viewResult);
            Assert.Equal(GetAllTestSpecialityDTO().Count, model.Count());
        }
        private List<Speciality> GetAllTestSpecialityDTO()
        {
            var specialities = new List<Speciality>
            {
                new Speciality{ Id = 1, NameOfSpeciality = "nameofspeciality", DepartmentId = 1},
                new Speciality{ Id = 2, NameOfSpeciality = "nameofspeciality", DepartmentId = 2},
                new Speciality{ Id = 3, NameOfSpeciality = "nameofspeciality", DepartmentId = 3}
            };
            return specialities;
        }
        [Fact]
        public void GetByIdSpeciality()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Speciality, SpecialityDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Specialities.Get(1)).Returns(GetByIdTestSpecialityDTO());
            var manager = new SpecialityManager(mock.Object, new AttributeValidator(), new Mapper(config));
        
            // Act
            var result = manager.GetById(1);
        
            // Arrange
            var viewResult = Assert.IsType<SpecialityDTO>(result);
            var model = Assert.IsAssignableFrom<SpecialityDTO>(viewResult);
            Assert.Equal(GetByIdTestSpecialityDTO().Id, model.Id);
        }
        private Speciality GetByIdTestSpecialityDTO()
        {
            var Speciality = new Speciality {Id = 1, NameOfSpeciality = "Speciality", DepartmentId = 1};
            return Speciality;
        }
        
       

       
    }
}