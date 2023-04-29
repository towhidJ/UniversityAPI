using UniversityAPI.Model;

namespace UniversityAPI.Interface
{
    public interface IClassScheduleRepository:IGenericRepository<AllocateClass>
    {
        public Task<string>AddClassSchedule(AllocateClass classSchedule);
    }
}
