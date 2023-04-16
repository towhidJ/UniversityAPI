using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityAPI.Model
{
    public class Designation
    {
        public int Id { get; set; }
        public string DesignationName { get; set; }
        public List<Teacher>Teacher { get; set; }
    }
}