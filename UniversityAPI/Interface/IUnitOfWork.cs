namespace UniversityAPI.Interface
{
    public interface IUnitOfWork
    {
        IStudentRepository students { get; }
        IDepartmentRepository departments { get; }
        ICourseRepository courses { get; }
        ISemesterRepository semesters { get; }
        ITeacherRepository teachers { get; }
        ICourseAssignToTeacherRepository courseAssignToTeacher { get; }
        IEnrollCourseRepository enrollCourse { get; }
        IStudentResultRepository studentResult { get; }
        IGradeLetterRepository gradeLetters{ get; }
        IDesignationRepository designation { get; }
        Task SaveAsync();
    }
}
