using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository.Repositories
{
    public class DesignationRepository : RepositoryBase<Designation>, IDesignationRepository
    {
        public DesignationRepository(DbContext universityCourseAndResultManagementSystemContext) : base(universityCourseAndResultManagementSystemContext)
        {
        }
    }
}
