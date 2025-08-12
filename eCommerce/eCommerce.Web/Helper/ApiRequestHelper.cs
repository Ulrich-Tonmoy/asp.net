using eCommerce.Web.DTOs;
using System.Net.Http.Json;

namespace eCommerce.Web.Helper
{
    public class ApiRequestHelper : IApiRequestHelper
    {
        public async Task<HttpResponseMessage> ApiRequestTypeCall<TModel>(ApiRequest request)
        {
            try
            {
                switch (request.Type)
                {
                    case Constant.ApiCallType.Post:
                        return await request.Client!.PostAsJsonAsync(request.Route, (TModel)request.Model!);
                    case Constant.ApiCallType.Update:
                        return await request.Client!.PutAsJsonAsync(request.Route, (TModel)request.Model!);
                    case Constant.ApiCallType.Delete:
                        return await request.Client!.DeleteAsync($"{request.Route}/{request.Id}");
                    case Constant.ApiCallType.Get:
                        string route = request.Id != null ? $"/{request.Id}" : "";
                        return await request.Client!.GetAsync($"{request.Route}{route}");
                    default:
                        throw new Exception("Invalid Api request type!");
                }
            }
            catch { return null!; }
        }

        public ServiceResponse ConnectionError()
        {
            return new ServiceResponse(Message: "Error occured in communicating to the server");
        }

        public async Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message)
        {
            var response = await message.Content.ReadFromJsonAsync<TResponse>();
            return response!;
        }
    }
}
