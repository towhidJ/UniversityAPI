using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class RoomController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;

        public RoomController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var res = await unitofWork.room.GetAllAsync();
            return Ok(res);
        }
    }
}
