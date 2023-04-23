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
        Task SaveAsync();
    }
}
