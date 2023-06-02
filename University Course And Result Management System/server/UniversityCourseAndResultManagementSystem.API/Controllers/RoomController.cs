using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RoomQueryParameters roomParam)
        {
            try
            {
                PagedList<RoomResponseDto> roomResults = await _roomService.GetAllRoomAsyncWithParam(roomParam);

                var roomResultstsData = new
                {
                    roomResults.TotalCount,
                    roomResults.PageSize,
                    roomResults.CurrentPage,
                    roomResults.TotalPages,
                    roomResults.HasNext,
                    roomResults.HasPrevious,
                    data = roomResults
                };

                return Ok(roomResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "RoomById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                RoomResponseDto roomResult = await _roomService.GetRoomByIdAsync(id);

                if (roomResult == null)
                {
                    return NotFound();
                }

                return Ok(roomResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomCreateDto room)
        {
            try
            {
                if (room == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Room"));
                }

                RoomResponseDto createdRoom = await _roomService.CreateRoomAsync(room);

                return CreatedAtRoute("RoomById", new { id = createdRoom.Id }, createdRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPatch("unallocate")]
        public async Task<IActionResult> UnAllocate()
        {
            try
            {
                string room = await _roomService.UnAllocateRoomAsync();
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomUpdateDto room)
        {
            try
            {
                if (room == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Room"));
                }

                RoomResponseDto roomEntity = await _roomService.UpdateRoomAsync(room);
                if (roomEntity == null)
                {
                    return NotFound();
                }

                return Ok(roomEntity);
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
                string room = await _roomService.DeleteRoomAsync(id);
                if (room == null)
                {
                    return NotFound();
                }

                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
