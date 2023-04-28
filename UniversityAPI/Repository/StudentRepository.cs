using Microsoft.EntityFrameworkCore;
using UniversityAPI.Dtos;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

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


        public List<StudentView> GetStudentById(int studentId)
        {
            var student = (from dep in _db.DepartmentTb
                join c in _db.CourseTb on dep.Id equals c.DepartmentId
                join std in _db.StudentTb on dep.Id equals std.DepartmentId
                where std.Id == studentId
                select new StudentView()
                {
                    CourseId = c.Id,
                    CourseName = c.CourseName,
                    DepartmentName = dep.DepartmentName,
                    DepartmentId = std.DepartmentId,
                    StudentName = std.StudentName,
                    StudentId = std.Id,
                    Email = std.Email,
                    RegistrationNo = std.RegistrationNo
                }).ToList();

            return student;
        }

        public List<StudentView> GetCourseById(int studentId)
        {
            var student = (from dep in _db.DepartmentTb
                join c in _db.CourseTb on dep.Id equals c.DepartmentId
                join std in _db.StudentTb on dep.Id equals std.DepartmentId
                where c.Action==1 && std.Id == studentId
                select new StudentView()
                {
                    CourseId = c.Id,
                    CourseName = c.CourseName,
                    StudentId = std.Id
                }).ToList();

            return student;
        }
        public List<Course> GetCourseByDepId(int depId)
        {
            var student = (from dep in _db.DepartmentTb
                join c in _db.CourseTb on dep.Id equals c.DepartmentId
                where c.Action == 1 && dep.Id == depId
                select new Course()
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    CourseCode = c.CourseCode,
                    Credit = c.Credit
                }).ToList();

            return student;
        }
    }
}
