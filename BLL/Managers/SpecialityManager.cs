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
    public class SpecialityManager: IManager<SpecialityDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;

        public SpecialityManager(IUnitOfWork unitOfWork, IValidator validator,IMapper mapper)
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

        public void Create(SpecialityDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Specialities.Create(_mapper.Map<Speciality>(item));
            _unitOfWork.Save();
        }

        public void Update(SpecialityDTO item)
        {
            _validator.Validate(item);
            _unitOfWork.Specialities.Update(_mapper.Map<Speciality>(item));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            ValidateId(id);
            _unitOfWork.Specialities.Delete(id);
            _unitOfWork.Save();
        }

        public SpecialityDTO GetById(int id)
        {
            ValidateId(id);
            return _mapper.Map<SpecialityDTO>(_unitOfWork.Specialities.Get(id));
        }

        public IEnumerable<SpecialityDTO> GetAll()
        {
            return _unitOfWork.Specialities.GetAll().ToList().Select(_mapper.Map<SpecialityDTO>).ToList();
        }
    }
}