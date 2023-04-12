namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TeacherTB")]
    public partial class TeacherTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeacherTB()
        {
            CourseAssignTB = new HashSet<CourseAssignTB>();
        }

        public int Id { get; set; }

        public int DesignationId { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherName { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactNo { get; set; }

        public double CreditToBeTaken { get; set; }

        public double ReminingCredit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseAssignTB> CourseAssignTB { get; set; }

        public virtual DepartmentTB DepartmentTB { get; set; }

        public virtual DesignationTB DesignationTB { get; set; }
    }
}
