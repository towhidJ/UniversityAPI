using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

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
            return await DbSet.Include(c => c.DepartmentTB).Where(c=>c.Action==true).ToListAsync();
        }

        public override async Task<CourseAssignTeacher> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<string> AddCourseAssign(CourseAssignTeacher courseAssign)
        {
            try
            {
                var iseXIST = await _db.CourseAssignTb.FirstOrDefaultAsync(c => c.CourseId == courseAssign.CourseId  );
                if (iseXIST != null)
                {
                    return "Course Already Assign";
                }
                else
                {
                    var credit = _db.CourseTb.Single(c => c.Id == courseAssign.CourseId).Credit;
                    var AvailableCredit = _db.TeacherTb.Single(c => c.Id == courseAssign.TeacherId).RemainingCredit;
                    var reminingCredit = (AvailableCredit - credit);
                    // if (AvailableCredit < credit)
                    // {
                    //     return "Credit not available";
                    // }
                     UpdateTeacherCredit(reminingCredit, courseAssign.TeacherId);
                    await DbSet.AddAsync(courseAssign);
                    return "Course Assign Success";
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     


        public bool UpdateTeacherCredit(double reminingcredit, int teacherId)
        {
               var existData =  _db.TeacherTb.FirstOrDefault(x => x.Id == teacherId);
                if (existData != null)
                {
                    existData.RemainingCredit = reminingcredit;
                    _db.TeacherTb.Update(existData);
                    _db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        public async Task<bool> UnassignCourse()
        {
            var isAction = _db.CourseTb.Where(c => c.Action == 1);
            if(isAction!=null)
            {
                
                var t = _db.TeacherTb.ToList();
                t.ForEach(c=>c.RemainingCredit=c.CreditToBeTaken);
                await _db.SaveChangesAsync();
                var cat = _db.CourseAssignTb.ToList();
                 cat.ForEach(c=>c.Action=false);
                await _db.SaveChangesAsync();
                var course = _db.CourseTb.ToList();
                course.ForEach(c => c.Action = 0);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public List<ShowAssignView> GetCourseAssignByDepartmentId(int depId)
        {
            // var course = (from c in _db.CourseTb
            //     join ca in _db.CourseAssignTb on new { X1 = c.Id, X2 = true } equals new { X1 = ca.CourseId, X2 = ca.Action }
            //         into caa
            //     from ctl in caa.DefaultIfEmpty()
            //     join t in _db.TeacherTb on ctl.TeacherId equals t.Id into ta
            //     from taa in ta.DefaultIfEmpty()
            //     join dep in _db.DepartmentTb on c.DepartmentId equals dep.Id
            //     where dep.Id == depId
            //     where c.Action == 1

                // select new CourseShowView()
                // {
                //     Id = c.Id,
                //     CourseCode = c.CourseCode,
                //     CourseName = c.CourseName,
                //     DepartmentCode = dep.DepartmentCode,
                //     TeacherName = taa.TeacherName == null ? "Not Assign" : taa.TeacherName
                //
                // }).ToList();

                var course = _db.StudentAssignView.FromSqlRaw("SELECT * FROM ShowAssignView WHERE DepartmentId =" +
                                                              depId + "AND Action = 1");
            return course.ToList();
        }
    }
}
