using System.Collections;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Interface;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniversityAPI.Repository
{
    public class ClassScheduleRepository:GenericRepository<AllocateClass>,IClassScheduleRepository
    {
        public ClassScheduleRepository(StudentDB db) : base(db)
        {
        }

        public async Task<List<ClassScheduleViewModel>> GetSchedule(int depId)
        {
            List<ClassScheduleViewModel> scheduleList = new List<ClassScheduleViewModel>();

            var classSchedule =  _db.ClassScheduleView.FromSqlRaw("select * from ClassAllocatedView where departmentId=" + depId +
                                                   " and Action="+1).ToList();
            Hashtable ht = new Hashtable();
            ClassScheduleViewModel schedule;

            foreach (var cs in classSchedule)
            {
                var ft = cs.FromTime.ToString("hh:mm tt");
                var tt = cs.ToTime.ToString("hh:mm tt");
                string scheduleInfo = "Room No: " + cs.RoomNo + ", " + cs.DayName + ", " + ft +
                                      " - " + tt + "\n";

                if (scheduleInfo == "")
                {
                    scheduleInfo = "Not Scheduled Yet";
                }

                if (!ht.ContainsKey(cs.CourseCode))
                {
                    schedule = new ClassScheduleViewModel();
                    schedule.CourseCode = cs.CourseCode;
                    schedule.CourseName = cs.CourseName;
                    schedule.Schedule = scheduleInfo;
                    ht[cs.CourseCode] = schedule;
                    scheduleList.Add(schedule);
                }
                else
                {
                    schedule = (ClassScheduleViewModel)ht[cs.CourseCode];
                    schedule.Schedule = schedule.Schedule + scheduleInfo;
                }
            }

            return scheduleList;
        }

        public async Task<string> AddClassSchedule(AllocateClass classSchedule)
        {
            if (classSchedule.FromTime > classSchedule.ToTime)
            {
                return "This Time is not Available";
            }
            bool isTimeClassAllocateValid = IsTimeClassAllocateValid(classSchedule.DayId, classSchedule.RoomId, classSchedule.FromTime, classSchedule.ToTime);
            if (isTimeClassAllocateValid == false)
            {
                await DbSet.AddAsync(classSchedule);
            }
            return "The Schedule Time Class Already Exists";
        }


        private bool IsTimeClassAllocateValid(int DayId, int RoomId, DateTime FromTime, DateTime ToTime)
        {
            List<AllocateClass> allocateClassrooms = GetTimeAllocate(DayId, RoomId, FromTime, ToTime);

            foreach (AllocateClass allocate in allocateClassrooms)
            {
                if ((allocate.DayId == DayId && RoomId == allocate.RoomId) &&
                    (FromTime < allocate.FromTime && ToTime > allocate.ToTime) || 
                    (FromTime == allocate.FromTime) ||
                    (allocate.FromTime < FromTime && allocate.ToTime > FromTime))
                {
                    return true;
                }
            }
            return false;
        }



        private List<AllocateClass> GetTimeAllocate(int dayId, int roomId, DateTime fromTime, DateTime toTime)
        {

            var allocateClassRooms = (from ac in _db.AllocateClassTb
                                      where ac.RoomId==roomId && ac.DayId==dayId && ac.Action==true
                                          select ac).ToList();
            return allocateClassRooms;
        }
    }
}
