using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using LeaveManagement.Repository.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Repository.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved)
        {
            leaveRequest.Approved = approved;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestDetails()
        {
            return await _dbContext.LeaveRequests.Include(x => x.LeaveType).ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestDetails(Guid id)
        {
            return await _dbContext.LeaveRequests.Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
