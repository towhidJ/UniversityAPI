using System.ComponentModel.DataAnnotations;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class AllocateClassDto
    {

        
        public int Id { get; set; }
        [DataType(DataType.Time)]
        public DateTime FromTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime ToTime { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }
        public bool Action { get; set; }
    }
}
