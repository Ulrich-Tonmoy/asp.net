using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Common.Constants;
using EmployeeManagementSystem.Service.Services.Contracts;
using EmployeeManagementSystem.Common;
using EmployeeManagementSystem.Repository.Contracts;
using EmployeeManagementSystem.DTO.Job;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.Common.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Service.Services
{
    public class JobService : IJobService
    {
        private IUnitOfWork _unitOfWork;

        public JobService(IUnitOfWork repositoryWrapper)
        {
            _unitOfWork = repositoryWrapper;
        }

        public async Task<List<JobResponseDto>> GetAllJobAsync()
        {

            List<Job> jobs = await _unitOfWork.JobRepository.GetAllNoTracking().ToListAsync();
            List<JobResponseDto> jobsResult = Mapping.Mapper.Map<List<JobResponseDto>>(jobs);

            return jobsResult;
        }

        public async Task<PagedList<JobResponseDto>> GetAllJobAsyncWithParam(JobQueryParameters jobParameters)
        {
            IQueryable<Job> jobs = _unitOfWork.JobRepository.GetAllNoTrackingWithParam(jobParameters, x => x.OrderBy(j => j.JobTitle));

            List<JobResponseDto> jobRes = Mapping.Mapper.Map<List<JobResponseDto>>(jobs);

            var count = await _unitOfWork.JobRepository.CountAllAsync();
            PagedList<JobResponseDto> jobResponseResult = PagedList<JobResponseDto>.ToPagedList(jobRes, count, jobParameters.PageNumber, jobParameters.PageSize);

            return jobResponseResult;
        }

        public async Task<JobResponseDto> GetJobByIdAsync(Guid id)
        {
            Job job = _unitOfWork.JobRepository.GetByConditionNoTracking(j => j.Id.Equals(id)).FirstOrDefault();
            JobResponseDto jobResult = Mapping.Mapper.Map<JobResponseDto>(job);

            return jobResult;
        }

        public async Task<JobCreateResponseDto> CreateJobAsync(JobCreateDto jobCreateDto)
        {
            Job jobModel = Mapping.Mapper.Map<Job>(jobCreateDto);
            await _unitOfWork.JobRepository.AddAsync(jobModel);
            await _unitOfWork.SaveAsync();

            JobCreateResponseDto jobResponseDto = Mapping.Mapper.Map<JobCreateResponseDto>(jobModel);

            return jobResponseDto;
        }

        public async Task<List<JobCreateResponseDto>> CreateJobAsyncRange(List<JobCreateDto> jobCreateDto)
        {
            List<Job> jobModel = Mapping.Mapper.Map<List<Job>>(jobCreateDto);
            await _unitOfWork.JobRepository.AddAsyncRange(jobModel);
            await _unitOfWork.SaveAsync();

            List<JobCreateResponseDto> jobResponseDto = Mapping.Mapper.Map<List<JobCreateResponseDto>>(jobModel);

            return jobResponseDto;
        }

        public async Task<JobUpdateResponseDto> UpdateJobAsync(JobUpdateDto jobUpdateDto)
        {
            Job jobEntity = _unitOfWork.JobRepository.GetByConditionNoTracking(j => j.Id.Equals(jobUpdateDto.Id)).FirstOrDefault();
            if (jobEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(jobUpdateDto, jobEntity);

            await _unitOfWork.JobRepository.Update(jobEntity);
            await _unitOfWork.SaveAsync();

            JobUpdateResponseDto jobResponseDto = Mapping.Mapper.Map<JobUpdateResponseDto>(jobEntity);

            return jobResponseDto;
        }

        public async Task<List<JobUpdateResponseDto>> UpdateJobAsyncRange(List<JobUpdateDto> jobUpdateDto)
        {
            IEnumerable<Guid> id = jobUpdateDto.Select(j => j.Id);

            List<Job> jobEntity = await _unitOfWork.JobRepository.GetByConditionNoTracking(j => id.Contains(j.Id)).ToListAsync();

            if (jobEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(jobUpdateDto, jobEntity);

            await _unitOfWork.JobRepository.UpdateRange(jobEntity);
            await _unitOfWork.SaveAsync();

            List<JobUpdateResponseDto> jobResponseDto = Mapping.Mapper.Map<List<JobUpdateResponseDto>>(jobEntity);

            return jobResponseDto;
        }

        public async Task<String> DeleteJobAsync(Guid id)
        {
            Job job = _unitOfWork.JobRepository.GetByConditionNoTracking(j => j.Id.Equals(id)).FirstOrDefault();
            if (job == null)
            {
                return null;
            }

            await _unitOfWork.JobRepository.Delete(job);
            await _unitOfWork.SaveAsync();

            return String.Format(ServerResponseConstants.SUCCESSFULLY_DELETED, "JobTitle");
        }

        public async Task<String> DeleteJobAsyncRange(List<Guid> id)
        {
            List<Job> job = await _unitOfWork.JobRepository.GetByConditionNoTracking(j => id.Contains(j.Id)).ToListAsync();
            if (job.Count() != id.Count())
            {
                return null;
            }

            await _unitOfWork.JobRepository.DeleteRange(job);
            await _unitOfWork.SaveAsync();

            return String.Format(ServerResponseConstants.SUCCESSFULLY_DELETED, "JobTitle");
        }

        public async Task<bool> AnyJobAsync(string jobTitle)
        {
            return await _unitOfWork.JobRepository.AnyAsync(j => j.JobTitle.Equals(jobTitle));
        }

        public async Task<int> CountAllJobAsync()
        {
            var totalJobCount = await _unitOfWork.JobRepository.CountAllAsync();

            return totalJobCount;
        }
    }
}
