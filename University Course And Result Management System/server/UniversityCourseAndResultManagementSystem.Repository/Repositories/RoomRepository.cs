using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(DbContext universityCourseAndResultManagementSystemContext) : base(universityCourseAndResultManagementSystemContext)
        {
        }
    }
}
