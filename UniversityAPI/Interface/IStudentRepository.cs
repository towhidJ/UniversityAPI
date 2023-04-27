using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;


namespace UniversityAPI.Interface
{
    public interface IStudentRepository:IGenericRepository<StudentTB>
    {
        public List<StudentView> GetStudentById(int studentId);
        public List<StudentView> GetCourseById(int studentId);
        public List<Course> GetCourseByDepId(int depId);
    }
}
