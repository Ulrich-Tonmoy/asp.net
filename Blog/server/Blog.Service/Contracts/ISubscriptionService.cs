using Blog.DTO.SubscriptionDTO;

namespace Blog.Service.Contracts
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionResponseDTO>> GetAllSubscriptionAsync();
        Task<SubscriptionResponseDTO> GetSubscriptionByIdAsync(Guid id);
        Task<SubscriptionResponseDTO> CreateSubscriptionAsync(SubscriptionCreateDTO sub);
        Task<SubscriptionResponseDTO> UpdateSubscriptionAsync(SubscriptionUpdateDTO sub);
        Task<string> DeleteSubscriptionAsync(Guid id);
        Task<bool> AnySubscriptionAsync(string email);
        Task<int> CountAllSubscriptionAsync();
    }
}
