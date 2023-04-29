using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityAPI.Model;

namespace UniversityAPI.Model
{
    public class AllocateClass
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Time)]
        public DateTime FromTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime ToTime { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentTB DepartmentTB { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public int? DayId { get; set; }
        public Day Day { get; set; }
        public bool Action { get; set; }


    }
}