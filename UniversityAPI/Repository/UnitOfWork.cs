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
        public ITeacherRepository teachers { get; }
        public ICourseAssignToTeacherRepository courseAssignToTeacher { get; }
        public IEnrollCourseRepository enrollCourse { get; }
        public IStudentResultRepository studentResult { get; }
        public IGradeLetterRepository gradeLetters{ get; }
        public IDesignationRepository designation { get; }
        public IClassScheduleRepository classSchedule { get; }
        public IDayRepository day { get; }
        public IRoomRepository room { get; }


        public UnitOfWork(StudentDB db)
        {
            _db = db;
            students = new StudentRepository(_db);
            departments = new DepartmentRepository(_db);
            courses = new CourseRepository(_db);
            semesters = new SemesterRepository(_db);
            teachers = new TeacherRepository(_db);
            courseAssignToTeacher = new CourseAssignToTeacherRepository(_db);
            enrollCourse = new EnrollCourseRepository(_db);
            studentResult = new StudentResultRepository(_db);
            gradeLetters = new GradeLetterRepository(_db);
            designation = new DesignationRepository(_db);
            classSchedule = new ClassScheduleRepository(_db);
            day= new DayRepository(_db);
            room= new RoomRepository(_db);
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
            
        }
    }
}
