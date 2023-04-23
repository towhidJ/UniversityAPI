using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Interface
{
    public interface ICourseAssignToTeacherRepository:IGenericRepository<CourseAssignTeacher>
    {
        Task<string> AddCourseAssign(CourseAssignTeacher entity);
        Task<bool> UpdateTeacherCredit(double reminingcredit, int teacherId);
        Task<bool> UnassignCourse();
    }
    
}
