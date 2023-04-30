using UniversityAPI.Interface;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class RoomRepository:GenericRepository<Room>,IRoomRepository
    {
        public RoomRepository(StudentDB db) : base(db)
        {
        }
        public override async Task<List<Room>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
    }
}
