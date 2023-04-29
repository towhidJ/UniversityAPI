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
    public class DepartmentController : ControllerBase
    {

        public readonly IUnitOfWork unitofWork;
        private readonly StudentDB _db;
        private readonly IMapper _mapper;


        public DepartmentController(IUnitOfWork unitofWork, StudentDB db, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _data = await unitofWork.departments.GetAllAsync();
            return Ok(_data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(DepartmentDto dep)
        {
            var newDep = _mapper.Map<DepartmentTB>(dep);

            var dc = unitofWork.departments.UniqueDepartmentCode(dep.DepartmentCode);
            var dn = unitofWork.departments.UniqueDepartmentName(dep.DepartmentName);
            if (dc)
            {
                return BadRequest("Department Code Already Added");
            }

            if (dn)
            {
                return BadRequest("Department Name Already Added");

            }

            var _data = await unitofWork.departments.AddEntity(newDep);
            await _db.SaveChangesAsync();
            return Ok(_data);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DepartmentDto dep)
        {
            var modifiedDepartment = _mapper.Map<DepartmentTB>(dep);
            var department = await unitofWork.departments.GetAsync(dep.Id);

            bool dc = false, dn = false;
            if (dep.DepartmentCode != department.DepartmentCode)
            {
                 dc = unitofWork.departments.UniqueDepartmentCode(dep.DepartmentCode);


            }
            if (department.DepartmentName != dep.DepartmentCode)
            {
                 dn = unitofWork.departments.UniqueDepartmentName(dep.DepartmentName);
                
            }
            if (dc)
            {
                return BadRequest("Department Code Already Added");
            }

            if (dn)
            {
                return BadRequest("Department Name Already Added");

            }
            var _data = await unitofWork.departments.UpdateEntity(modifiedDepartment);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> getById(int id)
        {

            var department = await unitofWork.departments.GetAsync(id);

            return Ok(department);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            var _data = await this.unitofWork.students.DeleteEntity(id);
            await this.unitofWork.SaveAsync();
            return Ok(_data);
        }

    }
}
