using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   

    [Table("SemesterTB")]
    public partial class SemesterTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SemesterTB()
        {
            CourseTB = new HashSet<CourseTB>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SemesterName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseTB> CourseTB { get; set; }
    }
}
