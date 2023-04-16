using UniversityAPI.Model;

namespace UniversityAPI.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class StudentTB
    {
        

        [Key]
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string? Email { get; set; }

        public string ContactNo { get; set; }

        public DateTime? RegisterDate { get; set; }

        public string Address { get; set; }

        public string RegistrationNo { get; set; }
        public int DepartmentId { get; set; }

        public DepartmentTB DepartmentTB{ get; set; }

        public List<EnrollCourse> EnrollCourse { get; set; }
        public List<StudentResult> StudentResult { get; set; }


    }
}
