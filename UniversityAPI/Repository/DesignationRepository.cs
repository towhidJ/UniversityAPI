using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class DesignationRepository:GenericRepository<Designation>,IDesignationRepository
    {
        public DesignationRepository(StudentDB db) : base(db)
        {
        }

        public override Task<List<Designation>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
    }
}
