using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityAPI.Model;

namespace UniversityAPI.Model
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Contact No must be 11 number long")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please enter you Credit")]
        [Range(1, 100, ErrorMessage = "You are not type of negative value")]
        [Display(Name = "CreditToBeTaken")]
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentTB DepartmentTB { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public List<CourseAssignTeacher> CourseAssignTeacher { get; set; }

    }
}