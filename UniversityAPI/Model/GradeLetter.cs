using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAPI.Model
{
    public class GradeLetter
    {
        public int Id { get; set; }
        public string GradeLetterMarkes { get; set; }
        public string? GradePoint { get; set; }
        public List<StudentResult> StudentResult { get; set; }

    }
}