using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;
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
            // var em = uniqueEmail(student.Email);
            // var ph = uniquePhone(student.ContactNo);
            // if (ph)
            // {
            //     return BadRequest("Phone Is Already Added");
            // }
            //
            // if (em)
            // {
            //     return BadRequest("Email Is Already Added");
            //
            // }
            // newStudent.RegistrationNo = registrationNumber(student.DepartmentId, student.RegisterDate);
            var _data = await unitofWork.courses.AddEntity(newCourse);
            await _db.SaveChangesAsync();
            return Ok("Course Add Successfull");
        }
    }
}
