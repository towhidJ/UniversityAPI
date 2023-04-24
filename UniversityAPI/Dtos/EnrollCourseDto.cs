using System.ComponentModel.DataAnnotations;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class EnrollCourseDto
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)] 
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
