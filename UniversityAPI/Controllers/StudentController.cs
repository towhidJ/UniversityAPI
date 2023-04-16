using System.Diagnostics.Tracing;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;
        public StudentController(IUnitOfWork work,StudentDB db,IMapper mapper)
        {
            _db=db;
            unitofWork = work;
            _mapper=mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.students.GetAllAsync();
            // var _data = _db.StudentTb.Include(c => c.DepartmentTB).ToListAsync();
            return Ok(_data);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _data = await unitofWork.students.GetAsync(id);
            return Ok(_data);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(StudentDto student)
        {
            var newStudent = _mapper.Map<StudentTB>(student);
            var em = uniqueEmail(student.Email);
            var ph = uniquePhone(student.ContactNo);
            if (ph)
            {
                return BadRequest("Phone Is Already Added");
            }

            if (em)
            {
                return BadRequest("Email Is Already Added");

            }
            newStudent.RegistrationNo = registrationNumber(student.DepartmentId, student.RegisterDate);
            var _data = await unitofWork.students.AddEntity(newStudent);
            await _db.SaveChangesAsync();
            return Ok("Student Add Success Full");
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(StudentDto student)
        {
            var modifiedStudent = _mapper.Map<StudentTB>(student);
            var _data = await unitofWork.students.UpdateEntity(modifiedStudent);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }
        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var _data = await this.unitofWork.students.DeleteEntity(id);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }

        [NonAction]
        public string registrationNumber(int departmentId, DateTime registerdate)
        {
            string departmentCode = _db.DepartmentTb.Single(x => x.Id == departmentId).DepartmentCode;
            int year = registerdate.Year;

            int num = 0;
            int count = _db.StudentTb.Count(x => x.DepartmentId == departmentId);
            count = count + 1;
            string countString = count.ToString();
            if (countString.Length == 1)
            {
                string newNumber = "00" + countString;
                string RegistrationNo = departmentCode + "-" + year.ToString() + "-" + newNumber;
                return RegistrationNo;
            }
            else if (countString.Length == 2)
            {
                string newNumber = "0" + countString;
                string RegistrationNo = departmentCode + "-" + year.ToString() + "-" + newNumber;
                return RegistrationNo;
            }
            else
            {
                string newNumber = countString;
                string RegistrationNo = departmentCode + "-" + year.ToString() + "-" + newNumber;
                return RegistrationNo;
            }
        }
        [NonAction]
        public bool uniqueEmail(string email)
        {
            var em = _db.StudentTb.FirstOrDefault(x => x.Email == email);
            if (em!=null)
            {
                return true;
            }

            return false;
        }
        [NonAction]
        public bool uniquePhone(string phone)
        {
            var em = _db.StudentTb.FirstOrDefault(x => x.ContactNo == phone);
            if (em != null)
            {
                return true;
            }

            return false;
        }


    }
}
