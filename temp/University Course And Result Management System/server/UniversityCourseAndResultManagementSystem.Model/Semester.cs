namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Semester
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SemesterCourse> SemesterCourse { get; set; }
    }
}
