using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityAPI.Model;

namespace UniversityAPI.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleasee enter you Code")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Code must be 5 character long")]
        public string CourseCode { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Pleasee enter you number")]
        [Range(0.5, 5, ErrorMessage = "Enter number between 0.5 to 5")]
        public float Credit { get; set; }
        public string? Description { get; set; }
        
        public int Action { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentTB DepartmentTB { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get;set; }
        public List<EnrollCourse>EnrollCourse { get; set; }
        public List<CourseAssignTeacher> CourseAssignTeacher { get; set; }
        public List<AllocateClass> AllocateClass { get; set; }
        public List<StudentResult> StudentResult { get; set; }



    }
}