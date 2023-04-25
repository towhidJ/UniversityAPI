using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Interface
{
    public interface IStudentResultRepository:IGenericRepository<StudentResult>
    {
        Task<string>AddResult(StudentResult studentResult);
        List<StudentResultViewModel> GetAllStudentResults(int studentId);
    }
}
