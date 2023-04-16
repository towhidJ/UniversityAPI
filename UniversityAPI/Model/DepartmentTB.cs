
using UniversityAPI.Model;

namespace UniversityAPI.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    
    public  class DepartmentTB
    {

        [Key]
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public List<StudentTB> StudentTB{ get; set; }
        // public List<StudentTB> StudentTB { get; set; }
        public List<Teacher> Teacher { get; set; }
        public List<Course> Course { get; set; }
        public List<CourseAssignTeacher> CourseAssignTeacher { get; set; }
        public List<AllocateClass> AllocateClass { get; set; }




    }
}
