using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentDB db) : base(db)
        {
        }

        public override async Task<List<Teacher>> GetAllAsync()
        {
            return await DbSet.Include(c => c.DepartmentTB).Include(x=>x.Designation).ToListAsync();
        }

        public override async Task<Teacher> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<bool> AddEntity(Teacher teacher)
        {
            try
            {
                teacher.RemainingCredit = teacher.CreditToBeTaken;
                await DbSet.AddAsync(teacher);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> UpdateEntity(Teacher entity)
        {
            try
            {
                var existData = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (existData != null)
                {
                    existData.TeacherName = entity.TeacherName;
                    existData.Address = entity.Address;
                    existData.ContactNo = entity.ContactNo;

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public List<Teacher> GetTeacherByDepId(int depId)
        {
            var student = (from dep in _db.DepartmentTb
                join t in _db.TeacherTb on dep.Id equals t.DepartmentId
                where dep.Id == depId
                select t).ToList();

            return student;
        }




    }
}
