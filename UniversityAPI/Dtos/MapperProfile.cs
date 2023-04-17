using AutoMapper;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentDto, StudentTB>();
            CreateMap<DepartmentDto, DepartmentTB>();
            CreateMap<CourseDto, Course>();
        }
    }
}
