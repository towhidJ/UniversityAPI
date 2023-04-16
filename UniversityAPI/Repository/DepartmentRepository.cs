using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class DepartmentRepository:GenericRepository<DepartmentTB>, IDepartmentRepository
    {
        public DepartmentRepository(StudentDB db) : base(db)
        {
        }
        public override async Task<List<DepartmentTB>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
    }
}
