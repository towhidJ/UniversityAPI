using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentResultController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;

        public StudentResultController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }

        [HttpPost("result")]
        public async Task<IActionResult> AddResult(StudentResultDto studentResultDto)
        {
            var newStudentResult = _mapper.Map<StudentResult>(studentResultDto);
            var _data = await unitofWork.studentResult.AddResult(newStudentResult);
            await _db.SaveChangesAsync();
            return Ok(_data);
        }

        [HttpGet("getBystudentId")]
        public async Task<IActionResult> RegistrationNo(int studentId)
        {
            var AllStudentView = unitofWork.enrollCourse.GetStudentByEnrollCourse(studentId);
            return Ok(AllStudentView);
        }
        [HttpGet("getCourseByReg")]
        public async Task<IActionResult> CourseByRegistrationNo(int studentId)
        {
            List<Course> AllCourseView = unitofWork.enrollCourse.GetCourseByEnrollCourse(studentId);
            return Ok(AllCourseView);
        }

        [HttpGet("result")]
        public async Task<IActionResult> ShowResult(int studentId)
        {
            var result = unitofWork.studentResult.GetAllStudentResults(studentId);
            return Ok(result);
        }
    }
}
