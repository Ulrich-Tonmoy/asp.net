using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Product;
using eCommerce.Web.Helper;
using eCommerce.Web.Services.Interfaces;

namespace eCommerce.Web.Services
{
    public class ProductService(IHttpClientHelper httpClientHelper, IApiRequestHelper apiRequestHelper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Product.Add,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = product
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<CreateProduct>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Product.Delete,
                Type = Constant.ApiCallType.Delete,
                Client = client,
                Model = null!
            };
            apiRequest.ToString(id);

            var result = await apiRequestHelper.ApiRequestTypeCall<EmptyDTO>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Product.Update,
                Type = Constant.ApiCallType.Update,
                Client = client,
                Id = null!,
                Model = product
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<UpdateProduct>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Public api

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Product.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = null!,
                Model = null!
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<IEnumerable<EmptyDTO>>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);

            return [];
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Product.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!
            };
            apiRequest.ToString(id);

            var result = await apiRequestHelper.ApiRequestTypeCall<EmptyDTO>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<GetProduct>(result);

            return null!;
        }
    }
}
