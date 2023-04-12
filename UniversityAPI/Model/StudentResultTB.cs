namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("StudentResultTB")]
    public partial class StudentResultTB
    {

        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int GradeLetterId { get; set; }

        public virtual CourseTB CourseTB { get; set; }

        public virtual GradeLetterTB GradeLetterTB { get; set; }
    }
}
