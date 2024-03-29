﻿using AutoMapper;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentDto, StudentTB>();
            CreateMap<DepartmentDto, DepartmentTB>();
            CreateMap<DesignationDto, Designation>();
            CreateMap<CourseDto, Course>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<EnrollCourseDto, EnrollCourse>();
            CreateMap<StudentResultDto, StudentResult>();
            CreateMap<AllocateClassDto, AllocateClass>();
            CreateMap<CourseAssignTeacherDto,CourseAssignTeacher>()
                .ForMember(c=>c.Id,o=>o.MapFrom(x=>x.Id))

                .ForMember(c => c.DepartmentId, o => o.MapFrom(x => x.DepartmentId))

                .ForMember(c => c.CourseId, o => o.MapFrom(x => x.CourseId))

                .ForMember(c => c.TeacherId, o => o.MapFrom(x => x.TeacherId));
        }
    }
}
