﻿namespace UniversityCourseAndResultManagementSystem.Model
{
    public class EnrolledCourse
    {
        public Guid Id { get; set; }
        public List<Student> Students { get; set; }
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public string Grade { get; set; }
    }
}
