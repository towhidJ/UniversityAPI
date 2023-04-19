using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;
using UniversityAPI.Repository;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;

        public CoursesController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.courses.GetAllAsync();
            return Ok(_data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CourseDto course)
        {
            var newCourse = _mapper.Map<Course>(course);
            var _data = await unitofWork.courses.AddEntity(newCourse);
            await _db.SaveChangesAsync();
            return Ok("Course Add Successfull");
        }

        [HttpGet("getByDepId")]
        public async Task<IActionResult> GetCourseByDepartmentId(int departmentId)
        { 

            // var course = (from c in _db.CourseTb
            //     join ca in _db.CourseAssignTb 
            //         on c.Id equals ca.CourseId 
            //     join t in _db.TeacherTb 
            //         on ca.TeacherId equals t.Id
            //     join dep in _db.DepartmentTb 
            //     on c.DepartmentId equals dep.Id
            //     where c.DepartmentId == departmentId
            //     
            //     select new CourseShowView()
            //     {
            //         DepartmentCode = dep.DepartmentCode,
            //         CourseCode = c.CourseCode,
            //         CourseName = c.CourseName,
            //         TeacherName = (t.TeacherName == null) ? "Not Assign" : t.TeacherName,
            //     }).ToList();

            var course = (from c in _db.CourseTb
                join ca in _db.CourseAssignTb on c.Id equals ca.CourseId into caa
                from ctl in caa.DefaultIfEmpty()
                join t in _db.TeacherTb on ctl.TeacherId equals t.Id into ta
                from taa in ta.DefaultIfEmpty()
                join dep in _db.DepartmentTb on c.DepartmentId equals dep.Id
                where dep.Id == departmentId
                select new CourseShowView()
            {
                    CourseCode = c.CourseCode,
                    CourseName = c.CourseName,
                    DepartmentCode = dep.DepartmentCode,
                    TeacherName = taa.TeacherName==null?"Not Assign":taa.TeacherName
                    
            }).ToList();

            return Ok(course);
        }
    }
}
