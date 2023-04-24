using UniversityAPI.Model;

namespace UniversityAPI.Interface
{
    public interface IEnrollCourseRepository:IGenericRepository<EnrollCourse>
    {
        Task<string> EnrollCourse(EnrollCourse enrollCourse);
    }
}
