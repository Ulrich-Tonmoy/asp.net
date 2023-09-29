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

        public Task<LeaveTypeDto> GetLeaveTypeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateLeaveType(CreateLeaveTypeDto leaveType)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("api/LeaveTypes", leaveType);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }

        public async Task UpdateLeaveType(LeaveTypeDto leaveType)
        {
            try
            {
                await _httpClient.PutAsJsonAsync("api/LeaveTypes", leaveType);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }

        public async Task<bool> DeleteLeaveType(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/LeaveTypes/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                throw;
            }
        }
    }
}
