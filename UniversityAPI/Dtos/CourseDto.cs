using System.ComponentModel.DataAnnotations;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        
        public string CourseName { get; set; }
        
        public float Credit { get; set; }
        public string? Description { get; set; }

        public int? Action { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    }
}
