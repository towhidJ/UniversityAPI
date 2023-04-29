using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Repository
{
    public class StudentResultRepository:GenericRepository<StudentResult>,IStudentResultRepository
    {
        public StudentResultRepository(StudentDB db) : base(db)
        {
            
        }

        public async Task<string> AddResult(StudentResult studentResult)
        {
            try
            {
                var a = _db.StudentResultTb.FirstOrDefault(c => c.StudentId == studentResult.StudentId && c.CourseId == studentResult.CourseId);
                if (a != null)
                {
                    return "This subject Result already entry";
                }

                var c = _db.EnrollCourseTb.FirstOrDefault(s =>
                    s.StudentId == studentResult.StudentId && s.CourseId == studentResult.CourseId);
                if (c == null)
                {
                    return "This Student Course not Enrolled";
                }
                
                await DbSet.AddAsync(studentResult);
                return "Result Add Successful";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
        }

        public List<StudentResultViewModel> GetAllStudentResults(int studentId)
        {
            

            var result = _db.StudentResultViews.FromSqlRaw($"SelectResultWithGPA {studentId}" ).ToList();

            return result;
        }
    }
}
