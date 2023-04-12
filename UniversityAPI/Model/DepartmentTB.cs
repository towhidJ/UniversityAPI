namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("DepartmentTB")]
    public partial class DepartmentTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTB()
        {
            ClassAllocateTB = new HashSet<ClassAllocateTB>();
            CourseTB = new HashSet<CourseTB>();
            StudentTB = new HashSet<StudentTB>();
            TeacherTB = new HashSet<TeacherTB>();
        }

        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentCode { get; set; }

        [Required]
        [StringLength(150)]
        public string DepartmentName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassAllocateTB> ClassAllocateTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseTB> CourseTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTB> StudentTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherTB> TeacherTB { get; set; }
    }
}
