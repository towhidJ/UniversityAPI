using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class DepartmentRepository:GenericRepository<DepartmentTB>, IDepartmentRepository
    {
        public DepartmentRepository(StudentDB db) : base(db)
        {
        }
        public override async Task<List<DepartmentTB>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
        public override async Task<DepartmentTB> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public override async Task<bool> AddEntity(DepartmentTB department)
        {
            try
            {
                
                await DbSet.AddAsync(department);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> UpdateEntity(DepartmentTB entity)
        {
            try
            {
                var existData = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (existData != null)
                {
                    existData.DepartmentCode = entity.DepartmentCode;
                    existData.DepartmentName = entity.DepartmentName;
                    

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

        public bool UniqueDepartmentCode(string code)
        {
            var em = _db.DepartmentTb.FirstOrDefault(x => x.DepartmentCode == code );
            if (em != null)
            {
                return true;
            }

            return false;
        }
        public bool UniqueDepartmentName(string name)
        {
            var em = _db.DepartmentTb.FirstOrDefault(x => x.DepartmentName == name);
            if (em != null)
            {
                return true;
            }

            return false;
        }
    }
}
