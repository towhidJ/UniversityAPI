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
    public class ClassScheduleController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;

        public ClassScheduleController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int depId)
        {
            var result = await unitofWork.classSchedule.GetSchedule(depId);
            return Ok(result);
        }

        [HttpPost("addclass")]
        public async Task<IActionResult> AddClass(AllocateClassDto classSchedule)
        {
            var newClass = _mapper.Map<AllocateClass>(classSchedule);
            var res = await unitofWork.classSchedule.AddClassSchedule(newClass);
            await unitofWork.SaveAsync();
            return Ok(res);
        }

        [HttpGet("unallocatedClass")]
        public async Task<IActionResult> UnAllocatedClass()
        {
            var res = await unitofWork.classSchedule.UnallocatedRoom();
            return Ok(res);
        }


    }
}
