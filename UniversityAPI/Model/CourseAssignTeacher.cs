using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityAPI.Model
{
    public class CourseAssignTeacher
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentTB DepartmentTB { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}