using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollCourseController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;

        public EnrollCourseController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }


        [HttpPost("enroll")]
        public async Task<IActionResult> enroll(EnrollCourseDto enroll)
        {
            var newEnroll = _mapper.Map<EnrollCourse>(enroll);
            var _data = await unitofWork.enrollCourse.EnrollCourse(newEnroll);
            await _db.SaveChangesAsync();
            return Ok(_data);
        }
    }

    

}
