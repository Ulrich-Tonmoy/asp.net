﻿namespace UniversityCourseAndResultManagementSystem.DTO.CourseDto
{
    public class CourseUpdateDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Credit { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid SemesterId { get; set; }
    }
}
