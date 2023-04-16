using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;

        public DepartmentController(IUnitOfWork unitofWork, StudentDB db)
        {
            this.unitofWork = unitofWork;
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.departments.GetAllAsync();
            return Ok(_data);
        }
    }
}
