using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CourseAssignToTeacherController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;

        public CourseAssignToTeacherController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.courseAssignToTeacher.GetAllAsync();
            return Ok(_data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CourseAssignTeacherDto courseAT)
        {
            var newCAT = _mapper.Map<CourseAssignTeacher>(courseAT);
           
            var _data = await unitofWork.courseAssignToTeacher.AddCourseAssign(newCAT);
            await _db.SaveChangesAsync();
            return Ok(_data);
        }

        [HttpGet("unassign")]
        public async Task<IActionResult> UnAssignCourse()
        {
           
            var _data = await unitofWork.courseAssignToTeacher.UnassignCourse();
            return Ok(_data);
        }
    }
}
