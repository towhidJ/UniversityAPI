﻿namespace UniversityAPI.Model.ViewModel
{
    public class ShowAssignView
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string CourseCode { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
    }
}
