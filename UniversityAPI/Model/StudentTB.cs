namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("StudentTB")]
    public partial class StudentTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTB()
        {
            EnrollCourseTB = new HashSet<EnrollCourseTB>();
        }


        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string ContactNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string RegistrationNo { get; set; }

        public virtual DepartmentTB DepartmentTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollCourseTB> EnrollCourseTB { get; set; }
    }
}
