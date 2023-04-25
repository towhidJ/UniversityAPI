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
            

            // var result = (from ec in _db.EnrollCourseTb
            //         join studentResult in _db.StudentResultTb on ec.StudentId equals studentResult.StudentId into stdEc
            //         from stdResult in stdEc.DefaultIfEmpty()
            //         join gradeLetter in _db.GradeLetterTb on stdResult.GradeLetterId equals gradeLetter.Id into
            //             grdLetter
            //         from gradeLetter in grdLetter.DefaultIfEmpty()
            //               join std in _db.StudentTb on ec.StudentId equals std.Id 
            //         join course in _db.CourseTb on ec.CourseId equals course.Id
            //         where ec.StudentId== studentId
            //         select new StudentResultView()
            //         {
            //             CourseId = course.Id,
            //             CourseCode = course.CourseCode, 
            //             CourseName = course.CourseName,
            //             Grade = gradeLetter == null? "Not Graded Yet" : gradeLetter.GradeLetterMarkes,
            //             Credit = course.Credit
            //         })
            //     .ToList();

            var result = _db.StudentResultViews.FromSqlRaw($"Student_Result {studentId}" );

            return result.ToList();
        }
    }
}
