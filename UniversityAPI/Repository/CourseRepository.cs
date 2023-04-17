using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;

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
            throw new NotImplementedException();
        }

        public override async Task<bool> AddEntity(Course course)
        {
            try
            {
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
            throw new NotImplementedException();
        }
    }
}
