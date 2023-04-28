using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class GradeLetterRepository:GenericRepository<GradeLetter>,IGradeLetterRepository
    {
        public GradeLetterRepository(StudentDB db) : base(db)
        {
        }

        public override Task<List<GradeLetter>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
    }
}
