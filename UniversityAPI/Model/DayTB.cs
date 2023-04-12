namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("DayTB")]
    public partial class DayTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DayTB()
        {
            ClassAllocateTB = new HashSet<ClassAllocateTB>();
        }


        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DayName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassAllocateTB> ClassAllocateTB { get; set; }
    }
}
