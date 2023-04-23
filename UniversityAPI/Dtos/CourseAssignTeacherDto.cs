using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class CourseAssignTeacherDto
    {
        
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
    }
}
