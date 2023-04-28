using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesinationController : ControllerBase
    {
        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;

        public DesinationController(IUnitOfWork unitofWork, StudentDB db)
        {
            this.unitofWork = unitofWork;
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.designation.GetAllAsync();
            return Ok(_data);
        }
    }
}
