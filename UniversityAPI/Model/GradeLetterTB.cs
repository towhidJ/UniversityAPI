namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("GradeLetterTB")]
    public partial class GradeLetterTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GradeLetterTB()
        {
            StudentResultTB = new HashSet<StudentResultTB>();
        }
       
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string GradeLetterMarkes { get; set; }

        [Required]
        [StringLength(50)]
        public string GradePoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentResultTB> StudentResultTB { get; set; }
    }
}
