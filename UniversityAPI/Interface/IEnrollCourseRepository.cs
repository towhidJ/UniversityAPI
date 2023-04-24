using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Interface
{
    public interface IEnrollCourseRepository:IGenericRepository<EnrollCourse>
    {
        Task<string> EnrollCourse(EnrollCourse enrollCourse);
        List<StudentView> GetStudentByEnrollCourse(int studentId);
    }
}
