namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("CourseAssignTB")]
    public partial class CourseAssignTB
    {

        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public virtual TeacherTB TeacherTB { get; set; }
    }
}
