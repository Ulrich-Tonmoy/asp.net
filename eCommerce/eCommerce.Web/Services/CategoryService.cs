using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Category;
using eCommerce.Web.DTOs.Product;
using eCommerce.Web.Helper;
using eCommerce.Web.Services.Interfaces;

namespace eCommerce.Web.Services
{
    public class CategoryService(IHttpClientHelper httpClientHelper, IApiRequestHelper apiRequestHelper) : ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Category.Add,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = category
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<CreateCategory>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Category.Delete,
                Type = Constant.ApiCallType.Delete,
                Client = client,
                Model = null!
            };
            apiRequest.ToString(id);

            var result = await apiRequestHelper.ApiRequestTypeCall<EmptyDTO>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Category.Update,
                Type = Constant.ApiCallType.Update,
                Client = client,
                Id = null!,
                Model = category
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<UpdateCategory>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        // Public api

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Category.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = null!,
                Model = null!
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<IEnumerable<EmptyDTO>>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<IEnumerable<GetCategory>>(result);

            return [];
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Category.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!
            };
            apiRequest.ToString(id);

            var result = await apiRequestHelper.ApiRequestTypeCall<EmptyDTO>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<GetCategory>(result);

            return null!;
        }

        public async Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId)
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Category.GetProductByCategory,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!
            };
            apiRequest.ToString(categoryId);

            var result = await apiRequestHelper.ApiRequestTypeCall<IEnumerable<EmptyDTO>>(apiRequest);

            if (result.IsSuccessStatusCode)
                return await apiRequestHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);

            return [];
        }
    }
}
