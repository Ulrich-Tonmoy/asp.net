using LeaveManagement.UI.DTOs.LeaveRequest;
using LeaveManagement.UI.Services.IServices;
using System.Net.Http.Json;
using System.Text.Json;

namespace LeaveManagement.UI.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public LeaveRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LeaveRequestDto>> GetAllLeaveRequest()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<LeaveRequestDto>>("api/LeaveRequests");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }

        public async Task<LeaveRequestDto> GetLeaveRequestById(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<LeaveRequestDto>($"api/LeaveRequests/{id}");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }

        public async Task<Response<Guid>> CreateLeaveRequest(LeaveRequestDto leaverequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/LeaveRequests", leaverequest);
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

        public async Task<Response<Guid>> UpdateLeaveRequest(LeaveRequestDto leaverequest)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/LeaveRequests/{leaverequest.Id}", leaverequest);
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

        public async Task<Response<Guid>> DeleteLeaveRequest(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/LeaveRequests/{id}");
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
