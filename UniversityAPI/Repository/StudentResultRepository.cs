using UniversityAPI.Interface;
using UniversityAPI.Model;

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

                await DbSet.AddAsync(studentResult);
                return "Result Add Successful";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
        }
    }
}
