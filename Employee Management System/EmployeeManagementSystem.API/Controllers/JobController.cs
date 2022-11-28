using EmployeeManagementSystem.Common.Constants;
using EmployeeManagementSystem.Common.Pagination;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.DTO.Job;
using EmployeeManagementSystem.Service.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;

namespace EmployeeManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IJobService _jobService;

        public JobController(IJobService jobTitleService)
        {
            _jobService = jobTitleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobTitles()
        {
            try
            {
                List<JobResponseDto> jobTitleResults = await _jobService.GetAllJobAsync();

                return Ok(jobTitleResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }



        [HttpGet("params")]
        public async Task<IActionResult> GetAllJobTitlesWithParams([FromQuery] JobQueryParameters jobParameters)
        {
            try
            {
                PagedList<ExpandoObject> jobTitleResults = await _jobService.GetAllJobAsyncWithParam(jobParameters);

                var jobTitleResultsData = new
                {
                    jobTitleResults.TotalCount,
                    jobTitleResults.PageSize,
                    jobTitleResults.CurrentPage,
                    jobTitleResults.TotalPages,
                    jobTitleResults.HasNext,
                    jobTitleResults.HasPrevious,
                    data = jobTitleResults
                };

                return Ok(jobTitleResultsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> GetAnyJobExist([FromQuery] string jobTitle)
        {
            try
            {
                var jobExist = await _jobService.AnyJobAsync(jobTitle);

                return Ok(jobExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetAllJobTitlesCount()
        {
            try
            {
                int jobTitlesResultCount = await _jobService.CountAllJobAsync();

                return Ok(jobTitlesResultCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "JobById")]
        public async Task<IActionResult> GetJobTitleById(Guid id)
        {
            try
            {
                JobResponseDto jobTitleResult = await _jobService.GetJobByIdAsync(id);

                if (jobTitleResult == null)
                {
                    return NotFound();
                }

                return Ok(jobTitleResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto job)
        {
            try
            {
                if (job == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "JobTitle"));
                }

                JobCreateResponseDto createdJob = await _jobService.CreateJobAsync(job);

                return CreatedAtRoute("JobTitleById", new { id = createdJob.Id }, createdJob);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost("range")]
        public async Task<IActionResult> CreateJobRange([FromBody] List<JobCreateDto> job)
        {
            try
            {
                if (job == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "JobTitle"));
                }

                List<JobCreateResponseDto> createdJob = await _jobService.CreateJobAsyncRange(job);

                var ids = createdJob.Select(d => new { jobId = d.Id });
                return CreatedAtRoute("JobById", new { id = ids }, createdJob);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobTitle([FromBody] JobUpdateDto job)
        {
            try
            {
                if (job == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "JobTitle"));
                }

                JobUpdateResponseDto jobEntity = await _jobService.UpdateJobAsync(job);
                if (jobEntity == null)
                {
                    return NotFound();
                }

                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut("range")]
        public async Task<IActionResult> UpdateJobTitleRange([FromBody] List<JobUpdateDto> job)
        {
            try
            {
                if (job == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "JobTitle"));
                }

                List<JobUpdateResponseDto> jobEntity = await _jobService.UpdateJobAsyncRange(job);
                if (jobEntity == null)
                {
                    return NotFound();
                }

                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTitle(Guid id)
        {
            try
            {
                string job = await _jobService.DeleteJobAsync(id);
                if (job == null)
                {
                    return NotFound();
                }

                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteJobTitleRange(List<Guid> id)
        {
            try
            {
                string job = await _jobService.DeleteJobAsyncRange(id);
                if (job == null)
                {
                    return NotFound();
                }

                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }
    }
}
