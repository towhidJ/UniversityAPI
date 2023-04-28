using UniversityAPI.Model;

namespace UniversityAPI.Interface
{
    public interface ITeacherRepository:IGenericRepository<Teacher>
    {

        public List<Teacher> GetTeacherByDepId(int depId);
    }
}
