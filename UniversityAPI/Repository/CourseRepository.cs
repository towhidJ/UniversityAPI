using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Repository
{
    public class CourseRepository:GenericRepository<Course>,ICourseRepository
    {
        public CourseRepository(StudentDB db) : base(db)
        {
        }

        public override async Task<List<Course>> GetAllAsync()
        {
            return await DbSet.Include(c => c.DepartmentTB).Include(c=>c.Semester).ToListAsync();

        }

        public override async Task<Course> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<bool> AddEntity(Course course)
        {
            try
            {
                course.Action = 1;
                await DbSet.AddAsync(course);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> UpdateEntity(Course entity)
        {
            try
            {
                var existData = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (existData != null)
                {
                    existData.CourseCode = entity.CourseCode;
                    existData.CourseName = entity.CourseName;
                    existData.Description=entity.Description;
                    existData.Credit = entity.Credit;
                    existData.DepartmentId = entity.DepartmentId;
                    existData.SemesterId = entity.SemesterId;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        
        public List<CourseShowView> GetCourseByDepartmentId(int depId)
        {
            var course = (from c in _db.CourseTb
                join ca in _db.CourseAssignTb on new {X1=c.Id,X2=true} equals new {X1=ca.CourseId,X2=ca.Action }
            into caa 
                from ctl in caa.DefaultIfEmpty()
                join t in _db.TeacherTb on ctl.TeacherId equals t.Id into ta
                from taa in ta.DefaultIfEmpty()
                join dep in _db.DepartmentTb on c.DepartmentId equals dep.Id
                where dep.Id == depId
                where c.Action ==1
                
                select new CourseShowView()
                {
                    Id = c.Id,
                    CourseCode = c.CourseCode,
                    CourseName = c.CourseName,
                    DepartmentCode = dep.DepartmentCode,
                    TeacherName = taa.TeacherName == null ? "Not Assign" : taa.TeacherName

                }).ToList();
            return course;
        }

       

        public override async Task<bool> DeleteEntity(int id)
        {
            var existData = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (existData != null)
            {
                DbSet.Remove(existData);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UniqueCourseCode(string code)
        {
            var em = _db.CourseTb.FirstOrDefault(x => x.CourseCode == code);
            if (em != null)
            {
                return true;
            }

            return false;
        }
        public bool UniqueCourseName(string name)
        {
            var em = _db.CourseTb.FirstOrDefault(x => x.CourseName == name);
            if (em != null)
            {
                return true;
            }

            return false;
        }
    }
}
