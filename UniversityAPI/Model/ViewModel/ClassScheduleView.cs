namespace UniversityAPI.Model.ViewModel
{
    public class ClassScheduleView
    {
        
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomNo { get; set; }
        public string DayName { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public bool Action { get; set; }
        public int  CourseAction { get; set; }
    }
}
