using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Cart;
using eCommerce.Web.Helper;
using eCommerce.Web.Services.Interfaces;

namespace eCommerce.Web.Services
{
    public class PaymentMethodService(IHttpClientHelper httpClientHelper, IApiRequestHelper apiRequestHelper) : IPaymentMethodService
    {
        public async Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods()
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Payment.GetAll,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = null!,
                Model = null!
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<IEnumerable<EmptyDTO>>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<IEnumerable<GetPaymentMethod>>(result);

            return [];
        }
    }
}
