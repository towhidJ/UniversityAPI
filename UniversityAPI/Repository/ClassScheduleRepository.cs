using Microsoft.Data.SqlClient;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniversityAPI.Repository
{
    public class ClassScheduleRepository:GenericRepository<AllocateClass>,IClassScheduleRepository
    {
        public ClassScheduleRepository(StudentDB db) : base(db)
        {
        }


        public async Task<string> AddClassSchedule(AllocateClass classSchedule)
        {
            if (classSchedule.FromTime > classSchedule.ToTime)
            {
                return "This Time is not Avaiable";
            }
            bool isTimeClassAllocateValid = IsTimeClassAllocateValid(classSchedule.DayId, classSchedule.RoomId, classSchedule.FromTime, classSchedule.ToTime);
            if (isTimeClassAllocateValid == false)
            {
                DbSet.AddAsync(classSchedule);
            }
            return "The Shedule Time Class Aleardy Exixts";
        }


        private bool IsTimeClassAllocateValid(int DayId, int RoomId, DateTime FromTime, DateTime ToTime)
        {
            // List<AllocateClass> allocateClassroomses = allocateClassRoomGetway.GetTimeAllocate(DayId, RoomId, FromTime, ToTime);

            // foreach (AllocateClass allocate in allocateClassroomses)
            // {
            //     if ((allocate.DayId == DayId && RoomId == allocate.RoomId) &&
            //         (FromTime < allocate.FromTime && ToTime > allocate.ToTime) ||
            //         (FromTime < allocate.FromTime && ToTime > allocate.ToTime) || (FromTime == allocate.FromTime) ||
            //         (allocate.FromTime < FromTime && allocate.ToTime > FromTime))
            //     {
            //         return true;
            //     }
            // }
            return false;
        }



        // public List<AllocateClass> GetTimeAllocate(int dayId, int roomId, DateTime fromTime, DateTime toTime)
        // {
        //     string query = "SELECT * FROM ClassAllocateTB WHERE RoomId=" + roomId + " AND DayId=" + dayId + " AND Action = 1";
        //     
        //     var allocateClassRooms = (from ac in _db.AllocateClassTb
        //                               where ac.RoomId==roomId && ac.DayId==dayId && ac.)
        //    
        //     return allocateClassRooms;
        // }
    }
}
