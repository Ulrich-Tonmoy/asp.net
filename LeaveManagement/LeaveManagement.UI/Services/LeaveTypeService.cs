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
                var response = await _httpClient.GetAsync($"api/LeaveTypes");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<LeaveTypeDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<LeaveTypeDto>>();
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

        public Task<LeaveTypeDto> GetLeaveTypeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeDto> CreateLeaveType(CreateLeaveTypeDto leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeDto> UpdateLeaveType(LeaveTypeDto leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLeaveType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
