namespace eCommerce.Web.DTOs
{
    public class ApiRequest
    {
        public string? Type { get; set; }
        public HttpClient? Client { get; set; }
        public string? Route { get; set; }
        public dynamic? Model { get; set; }
        public string? Id { get; set; }
        public void ToString(Guid id) => Id = id.ToString();
    }
}
