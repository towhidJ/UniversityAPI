using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly StudentDB _db;
        public IStudentRepository students { get; private set; }
        public IDepartmentRepository departments { get; set; }
        public ICourseRepository courses { get; }
        public ISemesterRepository semesters { get; }


        public UnitOfWork(StudentDB db)
        {
            _db = db;
            students = new StudentRepository(_db);
            departments = new DepartmentRepository(_db);
            courses = new CourseRepository(_db);
            semesters = new SemesterRepository(_db);
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
            
        }
    }
}
