using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Interface
{
    public interface IClassScheduleRepository:IGenericRepository<AllocateClass>
    {
        public Task<string>AddClassSchedule(AllocateClass classSchedule);
        public Task<List<ClassScheduleViewModel>> GetSchedule(int depId);
    }
}
