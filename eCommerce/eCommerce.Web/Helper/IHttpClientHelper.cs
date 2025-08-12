namespace eCommerce.Web.Helper
{
    public interface IHttpClientHelper
    {
        HttpClient GetPublicClient();
        Task<HttpClient> GetPrivateClientAsync();
    }
}
