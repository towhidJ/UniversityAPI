namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("RoomNoTB")]
    public partial class RoomNoTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomNoTB()
        {
            ClassAllocateTB = new HashSet<ClassAllocateTB>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassAllocateTB> ClassAllocateTB { get; set; }
    }
}
