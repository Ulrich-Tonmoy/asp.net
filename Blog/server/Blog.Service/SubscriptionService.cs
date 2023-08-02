using Blog.Common;
using Blog.DTO.SubscriptionDTO;
using Blog.Model;
using Blog.Repository;
using Blog.Service.Contracts;

namespace Blog.Service
{
    public class SubscriptionService : ISubscriptionService
    {
        private IUnitOfWork _unitOfWork;

        public SubscriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SubscriptionResponseDTO>> GetAllSubscriptionAsync()
        {
            List<Subscription> subscriptions = _unitOfWork.SubscriptionRepository.GetAllNoTracking().ToList();
            List<SubscriptionResponseDTO> subscriptionsResult = Mapping.Mapper.Map<List<SubscriptionResponseDTO>>(subscriptions);

            return subscriptionsResult;
        }

        public async Task<SubscriptionResponseDTO> GetSubscriptionByIdAsync(Guid id)
        {
            Subscription subscription = _unitOfWork.SubscriptionRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            SubscriptionResponseDTO subscriptionResult = Mapping.Mapper.Map<SubscriptionResponseDTO>(subscription);

            return subscriptionResult;
        }

        public async Task<SubscriptionResponseDTO> CreateSubscriptionAsync(SubscriptionCreateDTO sub)
        {
            Subscription subscriptionModel = Mapping.Mapper.Map<Subscription>(sub);

            await _unitOfWork.SubscriptionRepository.AddAsync(subscriptionModel);
            await _unitOfWork.SaveAsync();

            SubscriptionResponseDTO subscriptionResult = Mapping.Mapper.Map<SubscriptionResponseDTO>(subscriptionModel);

            return subscriptionResult;
        }

        public async Task<SubscriptionResponseDTO> UpdateSubscriptionAsync(SubscriptionUpdateDTO sub)
        {
            Subscription subscriptionEntity = _unitOfWork.SubscriptionRepository.GetByConditionNoTracking(c => c.Id.Equals(sub.Id)).FirstOrDefault();

            if (subscriptionEntity == null) return null;

            Mapping.Mapper.Map(sub, subscriptionEntity);

            await _unitOfWork.SubscriptionRepository.Update(subscriptionEntity);
            await _unitOfWork.SaveAsync();

            SubscriptionResponseDTO subscriptionResult = Mapping.Mapper.Map<SubscriptionResponseDTO>(subscriptionEntity);

            return subscriptionResult;
        }

        public async Task<string> DeleteSubscriptionAsync(Guid id)
        {
            Subscription subscription = _unitOfWork.SubscriptionRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();

            if (subscription == null) return null;

            await _unitOfWork.SubscriptionRepository.Delete(subscription);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Subscription");
        }

        public async Task<bool> AnySubscriptionAsync(string email)
        {
            return await _unitOfWork.SubscriptionRepository.AnyAsync(c => c.Email.Equals(email));
        }

        public async Task<int> CountAllSubscriptionAsync()
        {
            return await _unitOfWork.SubscriptionRepository.CountAllAsync();
        }
    }
}
