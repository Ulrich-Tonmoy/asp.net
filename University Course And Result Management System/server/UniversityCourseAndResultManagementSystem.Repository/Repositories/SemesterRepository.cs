using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository.Repositories
{
    public class SemesterRepository : RepositoryBase<Semester>, ISemesterRepository
    {
        public SemesterRepository(DbContext universityCourseAndResultManagementSystemContext) : base(universityCourseAndResultManagementSystemContext)
        {
        }
    }
}
