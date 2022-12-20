using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository.Repositories
{
    public class StudentEnrolledCourseRepository : RepositoryBase<StudentEnrolledCourse>, IStudentEnrolledCourseRepository
    {
        public StudentEnrolledCourseRepository(DbContext universityCourseAndResultManagementSystemContext) : base(universityCourseAndResultManagementSystemContext)
        {
        }
    }
}
