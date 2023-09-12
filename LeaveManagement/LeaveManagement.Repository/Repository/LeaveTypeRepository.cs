using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using LeaveManagement.Repository.Repository.Generic;

namespace LeaveManagement.Repository.Repository
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext) { }
    }
}
