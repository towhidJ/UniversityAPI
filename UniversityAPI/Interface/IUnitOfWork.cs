namespace UniversityAPI.Interface
{
    public interface IUnitOfWork
    {
        IStudentRepository students { get; }
        IDepartmentRepository departments { get; }
        ICourseRepository courses { get; }
        Task SaveAsync();
    }
}
