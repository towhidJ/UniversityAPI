namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("ClassAllocateTB")]
    public partial class ClassAllocateTB
    {

        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int RoomId { get; set; }

        public int CourseId { get; set; }

        public int DayId { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public int Action { get; set; }

        public virtual DayTB DayTB { get; set; }

        public virtual DepartmentTB DepartmentTB { get; set; }

        public virtual RoomNoTB RoomNoTB { get; set; }
    }
}
