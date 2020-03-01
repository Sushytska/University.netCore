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
    public class FacultyManager: IManager<FacultyDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;

        public FacultyManager(IUnitOfWork unitOfWork, IValidator validator,IMapper mapper)
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

        public void Create(FacultyDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Faculties.Create(_mapper.Map<Faculty>(item));
            _unitOfWork.Save();
        }

        public void Update(FacultyDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Faculties.Update(_mapper.Map<Faculty>(item));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            ValidateId(id);
            _unitOfWork.Faculties.Delete(id);
            _unitOfWork.Save();
        }

        public FacultyDTO GetById(int id)
        {
            ValidateId(id);
            return _mapper.Map<FacultyDTO>(_unitOfWork.Faculties.Get(id));
        }

        public IEnumerable<FacultyDTO> GetAll()
        {
            return _unitOfWork.Faculties.GetAll().ToList().Select(_mapper.Map<FacultyDTO>).ToList();
        }
    }
}