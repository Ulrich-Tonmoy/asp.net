﻿namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Credit { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public Guid SemesterId { get; set; }
        public List<Semester> Semesters { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid ScheduleId { get; set; }
        public List<Schedule> Schedules { get; set; }
        public Guid AssignedCourseId { get; set; }
        public AssignedCourse AssignedCourse { get; set; }
    }
}