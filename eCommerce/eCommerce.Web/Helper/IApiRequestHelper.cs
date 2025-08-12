using eCommerce.Web.DTOs;

namespace eCommerce.Web.Helper
{
    public interface IApiRequestHelper
    {
        Task<HttpResponseMessage> ApiRequestTypeCall<TModel>(ApiRequest request);
        Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message);
        ServiceResponse ConnectionError();
    }
}
