using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class SemesterRepository:GenericRepository<Semester>,ISemesterRepository
    {
        public SemesterRepository(StudentDB db) : base(db)
        {
        }

        public async Task<List<Semester>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
    }
}
