using AutoMapper;
using Entities.DTOModels;
using Entities.Models;

namespace WebApp
{
    public class Mapping : Profile
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentDTO, Department>();
                cfg.CreateMap<Department, DepartmentDTO>()
                    .ForMember(x => x.Id, y => y.MapFrom(t => t.Id))
                    .ForMember(x => x.NameOfDepartment, y => y.MapFrom(t => t.NameOfDepartment))
                    .ForMember(x => x.FacultyId, y => y.MapFrom(t => t.FacultyId));

                cfg.CreateMap<FacultyDTO, Faculty>();
                cfg.CreateMap<Faculty, FacultyDTO>()
                    .ForMember(x => x.Id, y => y.MapFrom(t => t.Id))
                    .ForMember(x => x.NameOfFaculty, y => y.MapFrom(t => t.NameOfFaculty));

                cfg.CreateMap<GroupDTO, Group>();
                cfg.CreateMap<Group, GroupDTO>()
                    .ForMember(x => x.Id, y => y.MapFrom(t => t.Id))
                    .ForMember(x => x.NameOfGroup, y => y.MapFrom(t => t.NameOfGroup))
                    .ForMember(x => x.SpecialityId, y => y.MapFrom(t => t.SpecialityId));

                cfg.CreateMap<SpecialityDTO, Speciality>();
                cfg.CreateMap<Speciality, SpecialityDTO>()
                    .ForMember(x => x.Id, y => y.MapFrom(t => t.Id))
                    .ForMember(x => x.NameOfSpeciality, y => y.MapFrom(t => t.NameOfSpeciality))
                    .ForMember(x => x.DepartmentId, y => y.MapFrom(t => t.DepartmentId));
                cfg.CreateMap<StudentDTO, Student>();
                cfg.CreateMap<Student, StudentDTO>()
                    .ForMember(x => x.Id, y => y.MapFrom(t => t.Id))
                    .ForMember(x => x.FirstName, y => y.MapFrom(t => t.FirstName))
                    .ForMember(x => x.LastName, y => y.MapFrom(t => t.LastName))
                    .ForMember(x => x.Address, y => y.MapFrom(t => t.Address))
                    .ForMember(x => x.Phone, y => y.MapFrom(t => t.Phone))
                    .ForMember(x => x.DateOfBirth, y => y.MapFrom(t => t.DateOfBirth))
                    .ForMember(x => x.GroupId, y => y.MapFrom(t => t.GroupId));
            });
            return config;
        }
    }
}