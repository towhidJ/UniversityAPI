namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("DesignationTB")]
    public partial class DesignationTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DesignationTB()
        {
            TeacherTB = new HashSet<TeacherTB>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DesignationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherTB> TeacherTB { get; set; }
    }
}
