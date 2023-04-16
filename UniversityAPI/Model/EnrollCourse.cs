using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityAPI.Model;

namespace UniversityAPI.Model
{
    public class EnrollCourse
    {
        [Key] public int Id { get; set; }
        [Required] [DataType(DataType.Date)] public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public StudentTB StudentTB { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}