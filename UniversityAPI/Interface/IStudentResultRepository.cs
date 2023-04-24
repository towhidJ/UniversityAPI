using UniversityAPI.Model;

namespace UniversityAPI.Interface
{
    public interface IStudentResultRepository:IGenericRepository<StudentResult>
    {
        Task<string>AddResult(StudentResult studentResult);
    }
}
