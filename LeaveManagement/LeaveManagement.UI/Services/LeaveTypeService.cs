using LeaveManagement.UI.DTOs.LeaveType;
using LeaveManagement.UI.Services.IServices;
using System.Net.Http.Json;
using System.Text.Json;

namespace LeaveManagement.UI.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public LeaveTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LeaveTypeDto>> GetAllLeaveType()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<LeaveTypeDto>>("api/LeaveTypes");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }

        public async Task<LeaveTypeDto> GetLeaveTypeById(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<LeaveTypeDto>($"api/LeaveTypes/{id}");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeDto leaveType)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/LeaveTypes", leaveType);
                if (response.IsSuccessStatusCode)
                {
                    return new Response<Guid>() { Success = true };
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    return new Response<Guid>() { Success = false, Message = message };
                }
            }
            catch (Exception ex)
            {
                return new Response<Guid>() { Success = false, Message = ex.Message };
            }
        }

        public async Task<Response<Guid>> UpdateLeaveType(LeaveTypeDto leaveType)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/LeaveTypes", leaveType);
                if (response.IsSuccessStatusCode)
                {
                    return new Response<Guid>() { Success = true };
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    return new Response<Guid>() { Success = false, Message = message };
                }
            }
            catch (Exception ex)
            {
                return new Response<Guid>() { Success = false, Message = ex.Message };
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/LeaveTypes/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return new Response<Guid>() { Success = true };
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    return new Response<Guid>() { Success = false, Message = message };
                }
            }
            catch (Exception ex)
            {
                return new Response<Guid>() { Success = false, Message = ex.Message };
            }
        }
    }
}
