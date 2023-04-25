using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Repository
{
    public class EnrollCourseRepository : GenericRepository<EnrollCourse>, IEnrollCourseRepository
    {
        public EnrollCourseRepository(StudentDB db) : base(db)
        {
        }

        

       

        public  async Task<string> EnrollCourse(EnrollCourse enrollCourse)
        {
            try
            {
                var a = _db.EnrollCourseTb.FirstOrDefault(c => c.StudentId == enrollCourse.StudentId && c.CourseId == enrollCourse.CourseId);
                if (a!=null)
                {
                    return "Course Already Enrolled";
                }
                await DbSet.AddAsync(enrollCourse);
                return "Enroll Successful";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentView> GetStudentByEnrollCourse(int studentId)
        {
            var student =
                from std
                    in _db.StudentTb
                join enrollCourse in _db.EnrollCourseTb
                    on std.Id
                    equals enrollCourse.StudentId
                join dep in _db.DepartmentTb
                    on std.DepartmentId
                    equals dep.Id
                join course in _db.CourseTb on new { X1 = enrollCourse.CourseId, X2 = 1 } equals new
                    { X1 = course.Id, X2 = course.Action }
                where enrollCourse.StudentId== studentId
                select new StudentView()
                {
                    CourseId = enrollCourse.CourseId,
                    CourseName = course.CourseName,
                    Email = std.Email,
                    DepartmentName = dep.DepartmentName,
                    DepartmentId = dep.Id,
                    StudentName = std.StudentName,
                    RegistrationNo = std.RegistrationNo,
                    StudentId = enrollCourse.StudentId
                };

            return student.ToList();

        }

        public List<Course> GetCourseByEnrollCourse(int studentId)
        {
            
            var student = (
                from course in _db.CourseTb
                join enrollCourse in _db.EnrollCourseTb on course.Id equals enrollCourse.CourseId
                where enrollCourse.StudentId == studentId
                where course.Action==1
                select new Course()
                {
                    CourseName = course.CourseName,
                    Id = enrollCourse.CourseId

                }).ToList();
            return student;
        }

    }
}
