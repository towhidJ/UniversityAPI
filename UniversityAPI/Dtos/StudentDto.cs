using System.ComponentModel.DataAnnotations;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class StudentDto
    {
        [Key]
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string? Email { get; set; }

        public string ContactNo { get; set; }

        public DateTime RegisterDate { get; set; }

        public string Address { get; set; }

        public string? RegistrationNo { get; set; }
        public int DepartmentId { get; set; }

    }
}
