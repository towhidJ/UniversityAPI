using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;
        public TeacherController(IUnitOfWork work, StudentDB db, IMapper mapper)
        {
            _db = db;
            unitofWork = work;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.teachers.GetAllAsync();
            // var _data = _db.StudentTb.Include(c => c.DepartmentTB).ToListAsync();
            return Ok(_data);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _data = await unitofWork.teachers.GetAsync(id);
            return Ok(_data);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(TeacherDto teacher)
        {
            var newTeacher = _mapper.Map<Teacher>(teacher);
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
            
            var _data = await unitofWork.teachers.AddEntity(newTeacher);
            await _db.SaveChangesAsync();
            return Ok(_data);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(TeacherDto teacher)
        {
            var modifiedTeacher = _mapper.Map<Teacher>(teacher);
            var _data = await unitofWork.teachers.UpdateEntity(modifiedTeacher);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var _data = await this.unitofWork.teachers.DeleteEntity(id);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }
    }
}
