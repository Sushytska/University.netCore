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
    public class DepartmentManager: IManager<DepartmentDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;
        
        public DepartmentManager(IUnitOfWork unitOfWork, IValidator validator,IMapper mapper)
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

        public void Create(DepartmentDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Departments.Create(_mapper.Map<Department>(item));
            _unitOfWork.Save();
        }

        public void Update(DepartmentDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Departments.Update(_mapper.Map<Department>(item));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            ValidateId(id);
            _unitOfWork.Departments.Delete(id);
            _unitOfWork.Save();
        }

        public DepartmentDTO GetById(int id)
        {
            ValidateId(id);
            return _mapper.Map<DepartmentDTO>(_unitOfWork.Departments.Get(id));
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            return _unitOfWork.Departments.GetAll().ToList().Select(_mapper.Map<DepartmentDTO>).ToList();
        }
    }
}