using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using LeaveManagement.Repository.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Repository.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetAllLeaveAllocationDetails()
        {
            return await _dbContext.LeaveAllocations.Include(x => x.LeaveType).ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationDetails(Guid id)
        {
            return await _dbContext.LeaveAllocations.Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
