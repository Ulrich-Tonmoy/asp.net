using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Cart;
using eCommerce.Web.Helper;
using eCommerce.Web.Services.Interfaces;

namespace eCommerce.Web.Services
{
    public class CartService(IHttpClientHelper httpClientHelper, IApiRequestHelper apiRequestHelper) : ICartService
    {
        public async Task<ServiceResponse> Checkout(Checkout checkout)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var model = new ApiRequest
            {
                Route = Constant.Cart.Checkout,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = checkout
            };
            var result = await apiRequestHelper.ApiRequestTypeCall<Checkout>(model);
            if (result == null) return apiRequestHelper.ConnectionError();
            return await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<IEnumerable<GetArchive>> GetArchives()
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Cart.GetArchive,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = null!,
                Model = null!
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<IEnumerable<EmptyDTO>>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<IEnumerable<GetArchive>>(result);

            return [];
        }

        public async Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateAchieve> archives)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var model = new ApiRequest
            {
                Route = Constant.Cart.SaveCart,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = archives
            };
            var result = await apiRequestHelper.ApiRequestTypeCall<IEnumerable<CreateAchieve>>(model);
            if (result == null) return apiRequestHelper.ConnectionError();
            return await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }
    }
}
