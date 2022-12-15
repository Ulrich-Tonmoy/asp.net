using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext universityCourseAndResultManagementSystemContext) : base(universityCourseAndResultManagementSystemContext)
        {
        }
    }
}
