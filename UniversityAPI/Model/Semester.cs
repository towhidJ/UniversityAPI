using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAPI.Model
{
    public class Semester
    {

        public int Id { get; set; }
        public string SemesterName { get; set; }
        public List<Course>Course { get;set; }
    }
}