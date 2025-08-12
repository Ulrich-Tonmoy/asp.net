namespace eCommerce.Web.Helper
{
    public class Constant
    {
        public static class Product
        {
            public const string GetAll = "product";
            public const string Get = "product";
            public const string Add = "product";
            public const string Update = "product";
            public const string Delete = "product";
        }

        public static class Category
        {
            public const string GetAll = "category";
            public const string Get = "category";
            public const string GetProductByCategory = "category/products-by-category";
            public const string Add = "category";
            public const string Update = "category";
            public const string Delete = "category";
        }

        public static class Payment
        {
            public const string GetAll = "payment";
        }

        public static class Cart
        {
            public const string Checkout = "cart/checkout";
            public const string SaveCart = "cart/save";
            public const string GetArchive = "cart/archive";
            public const string Name = "my-cart";
            public const long Seconds = 2592000;
        }

        public static class Auth
        {
            public const string Type = "Bearer";
            public const string Register = "auth/create";
            public const string Login = "auth/login";
            public const string RefreshToken = "auth/refresh-token";
        }

        public static class ApiCallType
        {
            public const string Get = "get";
            public const string Post = "post";
            public const string Delete = "delete";
            public const string Update = "update";
        }

        public static class Cookie
        {
            public const string Name = "token";
            public const string Path = "/";
            public const int Days = 86400;
        }

        public static class ApiClient
        {
            public const string Name = "Blazor-Client";
        }

        public static class Administration
        {
            public const string AdminRole = "Admin";
        }
    }
}
