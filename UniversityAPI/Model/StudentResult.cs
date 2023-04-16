namespace UniversityAPI.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public  class StudentResult
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public StudentTB StudentTB { get; set; }
        public int CourseId { get; set; }
        public  Course Course { get; set; }
        public int GradeLetterId { get; set; }
        public GradeLetter GradeLetter { get; set; }
    }
}
