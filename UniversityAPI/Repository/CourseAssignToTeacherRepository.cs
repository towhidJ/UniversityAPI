using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class CourseAssignToTeacherRepository : GenericRepository<CourseAssignTeacher>,
        ICourseAssignToTeacherRepository
    {
        public CourseAssignToTeacherRepository(StudentDB db) : base(db)
        {
        }

        public override async Task<List<CourseAssignTeacher>> GetAllAsync()
        {
            return await DbSet.Include(c => c.DepartmentTB).ToListAsync();
        }

        public override async Task<CourseAssignTeacher> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<string> AddCourseAssign(CourseAssignTeacher courseAssign)
        {
            try
            {
                var iseXIST = await _db.CourseAssignTb.FirstOrDefaultAsync(c => c.CourseId == courseAssign.CourseId && c.Action==true );
                if (iseXIST != null)
                {
                    return "Course Already Assign";
                }
                var credit = _db.CourseTb.Single(c => c.Id == courseAssign.CourseId).Credit;
                var AvailableCredit = _db.TeacherTb.Single(c => c.Id == courseAssign.TeacherId).RemainingCredit;
                var reminingCredit = (AvailableCredit - credit);
                if (AvailableCredit < credit)
                {
                    return "Credit not available";
                }

                await UpdateTeacherCredit(reminingCredit, courseAssign.TeacherId);
                
                await DbSet.AddAsync(courseAssign);
                return "Course Assign Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     


        public async Task<bool> UpdateTeacherCredit(double reminingcredit, int teacherId)
        {
               var existData = await _db.TeacherTb.FirstOrDefaultAsync(x => x.Id == teacherId);
                if (existData != null)
                {
                    existData.RemainingCredit = reminingcredit;
                    _db.TeacherTb.Update(existData);
                    _db.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        public async Task<bool> UnassignCourse()
        {
            var isAction = _db.CourseAssignTb.Where(c => c.Action == true);
            if(isAction!=null)
            {
                
                var t = _db.TeacherTb.ToList();
                t.ForEach(c=>c.RemainingCredit=c.CreditToBeTaken);
                await _db.SaveChangesAsync();
                var cat = _db.CourseAssignTb.ToList();
                 cat.ForEach(c=>c.Action=false);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
