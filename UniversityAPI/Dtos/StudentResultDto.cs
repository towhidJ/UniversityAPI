using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class StudentResultDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GradeLetterId { get; set; }
    }
}
