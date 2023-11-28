using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.DesignationDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private IDesignationService _designationService;

        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DesignationQueryParameters des)
        {
            try
            {
                PagedList<DesignationResponseDto> desResults = await _designationService.GetAllDesignationAsyncWithParam(des);

                var desResultstsData = new
                {
                    desResults.TotalCount,
                    desResults.PageSize,
                    desResults.CurrentPage,
                    desResults.TotalPages,
                    desResults.HasNext,
                    desResults.HasPrevious,
                    data = desResults
                };

                return Ok(desResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "DesignationById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                DesignationResponseDto desResult = await _designationService.GetDesignationByIdAsync(id);

                if (desResult == null)
                {
                    return NotFound();
                }

                return Ok(desResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DesignationCreateDto des)
        {
            try
            {
                if (des == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Designation"));
                }

                DesignationResponseDto createdDes = await _designationService.CreateDesignationAsync(des);

                return CreatedAtRoute("DesignationById", new { id = createdDes.Id }, createdDes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DesignationUpdateDto des)
        {
            try
            {
                if (des == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Designation"));
                }

                DesignationResponseDto desEntity = await _designationService.UpdateDesignationAsync(des);
                if (desEntity == null)
                {
                    return NotFound();
                }

                return Ok(desEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                string des = await _designationService.DeleteDesignationAsync(id);
                if (des == null)
                {
                    return NotFound();
                }

                return Ok(des);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
