namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("CourseTB")]
    public partial class CourseTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseTB()
        {
            StudentResultTB = new HashSet<StudentResultTB>();
        }


        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int SemesterId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Credit { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Action { get; set; }

        public virtual DepartmentTB DepartmentTB { get; set; }

        public virtual SemesterTB SemesterTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentResultTB> StudentResultTB { get; set; }
    }
}
