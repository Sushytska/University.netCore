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
    public class StudentManager: IManager<StudentDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;

        public StudentManager(IUnitOfWork unitOfWork, IValidator validator,IMapper mapper)
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

        public void Create(StudentDTO item)
        {
           // _validator.Validate(item);
            _unitOfWork.Students.Create(_mapper.Map<Student>(item));
            _unitOfWork.Save();
        }

        public void Update(StudentDTO item)
        {
            //_validator.Validate(item);
            _unitOfWork.Students.Update(_mapper.Map<Student>(item));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            ValidateId(id);
            _unitOfWork.Students.Delete(id);
            _unitOfWork.Save();
        }

        public StudentDTO GetById(int id)
        {
            ValidateId(id);
            return _mapper.Map<StudentDTO>(_unitOfWork.Students.Get(id));
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            return _unitOfWork.Students.GetAll().ToList().Select(_mapper.Map<StudentDTO>).ToList();
        }
    }
}