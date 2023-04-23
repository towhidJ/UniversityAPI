using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using UniversityAPI.Model;

namespace UniversityAPI.Dtos
{
    public class TeacherDto
    {
        
        public int Id { get; set; }

       
        public string TeacherName { get; set; }
       
        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        
        public string ContactNo { get; set; }


        [Range(1, 100, ErrorMessage = "Credit Must 0 to 100")]
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }

    }
}
