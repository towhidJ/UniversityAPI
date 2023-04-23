using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Interface
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        List<CourseShowView> GetCourseByDepartmentId(int depId);
        bool UniqueCourseCode(string code);
        bool UniqueCourseName(string name);
    }
}
