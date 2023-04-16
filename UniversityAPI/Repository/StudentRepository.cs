using Microsoft.EntityFrameworkCore;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class StudentRepository:GenericRepository<StudentTB>,IStudentRepository
    {
        public StudentRepository(StudentDB db) : base(db)
        {
        }

        public override async Task<List<StudentTB>> GetAllAsync()
        {
            return await DbSet.Include(c=>c.DepartmentTB).ToListAsync();
        }

        public override async Task<StudentTB> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<bool> AddEntity(StudentTB studentTB)
        {
            try
            {
                await DbSet.AddAsync(studentTB);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> UpdateEntity(StudentTB entity)
        {
            try
            {
                var existData = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (existData!=null)
                {
                    existData.StudentName = entity.StudentName;
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
           var existData =   await DbSet.FirstOrDefaultAsync(x => x.Id == id);
           if (existData!=null)
           {
                DbSet.Remove(existData);
               return true;
           }
           else
           {
               return false;
           }
        }

        
    }
}
