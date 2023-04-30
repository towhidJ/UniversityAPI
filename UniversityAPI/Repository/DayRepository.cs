using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class DayRepository:GenericRepository<Day>,IDayRepository
    {
        public DayRepository(StudentDB db) : base(db)
        {
        }

        public override async Task<List<Day>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
    }
}
