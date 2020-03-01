using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using Entities.DTOModels;
using Entities.Models;

namespace BLL.Managers
{
    public class GroupManager: IManager<GroupDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;

        public GroupManager(IUnitOfWork unitOfWork, IValidator validator,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        private void ValidateId(int id)
        {
            if (id < 1)
                throw new ArgumentException("Id must be positive number");
        }

        public void Create(GroupDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Groups.Create(_mapper.Map<Group>(item));
            _unitOfWork.Save();
        }

        public void Update(GroupDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Groups.Update(_mapper.Map<Group>(item));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            ValidateId(id);
            _unitOfWork.Groups.Delete(id);
            _unitOfWork.Save();
        }

        public GroupDTO GetById(int id)
        {
            ValidateId(id);
            return _mapper.Map<GroupDTO>(_unitOfWork.Groups.Get(id));
        }

        public IEnumerable<GroupDTO> GetAll()
        {
            return _unitOfWork.Groups.GetAll().ToList().Select(_mapper.Map<GroupDTO>).ToList();
        }
    }
}