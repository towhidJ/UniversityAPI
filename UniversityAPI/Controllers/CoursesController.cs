using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.courses.GetAllAsync();
            return Ok(_data);
        }
        [HttpPost("create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CourseDto course)
        {
            var newCourse = _mapper.Map<Course>(course);
            var cc =  unitofWork.courses.UniqueCourseCode(course.CourseCode);
            var cn = unitofWork.courses.UniqueCourseName(course.CourseName);
            if (cc)
            {
                return BadRequest("Course Code Already Added");
            }

            if (cn)
            {
                return BadRequest("Course Name Already Added");

            }
            var _data = await unitofWork.courses.AddEntity(newCourse);
            await _db.SaveChangesAsync();
            return Ok(_data);
        }
        [HttpPut("update")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(CourseDto courseDto)
        {
            var modifiedCourse = _mapper.Map<Course>(courseDto);
            var course = await unitofWork.courses.GetAsync(courseDto.Id);
            bool cc=false, cn=false;
            if (course.CourseCode!=courseDto.CourseCode)
            {
             cc = unitofWork.courses.UniqueCourseCode(courseDto.CourseCode);

            }
            if (course.CourseName != courseDto.CourseName)
            {
                 cn = unitofWork.courses.UniqueCourseName(courseDto.CourseName);
            }
            if (cc)
            {
                return BadRequest("Course Code Already Added");
            }

            if (cn)
            {
                return BadRequest("Course Name Already Added");

            }
            var _data = await unitofWork.courses.UpdateEntity(modifiedCourse);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }
        [HttpDelete("remove/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var _data = await this.unitofWork.courses.DeleteEntity(id);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }

        [HttpGet("getByDepId")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetCourseByDepartmentId(int departmentId)
        {

            var course = unitofWork.courses.GetCourseByDepartmentId(departmentId);

            return Ok(course);
        }

        [HttpGet("getbyid/{id}")]
        [Authorize(Roles = "admin")]
        public  async Task<IActionResult> getById(int id)
        {

            var course = await unitofWork.courses.GetAsync(id);

            return Ok(course);
        }
    }
}
