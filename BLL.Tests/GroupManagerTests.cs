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
    public class GroupManagerTests
    {
        [Fact]
        public void GetAllReturnsAViewResultWithAListOfGroups()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Groups.GetAll()).Returns(GetAllTestGroupDTO());
            var manager = new GroupManager(mock.Object, new AttributeValidator(), new Mapper(config));
            
            // Act
            var result = manager.GetAll();
            
            // Assert
            var viewResult = Assert.IsType<List<GroupDTO>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<GroupDTO>>(viewResult);
            Assert.Equal(GetAllTestGroupDTO().Count, model.Count());
        }
        private List<Group> GetAllTestGroupDTO()
        {
            var groups = new List<Group>
            {
                new Group{ Id = 1, NameOfGroup = "nameofgroup", SpecialityId = 1},
                new Group{ Id = 2, NameOfGroup = "nameofgroup", SpecialityId = 2},
                new Group{ Id = 3, NameOfGroup = "nameofgroup", SpecialityId = 3}
            };
            return groups;
        }
        [Fact]
        public void GetByIdGroup()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(unitOfWork => unitOfWork.Groups.Get(1)).Returns(GetByIdTestGroupDTO());
            var manager = new GroupManager(mock.Object, new AttributeValidator(), new Mapper(config));
        
            // Act
            var result = manager.GetById(1);
        
            // Arrange
            var viewResult = Assert.IsType<GroupDTO>(result);
            var model = Assert.IsAssignableFrom<GroupDTO>(viewResult);
            Assert.Equal(GetByIdTestGroupDTO().Id, model.Id);
        }
        private Group GetByIdTestGroupDTO()
        {
            var Group = new Group {Id = 1, NameOfGroup = "Group", SpecialityId = 1};
            return Group;
        }
        
       

       
    }
}