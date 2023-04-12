namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("EnrollCourseTB")]
    public partial class EnrollCourseTB
    {
        
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual StudentTB StudentTB { get; set; }
    }
}
