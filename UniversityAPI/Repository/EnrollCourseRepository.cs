using UniversityAPI.Interface;
using UniversityAPI.Model;

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
    }
}
