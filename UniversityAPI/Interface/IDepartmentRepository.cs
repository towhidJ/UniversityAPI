using UniversityAPI.Model;

namespace UniversityAPI.Interface
{
    public interface IDepartmentRepository:IGenericRepository<DepartmentTB>
    {
        public bool UniqueDepartmentCode(string code);
        public bool UniqueDepartmentName(string name);
    }
}
